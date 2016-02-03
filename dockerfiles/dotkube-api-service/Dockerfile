FROM dotkube-dotnet-dev

ADD . /opt/dotkube

WORKDIR /opt/dotkube/
RUN bash -c "make build-api"

WORKDIR /opt/dotkube/dotnet/Dotkube.Api/bin/Release/dnxcore50/ubuntu.14.04-x64/
#WORKDIR /opt/dotkube/dotnet/Dotkube.Api/bin/Release/dnxcore50/ubuntu.14.04-x64/
CMD bash -c "./Dotkube.Api"
