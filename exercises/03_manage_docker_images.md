# Exercise #3 - Manage Docker Images

## Steps

1. For this exercise, you will use some prepared files in the `labs/docker/01_images/manage-images`.

2. Run the following Docker command to build a custom image from a Dockerfile. We have not discussed Dockerfiles yet, so do not worry about the details of it. Just run the command to create the image.

```bash
docker build -t ubuntu-nginx-php-demo .
```

3. With the image created, let's run the container and view the output. We will dive deeper into the `run` command later in the course.

```bash
docker run -d -p 80:80 --name demo1 ubuntu-nginx-php-demo
```

4. Using the host name of your Linux virtual machine, view the web site running in the container. Update the `student0` part to your machine.

```bash
http://student0.databots.cloud
```

5. Let's stop the running container.

```bash
docker stop demo1
```

6. And, remove the container.

```bash
docker rm demo1
```

7. List the images. Can you see the image you created? Remember, when explicit commands are omitted please apply the commands learned earlier in the course.

8. Tag the image with your Docker Hub account name and image name.

9. List the images. Can you see the tag you created?

10. List all of the images including the intermediary images. Compare the image ids to the images created when building the image.

11. Modify the `index.php` file in the `www` folder. Replace its contents with the following code.

```php
<?php

echo "hello";

# phpinfo();

?>
```

12. Rebuild the image and start a container using the same `run` command as above. Load the web page in the web browser. Did it change? Now, review the results of the build and the cached images which were used or not used. Any surprises?

13. Stop the container, and remove it.

### Excellent Job! You have completed the lab exercise!