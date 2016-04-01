NOTPARALLEL:

kubectl=kubectl
namespace=dotkube

all:

reset:
	$(kubectl) delete ns/dotkube

reset-all:
	$(kubectl) delete ns/default
	$(kubectl) delete ns/kube-system


deploy-registry:
	# ensure storage account exists
	# ensure storage container exists
	ifndef AZURE_STORAGE_ACCOUNT
		$(error AZURE_STORAGE_ACCOUNT is undefined)
	endif
	ifndef AZURE_STORAGE_KEY
		$(error AZURE_STORAGE_KEY is undefined)
	endif
	$(kubectl) create secret generic \
		azure-registry-storage-secret \
		--from-literal=AZURE_STORAGE_ACCOUNTNAME=$(AZURE_STORAGE_ACCOUNT) \
		--from-literal=AZURE_STORAGE_KEY=$(AZURE_STORAGE_KEY) \
		--from-literal=AZURE_STORAGE_CONTAINER=$(AZURE_STORAGE_CONTAINER)
	$(kubectl) create -f ./svc-registry.yaml
	$(kubectl) create -f ./rc-registry.yaml
	$(kubectl) create -f ./ds-registry-proxy.yaml

deploy:
	$(kubectl) create --namespace=$(namespace) -f ./svc-aspnet-api.yaml
	$(kubectl) create --namespace=$(namespace) -f ./svc-db.yaml
	$(kubectl) create --namespace=$(namespace) -f ./rc-aspnet-api.yaml
	$(kubectl) create --namespace=$(namespace) -f ./rc-db.yaml
