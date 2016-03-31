FROM docker.io/colemickens/polykube-aspnet-base

ADD . /opt/polykube/dotnet
WORKDIR /opt/polykube/dotnet
RUN make build
CMD make -s tar-out
