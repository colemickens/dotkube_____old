#!/bin/bash

.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = docker.io/colemickens
PROJECTNAME=dotkube
IMAGE_FINAL = $(REPO)/$(PROJECTNAME)-www
IMAGE_DEVENV = $(REPO)/$(PROJECTNAME)-www-devenv

docker-run-www: docker-build-www
	docker run -it \
		-p 0.0.0.0:8000:8000 \
		$(IMAGE_FINAL)

docker-build-www-service:
	docker build \
		-f blah
		-t $(IMAGE_FINAL)

docker-build-www-devenv:
	docker build \
		-f ./dockerfiles/www-dev/Dockerfile \
		-t $(IMAGE_DEVENV) \
		.

docker-devenv: docker-build-www-devenv
	docker run -it \
		-p 0.0.0.0:3000:3000 \
		-v $(CURDIR):/opt/$(PROJECTNAME) \
		$(IMAGE_DEVENV) /bin/bash; true

docker-push-www:
	docker push $(IMAGE_FINAL)
