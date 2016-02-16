FROM docker.io/colemickens/polykube-golang-base

ADD . /opt/polykube/golang

ENV GOPATH /opt/gopath
RUN mkdir /opt/gopath

WORKDIR /opt/polykube/golang
RUN make build

CMD make -s tar-out
