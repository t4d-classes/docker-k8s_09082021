# Exercise #12 - Docker Compose Networking

## Steps

1. For this exercise, you will use some prepared files in the `labs/06_compose/proxy-node-app`.

2. Create a Docker Compose YAML file configure for 3 services. There should be a service for the nginx-proxy app, the node-app1, and node-app2. The nginx-proxy should be accessible on the host through port 80.

3. Bring up the Docker Compose file, but not in detached mode. Review the output to the console. Were images built? What kind of networking was configured?

4. Using the Linux host's external IP address and a web browser, navigate to these two URLs.

```bash
http://LINUX_EXTERNAL_IP/www1/

http://LINUX_EXTERNAL_IP/www2/
```

5. When you accessed each URL what loaded up for you?

6. Bring down the Docker Compose configuration.

7. Within the Docker Compose configuration create a new network named my-app. Configure all three services to use the network.

8. Bring up the Docker Compose configuration. Ensure it works. Inspect the network. After inspecting the network bring down the Docker Compose configuration.

9. Update the `default.conf` file in the `nginx-proxy` folder. Replace "www1" with "app1". Rebuild the Docker Compose configuration and bring it up.

10. Using the Linux host name and a web browser, navigate to the "www1" URL.

```bash
http://YOUR_HOST_NAME/www1/
```

11. Does the web page load?

12. Update the Docker Compose configuration to alias "www1" to "app1". Rebuild the Docker Compose configuration, and bring up the Docker Compose configuration. Using the Linux host name and a web browser, navigate to the "www1" URL.

```bash
http://YOUR_HOST_NAME/www1/
```

13. Does the web page load?


### Excellent Job! You have completed the lab exercise!