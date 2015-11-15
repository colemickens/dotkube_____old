#!/bin/bash

.NOTPARALLEL:

CURDIR = $(shell pwd)

build-api:
	dnu restore
	cd src/Dotkube.Api; dnu publish --no-source

run-api:
	dnu restore
	cd src/Dotkube.Api; dnx kestrel

test-api:
	dnu restore
	cd test/Dotkube.Tests
	dnx test

docker-build-devenv:
	sudo chmod -R +rx .
	docker build -f ./dockerfiles/dotkube-dotnet-dev/Dockerfile -t dotkube-dotnet-dev .

docker-build-api-service: docker-build-devenv
	sudo chmod -R +rx .
	docker build -f ./dockerfiles/dotkube-api-service/Dockerfile -t dotkube-api-service .

docker-build-api-nginx:
	docker build -f ./dockerfiles/dotkube-api-nginx/Dockerfile -t dotkube-api-nginx .

docker-run-api-service:
	docker run -it \
		-p 8000:8000 \
		dotkube-api-service

docker-run-api-nginx:
	docker run -it \
		-p 9000:9000 \
		dotkube-api-nginx

docker-devenv: docker-build-devenv
	docker run -it \
		-p 8000:8000 \
		-v $(CURDIR):/opt/dotkube \
		-w /opt/dotkube/ \
		dotkube-dotnet-dev /bin/bash; true

docker-push:
	docker tag -f dotkube-api-service gcr.io/dotkube/api-service:latest
	docker tag dotkube-api-nginx gcr.io/dotkube/api-nginx
	gcloud docker push gcr.io/dotkube/api-service
	gcloud docker push gcr.io/dotkube/api-nginx

kubernetes-deploy:
	kubectl create -f ./kubernetes/api-rc.json
	kubectl create -f ./kubernetes/api-svc.json
