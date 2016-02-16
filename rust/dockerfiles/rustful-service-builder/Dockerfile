FROM docker.io/colemickens/polykube-rust-base

ADD . /opt/polykube/rust/

WORKDIR /opt/polykube/rust/rustful
RUN cargo build

WORKDIR /opt/polykube/rust
CMD make -s tar-out
