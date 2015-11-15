FROM dotkube-dotnet-dev

ADD . /opt/dotkube

RUN bash -l -c "cd /opt/dotkube; make build-api"

WORKDIR /opt/dotkube/src/Dotkube.Api/bin/output/approot

CMD bash -l -c "./kestrel"

EXPOSE 8000
