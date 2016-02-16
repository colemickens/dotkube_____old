.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = 'docker.io/colemickens'

build:
	cd goa; go get ./...; CGO_ENABLED=0 go build -a -tags netgo -installsuffix nocgo -ldflags '-w' -o cellar .

run:
	cd goa; go get .; go run main.go

test:
	cd goa; go test

tar-out:
	tar -cf - -C ./dockerfiles/goa-service/ ./Dockerfile -C ./../../goa/ ./cellar

docker-build-golang-base:
	docker build -f ./dockerfiles/golang-base/Dockerfile -t $(REPO)/polykube-golang-base .

docker-build-goa-service-builder: docker-build-golang-base
	docker build -f ./dockerfiles/goa-service-builder/Dockerfile -t $(REPO)/polykube-goa-service-builder .

docker-build-goa-service: docker-build-goa-service-builder
	docker run $(REPO)/polykube-goa-service-builder | \
		docker build -f ./Dockerfile -t $(REPO)/polykube-goa-service -

docker-run-goa-service:
	docker run -it \
		-p 0.0.0.0:9030:9030 \
		$(REPO)/polykube-goa-service

docker-devenv: docker-build-golang-base
	docker run -it \
		-p 0.0.0.0:9030:9030 \
		-v $(CURDIR):/opt/polykube \
		$(REPO)/polykube-goa-service-builder /bin/bash; true

docker-push-goa-service:
	docker push $(REPO)/polykube-goa-service
