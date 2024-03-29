# dotkube

Kubernetes + Azure + AspNetCore


## Kubernetes features

0. Basics

   Uses ReplicationControllers, Pods, Services.
   Eventually will use Deployments when the Dashboard supports it.
   (Makes for a slightly more interesting demo to show the Dashboard.)

1. Secrets

   Uses a secret to hold Azure Storage connection secrets for the internal Docker registry.
   Uses a secret to hold another secret used as the login password for the database.

2. ~~Deployments~~

   Not yet, waiting on Dashboard support for Deployments/ReplicaSets

3. Service Discovery

   Uses the DNS addon (SkyDNS) to resolve services at runtime in cluster.
   (The dotnet api literally connects to "db" as the hostname.)


## Azure features

0. Docker registry backed by Azure Storage

   All of the component Docker containers are pushed to a registry self-hosted in Kubernetes.
   This registry is backed by Azure Blob Storage.

1. ~~Native cloudprovider support (TCP LB only, for now)~~

   Not yet. Soon hopefully...


## AspNetCore features

1. CoreCLR on Linux. 'Nuff said.

2. AspNetCore on Linux. Woot.
