.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = docker.io/colemickens
IMAGE_FINAL = $(REPO)/polykube-aspnet-api-service
IMAGE_BUILD = $(REPO)/polykube-aspnet-api-builder
IMAGE_DEVENV = $(REPO)/polykube-aspnet-base
IMAGE_NGINX = $(REPO)/polykube-aspnet-api-nginx

build:
	dotnet restore -v Verbose
	(dotnet -v publish -c Release Polykube.Api/project.json)

run:
	dotnet restore -v Verbose
	(dotnet -v run -p Polykube.Api/project.json)

test:
	dotnet restore -v Verbose
	cd test/Polykube.Tests; dotnet -v test dotnet/Polykube.Tests/project.json

tar-out:
	tar -cf - -C ./dockerfiles/aspnet-api-service/ ./Dockerfile -C ./../../Polykube.Api/bin/Release/netcoreapp1.0/ .

docker-build-aspnet-base:
	docker build -f ./dockerfiles/aspnet-base/Dockerfile -t $(IMAGE_DEVENV) .

docker-build-aspnet-api-builder: docker-build-aspnet-base
	docker build \
		-f ./dockerfiles/aspnet-api-builder/Dockerfile \
		-t $(IMAGE_BUILD) \
		.

docker-build-aspnet-api-service: docker-build-aspnet-api-builder
	docker run $(IMAGE_BUILD) | \
		docker build \
			-f ./Dockerfile \
			-t $(IMAGE_FINAL) \
			-

docker-build-aspnet-api-nginx:
	dockr build -f ./dockerfiles/aspnet-nginx/Dockerfile -t $(IMAGE_NGINX) .

docker-run-aspnet-api-service:
	docker run -it \
		-p 0.0.0.0:9010:9010 \
		$(IMAGE_FINAL)

docker-devenv: docker-build-aspnet-base
	docker run -it \
		-p 0.0.0.0:9010:9010 \
		-v $(CURDIR):/opt/polykube \
		-v $(CURDIR)/.nuget-cache:/root/.local/share/NuGet \
		$(IMAGE_DEVENV) /bin/bash; true

docker-push-aspnet-api-service: docker-build-aspnet-api-service
	docker push $(IMAGE_FINAL)

docker-push-aspnet-api-nginx: docker-build-aspnet-api-nginx
	docker push $(IMAGE_NGINX)
