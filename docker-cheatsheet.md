# Docker Cheat Sheet

## Images

### Download Docker Images

Download a Docker Image

```bash 
docker pull IMAGE_ID
```

 Download a tagged Docker Image

```bash
docker pull IMAGE_ID:TAG_NAME
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
docker image rm IMAGE_ID
```

Shorthand to Remove a Docker Image

```bash
docker rmi IMAGE_ID
```

**Documentation**

- [Docker Image List Command](https://docs.docker.com/engine/reference/commandline/image_ls/)
- [Docker Image List Command Options](https://github.com/moby/moby/blob/10c0af083544460a2ddc2218f37dc24a077f7d90/docs/reference/commandline/images.md)
- [Docker Remove Image Command](https://docs.docker.com/engine/reference/commandline/rmi/)

## Containers

## Volumes

## Networks