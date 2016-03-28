#!/bin/bash

.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = docker.io/colemickens
IMAGE = $(REPO)/polykube-www

docker-build-www:
	docker build -f ./dockerfiles/www-nginx/Dockerfile -t $(REPO)/polykube-www .

docker-run-www: docker-build-www
	docker run -it \
		-p 0.0.0.0:9000:80 \
		$(IMAGE)

docker-build-www-service:
	docker build \
		-f blah
		-t blah


docker-build-www-dev:
	docker build \
		-f ./dockerfiles/www-dev/Dockerfile \
		-t $(REPO)/polykube-www-dev \
		.

docker-devenv: docker-build-www-dev
	docker run -it \
		-p 0.0.0.0:9000:80 \
		-v $(CURDIR):/opt/polykube \
		$(REPO)/polykube-www-dev /bin/bash; true

docker-push-www:
	docker push $(IMAGE)
