#!/bin/bash

.NOTPARALLEL:

CURDIR = $(shell pwd)

build-api:
	dotnet restore
	(cd src/Dotkube.Api; dotnet publish)

run-api:
	dotnet restore
	(cd src/Dotkube.Api; dotnet run)

test-api:
	dotnet restore
	(cd test/Dotkube.Tests; dotnet test)

docker-build-devenv:
	docker build -f ./dockerfiles/dotkube-dotnet-dev/Dockerfile -t dotkube-dotnet-dev .

docker-build-api-service: docker-build-devenv
	docker build -f ./dockerfiles/dotkube-api-service/Dockerfile -t dotkube-api-service .

docker-build-api-nginx:
	docker build -f ./dockerfiles/dotkube-api-nginx/Dockerfile -t dotkube-api-nginx .

docker-run-api-service:
	docker run -it \
		-p 5000:5000 \
		dotkube-api-service

docker-run-api-nginx:
	docker run -it \
		-p 5000:5000 \
		dotkube-api-nginx

docker-devenv: docker-build-devenv
	docker run -it \
		-p 5000:5000 \
		-v $(CURDIR):/opt/dotkube \
		-w /opt/dotkube/ \
		dotkube-dotnet-dev /bin/bash; true

docker-push:
	docker tag -f dotkube-api-service docker.io/colemickens/dotkube-api-service:latest
	docker tag dotkube-api-nginx docker.io/colemickens/dotkube-api-nginx:latest
	docker push gcr.io/dotkube/api-service
	docker push gcr.io/dotkube/api-nginx

kubernetes-deploy:
	kubectl create -f ./kubernetes/api-rc.json
	kubectl create -f ./kubernetes/api-svc.json
