FROM docker.io/ubuntu:16.04

RUN apt-get update && apt-get install -y npm nodejs

RUN ln -s /usr/bin/nodejs /usr/bin/node

RUN npm install -g webpack webpack-dev-server typings typescript ts-node

CMD /bin/bash
