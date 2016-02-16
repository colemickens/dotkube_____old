#[macro_use]
extern crate rustful;

use std::io::{self, Read};
use std::fs::File;
use std::path::Path;
use std::sync::{Arc, RwLock};
use std::error::Error;

#[macro_use]
extern crate log;
extern crate env_logger;

use rustful::{
    Server,
    Context,
    Response,
    Handler,
    TreeRouter,
    StatusCode
};
use rustful::file::check_path;

fn main() {
    env_logger::init().unwrap();

    println!("Visit http://localhost:9020 to try this example.");

    //Read the page before we start
    // let page = Arc::new(read_string("examples/handler_storage/page.html").unwrap());

    //The shared counter state
    let value = Arc::new(RwLock::new(0));

    let router = insert_routes!{
        TreeRouter::new() => {
            Get: Api::Counter {
                value: value.clone(),
                operation: None
            },
            "add" => Get: Api::Counter {
                value: value.clone(),
                operation: Some(add)
            },
            "sub" => Get: Api::Counter {
                value: value.clone(),
                operation: Some(sub)
            },
        }
    };

    let server_result = Server {
        host: 9020.into(),	
        handlers: router,
        content_type: content_type!(Text / Html; Charset = Utf8),
        ..Server::default()
    }.run();

    match server_result {
        Ok(_server) => {},
        Err(e) => error!("could not start server: {}", e.description())
    }
}


fn add(value: i32) -> i32 {
    value + 1
}

fn sub(value: i32) -> i32 {
    value - 1
}

fn read_string<P: AsRef<Path>>(path: P) -> io::Result<String> {
    //Read file into a string
    let mut string = String::new();
    File::open(path).and_then(|mut f| f.read_to_string(&mut string)).map(|_| string)
}


enum Api {
    Counter {
        value: Arc<RwLock<i32>>,
        operation: Option<fn(i32) -> i32>
    },
    File
}

impl Handler for Api {
    fn handle_request(&self, context: Context, mut response: Response) {
        match *self {
            Api::Counter { ref value, ref operation }  => {
                operation.map(|op| {
                    //Lock the value for writing and update it
                    let mut value = value.write().unwrap();
                    *value = op(*value);
                });

                //Insert the value into the page and write it to the response
                let count = value.read().unwrap().to_string();
                response.send(format!("\"count\": {}", &count[..]));
            },
            Api::File => {
                if let Some(file) = context.variables.get("file") {
                    let file_path = Path::new(file.as_ref());

                    //Check if the path is valid
                    if check_path(file_path).is_ok() {
                        //Make a full path from the file name and send it
                        let path = Path::new("examples/handler_storage").join(file_path);
                        let res = response.send_file(path)
                            .or_else(|e| e.send_not_found("the file was not found"))
                            .or_else(|e| e.ignore_send_error());

                        //Check if a more fatal file error than "not found" occurred
                        if let Err((error, mut response)) = res {
                            //Something went horribly wrong
                            error!("failed to open '{}': {}", file, error);
                            response.set_status(StatusCode::InternalServerError);
                        }
                    } else {
                        //Accessing parent directories is forbidden
                        response.set_status(StatusCode::Forbidden);
                    }
                } else {
                    //No file name was specified
                    response.set_status(StatusCode::Forbidden);
                }
            }
        }
    }
}
