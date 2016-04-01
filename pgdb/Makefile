.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = docker.io/colemickens
PROJECTNAME=dotkube
IMAGE_FINAL = $(REPO)/$(PROJECTNAME)-pgdb

docker-build-pgdb:
	docker build -f ./dockerfiles/db/Dockerfile -t $(IMAGE_FINAL) .

docker-run-pgdb:
	docker run -it \
		-p 0.0.0.0:5432:5432 \
		$(IMAGE_FINAL)
