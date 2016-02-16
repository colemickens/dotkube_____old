.NOTPARALLEL:

CURDIR = $(shell pwd)
REPO = 'docker.io/colemickens'

build:
	cd rustful; cargo build --release

run:
	cd rustful; cargo run

test:
	cd rustful; cargo test

tar-out:
	tar -cf - -C ./dockerfiles/rustful-service/ ./Dockerfile -C ./../../rustful/target/debug/ ./rustfulapi

docker-build-rust-base:
	docker build -f ./dockerfiles/rust-base/Dockerfile -t $(REPO)/polykube-rust-base .

docker-build-rustful-service-builder: docker-build-rust-base
	docker build -f ./dockerfiles/rustful-service-builder/Dockerfile -t $(REPO)/polykube-rustful-service-builder .

docker-build-rustful-service: docker-build-rustful-service-builder
	docker run $(REPO)/polykube-rustful-service-builder | \
		docker build -f ./Dockerfile -t $(REPO)/polykube-rustful-service -

docker-run-rustful-service:
	docker run -it \
		-p 0.0.0.0:9020:9020 \
		$(REPO)/polykube-rustful-service

docker-devenv: docker-build-rust-base
	docker run -it \
		-p 0.0.0.0:9020:9020 \
		-v $(CURDIR):/opt/polykube \
		$(REPO)/polykube-rustful-service-builder /bin/bash; true

docker-push-rustful-service:
	docker push $(REPO)/polykube-rustful-service
