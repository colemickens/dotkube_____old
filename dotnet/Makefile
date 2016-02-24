.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = 'docker.io/colemickens'

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
	tar -cf - -C ./dockerfiles/aspnet-service/ ./Dockerfile -C ./../../Polykube.Api/bin/Release/dnxcore50/ubuntu.14.04-x64/ .

# TODO: remove when dotnet publish docker images
docker-build-dotnet-base:
	docker build -f ./dockerfiles/dotnet-base/Dockerfile -t $(REPO)/polykube-dotnet-base .

docker-build-aspnet-service-builder: docker-build-dotnet-base
	docker build \
		-f ./dockerfiles/aspnet-service-builder/Dockerfile \
		-t $(REPO)/polykube-aspnet-service-builder \
		.

docker-build-aspnet-service: docker-build-aspnet-service-builder
	docker run $(REPO)/polykube-aspnet-service-builder | \
		docker build \
			-f ./Dockerfile \
			-t $(REPO)/polykube-aspnet-service \
			-

docker-run-aspnet-service:
	docker run -it \
		-p 0.0.0.0:9010:9010 \
		$(REPO)/polykube-aspnet-service

docker-devenv: docker-build-dotnet-base
	docker run -it \
		-p 0.0.0.0:9010:9010 \
		-v $(CURDIR):/opt/polykube \
		-v $(CURDIR)/nuget-cache:/root/.local/share/NuGet \
		$(REPO)/polykube-aspnet-service-builder /bin/bash; true

docker-push-aspnet-service:
	docker push $(REPO)/polykube-aspnet-service
