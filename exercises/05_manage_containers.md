# Exercise #5 - Manage Containers

## Steps

1. Using the Docker `run` command, create three instances of the `ubuntu-nginx-php-demo` image. If you do not have this image, please create it using the steps from the "Manage Docker Containers" lab. Do not worry about mapping the ports, and start the containers detached from the terminal using the `-d` option. The name for each container is listed below.

- demo1
- demo2
- demo3

2. Display a list of the running containers. Are all three containers listed?

3. Stop the `demo2` container. Display a list of the running containers. Is the `demo2` container still listed?

4. Display a list of all containers. Is the `demo2` container listed?

5. Restart the `demo2` container. Verify it's running by getting the list of running containers.

6. Stop the `demo1` container and remove it. Verified it is removed.

7. It's possible to remove multiple containers at the same time by listing multiple container ids or names. Each id (or name) is separated by a space. Force remove both the `demo2` and `demo3` containers with one command.

8. Verify that all containers have been stopped and removed.


### Excellent Job! You have completed the lab exercise!