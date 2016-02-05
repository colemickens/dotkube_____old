#!/bin/bash

.NOTPARALLEL:

CURDIR = $(shell pwd)

build-api:
	dotnet restore -v Verbose
	dotnet -v publish -c Release dotnet/Dotkube.Api/project.json

run-api:
	dotnet restore -v Verbose
	dotnet -v run dotnet/Dotkube.Api/project.json

test-api:
	dotnet restore -v Verbose
	cd test/Dotkube.Tests; dotnet -v test dotnet/Dotkube.Tests/project.json

docker-build-devenv:
	docker build -f ./dockerfiles/dotkube-dotnet-dev/Dockerfile -t dotkube-dotnet-dev .

docker-build-api-service: docker-build-devenv
	docker build -f ./dockerfiles/dotkube-api-service/Dockerfile -t dotkube-api-service .

docker-build-api-nginx:
	docker build -f ./dockerfiles/dotkube-api-nginx/Dockerfile -t dotkube-api-nginx .

docker-run-api-service:
	docker run -it \
		-p 0.0.0.0:5000:5000 \
		dotkube-api-service

docker-run-api-nginx:
	docker run -it \
		-p 0.0.0.0:8000:80 \
		dotkube-api-nginx

docker-devenv: docker-build-devenv
	docker run -it \
		-p 0.0.0.0:5000:5000 \
		-v $(CURDIR):/opt/dotkube \
		-v $(CURDIR)/nuget-cache:/root/.local/share/NuGet \
		-w /opt/dotkube/ \
		dotkube-dotnet-dev /bin/bash; true

docker-push:
	docker tag -f dotkube-api-service docker.io/colemickens/dotkube-api-service:latest
	docker tag -f dotkube-api-nginx docker.io/colemickens/dotkube-api-nginx:latest
	docker push colemickens/dotkube-api-service
	docker push colemickens/dotkube-api-nginx

kubernetes-deploy:
	kubectl create -f ./kubernetes/api-rc.json
	kubectl create -f ./kubernetes/api-svc.json
