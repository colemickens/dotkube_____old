#!/bin/bash

.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = "docker.io/colemickens"

docker-build-www:
	docker build -f ./dockerfiles/www-nginx/Dockerfile -t $(REPO)/polykube-www .

docker-run-www: docker-build-www
	docker run -it \
		-p 0.0.0.0:9000:9000 \
		$(REPO)/polykube-www

docker-push-www:
	#docker tag -f polykube-aspnet-service $(REPO)/polykube-aspnet-service:latest
	docker push $(REPO)/polykube-aspnet-www
