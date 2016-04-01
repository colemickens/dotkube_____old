.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = docker.io/colemickens
PROJECTNAME=dotkube
IMAGE_FINAL = $(REPO)/$(PROJECTNAME)-db

docker-build-db:
	docker build -f ./dockerfiles/db/Dockerfile -t $(IMAGE_FINAL) .

docker-run-db:
	docker run -it \
		-p 0.0.0.0:1433:1433 \
		$(IMAGE_FINAL)
