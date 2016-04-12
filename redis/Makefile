.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = docker.io/colemickens
PROJECTNAME=dotkube
IMAGE_FINAL = $(REPO)/$(PROJECTNAME)-rediscache

docker-build-rediscache:
	docker build -f ./dockerfiles/cache/Dockerfile -t $(IMAGE_FINAL) .

docker-run-rediscache:
	docker run -it \
		-p 0.0.0.0:6379:6379 \
		$(IMAGE_FINAL)
