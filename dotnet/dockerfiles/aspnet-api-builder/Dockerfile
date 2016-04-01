FROM docker.io/colemickens/dotkube-aspnet-base

ADD . /opt/dotkube/dotnet
WORKDIR /opt/dotkube/dotnet
RUN make build
CMD make -s tar-out
