NOTPARALLEL:

# TODO: make sure all of the services/rcs are in a polykube namespace

all:
	$(KUBECTL) delete ns/polykube

deploy:
	$(KUBECTL) create -f ./api-svc.yaml
	$(KUBECTL) create -f ./aspnet-api-svc.yaml
	$(KUBECTL) create -f ./db-svc.yaml
	
	$(KUBECTL) create -f ./api-rc.yaml
	$(KUBECTL) create -f ./aspnet-api-rc.yaml
	$(KUBECTL) create -f ./db-rc.yaml
