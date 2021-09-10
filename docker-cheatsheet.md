# Docker Cheat Sheet

## Images

### Download Docker Images

Download a Docker Image

```bash 
docker pull IMAGE_NAME
```

 Download a tagged Docker Image

```bash
docker pull IMAGE_NAME:TAG_NAME
```

**Documentation**

- [Docker Pull Command](https://docs.docker.com/engine/reference/commandline/pull/)

### List and Remove Docker Images

List Docker Images

```bash
docker image ls
```

Remove Docker Image

```bash
docker image rm IMAGE_NAME
```

Shorthand to Remove a Docker Image

```bash
docker rmi IMAGE_NAME
```

**Documentation**

- [Docker Image List Command](https://docs.docker.com/engine/reference/commandline/image_ls/)
- [Docker Image List Command Options](https://github.com/moby/moby/blob/10c0af083544460a2ddc2218f37dc24a077f7d90/docs/reference/commandline/images.md)
- [Docker Remove Image Command](https://docs.docker.com/engine/reference/commandline/rmi/)

### Tagging Docker Images

Tag Docker Image

```bash
docker image tag IMAGE_NAME NEW_IMAGE_NAME:TAG_NAME
```

**Documentation**

- [Docker Image Tag Command](https://docs.docker.com/engine/reference/commandline/image_tag/)

### Publish a Docker Image to Docker Hub

Docker Hub Login

```bash
docker login
```

Docker Hub Logout

```bash
docker logout
```

Push Image to Docker Hub

```bash
docker push IMAGE_NAME
```

Pull Image from Docker Hub

```bash
docker pull IMAGE_NAME
```

**Documentation**

- [Docker Login Command](https://docs.docker.com/engine/reference/commandline/login/)
- [Docker Logout Command](https://docs.docker.com/engine/reference/commandline/logout/)
- [Docker Push Command](https://docs.docker.com/engine/reference/commandline/push/)
- [Docker Pull Command](https://docs.docker.com/engine/reference/commandline/pull/)

## Containers

### List Containers

Docker Run Command

```bash
docker run -d --name CONTAINER_NAME IMAGE_NAME
```

Docker List Running Containers Command

```bash
docker ps
```

Docker List all Containers (Stopped and Running) Command

```bash
docker ps -a
```

**Documentation**

- [Docker Run Command](https://docs.docker.com/engine/reference/commandline/run/)
- [Docker List Containers Command](https://docs.docker.com/engine/reference/commandline/ps/)

### Start and Stop Containers

Docker Start Command

```bash
docker start CONTAINER_ID
```

```bash
docker start CONTAINER_NAME
```

Docker Stop Command

```bash
docker stop CONTAINER_ID
```

```bash
docker stop CONTAINER_NAME
```

**Documentation**

- [Docker Start Command](https://docs.docker.com/engine/reference/commandline/start/)
- [Docker Stop Command](https://docs.docker.com/engine/reference/commandline/stop/)

### Remove Containers

Docker Remove Command

```bash
docker rm CONTAINER_ID
```

```bash
docker rm CONTAINER_NAME
```

Docker Force Remove Command

```bash
docker rm -f CONTAINER_ID
```

```bash
docker rm -f CONTAINER_NAME
```

**Documentation**

- [Docker Remove Container Command](https://docs.docker.com/engine/reference/commandline/rm/)

### Run Docker Containers in Interactive Mode

Docker Run Interactive Command

```bash
docker run -it --name CONTAINER_NAME IMAGE_NAME COMMAND
```

**Documentation**

- [Docker Run Interactive Command](https://docs.docker.com/engine/reference/commandline/run/#assign-name-and-allocate-pseudo-tty---name--it)

### Run a Command in a Running Container

Docker Exec Command

```bash
docker exec CONTAINER_NAME COMMAND
```

Docker Exec Interactive Command

```bash
docker exec -it CONTAINER_NAME COMMAND
```

**Documentation**

- [Docker Exec Command](https://docs.docker.com/engine/reference/commandline/exec/)

### Docker Logs

Docker Logs Command

```bash
docker logs CONTAINER_NAME
```

**Documentation**

- [Docker Logs Command](https://docs.docker.com/engine/reference/commandline/logs/)

### Copy Files Between the Host and Container

Docker Copy Command

```bash
docker cp LOCAL_FILE CONTAINER_NAME:CONTAINER_PATH
```

```bash
docker cp CONTAINER_NAME:CONTAINER_PATH LOCAL_FILE
```

**Documentation**

- [Docker Copy Command](https://docs.docker.com/engine/reference/commandline/cp/)

### Create an Image from a Container

Docker Create Container Command

```bash
docker container create --name CONTAINER_NAME IMAGE_NAME
```

Docker Commit Command

```bash
docker commit CONTAINER_NAME IMAGE_NAME
```

**Documentation**

- [Docker Commit Command](https://docs.docker.com/engine/reference/commandline/commit/)

## Persistent Storage

### Docker Volumes

Docker Create Volume Command

```bash
docker volume create VOL_NAME
```

Docker List Volumes Command

```bash
docker volume ls
```

Docker Remove Volume Command

```bash
docker volume rm VOL_NAME
```

Docker Run with Volume Option

```bash
docker run -d --name CONTAINER_NAME -p HOST_PORT:CONTAINER_PORT -v VOL_NAME:CONTAINER_PATH IMAGE_NAME
```

**Documentation**

- [Docker Volume Command](https://docs.docker.com/storage/volumes/)

### Mount the File System into a Container

Docker Run with Volume Option

```bash
docker run -d --name CONTAINER_NAME -p HOST_PORT:CONTAINER_PORT -v HOST_PATH:CONTAINER_PATH IMAGE_NAME
```

**Documentation**

- [Docker Bind Mounts](https://docs.docker.com/storage/bind-mounts/)


## Networks

### Docker Container Ports

Docker Container Port Command

```bash
docker container port CONTAINER_NAME
```

**Documentation**

- [Docker Container Port Command](https://docs.docker.com/engine/reference/commandline/container_port/)

### Networking Containers

Docker Network Inspect Command

```bash
docker network inspect NETWORK_NAME
```

Docker Network Create Command

```bash
docker network create NETWORK_NAME
```

Docker Network Remove Command

```bash
docker network rm NETWORK_NAME
```

Docker Network List Command

```bash
docker network ls
```

Docker Run with Network Option

```bash
docker run -d --name CONTAINER_NAME -p HOST_PORT:CONTAINER_PORT --network NETWORK_NAME IMAGE_NAME
```

**Documentation**

- [Docker Network Inspect Command](https://docs.docker.com/engine/reference/commandline/network_inspect/)
- [Docker Network Create Command](https://docs.docker.com/engine/reference/commandline/network_create/)
- [Docker Network Remove Command](https://docs.docker.com/engine/reference/commandline/network_rm/)
- [Docker Network List Command](https://docs.docker.com/engine/reference/commandline/network_ls/)


## Docker Compose