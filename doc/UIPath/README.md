# Interview Companion

## Basic

1. [Control Structures](./1.interview1.md#control-structures)
2. [Data Structures](./1.interview1.md#data-structures)
3. [OOP](./1.interview1.md#oop)
4. [SOLID](./1.interview1.md#solid-principles)
5. [Design Patterns](./1.interview1.md#design-patterns)
6. [Functional Programming](./1.interview1.md#fp)


## Distributed Apps

1. [RESTful](./1.interview1.md#restful-services)
2. [Reactive](./1.interview1.md#reactive-manifesto)
3. [Resilience](./1.interview1.md#resilience-patterns)


## Storage

1. [Database](./1.interview1.md#database)
2. [NOSQL](./1.interview1.md#nosql)
3. [Transaction isolation](./1.interview1.md#transaction-isolation)


## Architecture

1. [Architecture](./1.interview1.md#architecture)

## Performance

1. [Garbage Collection](../expert/java_garbagecollectors.md#java-garbage-collectors)
2. [Java Memory](../expert/java_garbagecollectors.md#jvm-memory-areas)
3. [Java Heap Memory](../expert/java_garbagecollectors.md#heap-memory-areas-generations)
4. [Memory Leaks](../expert/java_garbagecollectors.md#memory-leak)

## Concurrency, parallelism, asynchrony

1. [Concurrency Basics](../expert/concurrency_parallelism_asychrony.md#basics-concepts)
2. [Concurrency Advanced](../expert/concurrency_parallelism_asychrony.md#advanced-concepts)

3. [Thread scheduling](../expert/concurrency_parallelism_asychrony.md#threads-vs-processes)
4. [KotlinContinuous Passing Style](../expert/concurrency_parallelism_asychrony.md#continuous-passing-style-cps-in-kotlin)
5. [Kotlin Structured Concurrency](../expert/concurrency_parallelism_asychrony.md#structure-concurrency)
6. [Other Kotlin Coroutines Features](../expert/concurrency_parallelism_asychrony.md#other-kotlin-coroutines-features)
7. [Interprocess comunication](../expert/concurrency_parallelism_asychrony.md#inter-process-communication-techniques)
8. [Thread scheduling](../expert/concurrency_parallelism_asychrony.md#threads-scheduling)
9. [Concurrent Collection](../expert/concurrency_parallelism_asychrony.md#concurrent-collections)
10. [Actor Model - Aka](../expert/concurrency_parallelism_asychrony.md#actor-model-in-akka)

11. Main building blocks for asynchronous programming in Java:
  - Future
  - CompletableFuture
  - Fork Join Pool
  - ExecutorService
  - Executor

## TODO

#### .NET

- [.NET ecosystem](../dotnet/dotnet_ecosystem.md#community)
- [.NET tools](../dotnet/dotnet_ecosystem.md#tools)

#### OPs

- Docker (Docker-compose)
  It is a platform for developing, shipping, and running applications. It consists of:
     - Docker Engine
     - Docker Compose
     - Docker Hub
     - Docker images
     - Docker containers
     - Docker networks
     - Docker ports mapping
     - Docker volumes
     - Docker-compose file: version, services, networks, volumes
     - Dockerfile (instructions: FROM, RUN, COPY, CMD, EXPOSE, ENV, WORKDIR, VOLUME, ENTRYPOINT)
     A docker container running on a host machine shares the host's kernel, but it runs as a separate process in user space.
     The files inside the docker container are stored in a read-write layer on top of the read-only image layer.
     
- Azure DevOps (ADO)
  - Pipelines (CI/CD)
    - pipeline elements (templates, stages, jobs, tasks, triggers, variables, parameters, conditions, branches - if, dependsOn)

- Kubernetes 
  Its architecture consists:
  - Master node
  - Worker node
  - Pod 
    It is smallest deployable unit that can be created, scheduled, and managed, can contain one or more (docker) containers, shared network namespace, shared storage.
    Probe: Liveness, Readiness are used by k8s to check the health of the container inside the pod.
  - Service
  - Deployment
  - ReplicaSet
  - Helm - is a package manager for Kubernetes

- Ansible
  Its elements/architecture (Inventory, Playbook, Role, Module, Task, Handler, Vault, Ansible Galaxy, Ansible Tower

- OpenShift is offered by Red Hat as a Platform as a Service (PaaS) solution, k8s-based

#### Security

- [OAuth2](./4.OAuth2.md#oauth-20)

- Certificates:
  - Signature
  - Algorithms: RSA, DSA, ECDSA, EdDSA
  - openssl, keytool
  - SSL/TLS - Secure Socket Layer/Transport Layer Security
  - SSH - Secure Shell
  - HTTPS - HTTP Secure
  - PKI - Public Key Infrastructure
  - CA - Certificate Authority
  - Public/Private keys

#### Web vulnerabilities (OWASP)

Types:
  - SQL Injection
  - XSS - Cross Site Scripting
  - CSRF - Cross Site Request Forgery
  - DoS - Denial of Service
  - DDoS - Distributed Denial of Service
  - RCE - Remote Code Execution
  - SSRF - Server Side Request Forgery
  - Insecure Deserialization
  - RegEx DoS

