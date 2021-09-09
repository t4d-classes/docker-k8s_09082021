# Exercise #8 - Create Image from Container

## Steps

1. For this exercise, you will use some prepared files in the `labs/02_containers/build-image`.

2. Create a new container with the following configuration.

- Interaction and PseudoTTY
- Ubuntu Image

3. Copy the `build.sh` file to the `/opt` folder in the container.

4. Log into the container, then run the following command.

```bash
/bin/bash /opt/build.sh
```

5. When the command completes, exit the container.

6. Copy the following files to the container.

- Contents of the local `www` to the container's `/var/www/html`.
- The local `default` file to the container's `/etc/nginx/sites-available` folder.
- The local `start.sh` file to the container's `/opt` folder.

7. Commit the current container to an image.

8. Using the new image, run a new container with the `-d` option, the `-p 80:80` option, and the command `/bin/bash /opt/start.sh`.

9. Open a web browser and navigate to the following URL, replacing the "YOUR_LINUX_IP_ADDRESS" with the IP address of your Ubuntu Linux server.

```bash
http://YOUR_LINUX_IP_ADDRESS
```

10. Verify the PHP Info page appears.

11. Clean up the containers and image which were created.



### Excellent Job! You have completed the lab exercise!