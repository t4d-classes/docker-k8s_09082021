# Exercise #11 - Proxy Web Servers

## Steps

1. For this exercise, you will use some prepared files in the `labs/04_networking/proxy-node-app`.

2. Build the Docker images in the `nginx-proxy`, `node-app1`, and `node-app2` folders.

3. Create a new network named `my-app`.

4. Start both of the node-app images. Assign them the `my-app` network. The name for the first node-app container should be set to `www1`. The name for the second node-app container should be set to `www2`. 

5. Start the nginx-proxy image. Assign it to the `my-app` network and bind its port 80 to port 80 on the Linux host.

6. Using the Linux host's external IP address and a web browser, navigate to these two URLs.

```bash
http://LINUX_EXTERNAL_IP/www1/

http://LINUX_EXTERNAL_IP/www2/
```

7. When you accessed each URL what loaded up for you?

8. Review the `nginx-proxy/default.conf` file. Compare the reverse proxy host names to the container names. Do you see a relationship?

9. Wire up a third node-app container on `http://LINUX_EXTERNAL_IP/www3/`. Employ the various techniques you have learned in class to accomplish this.

10. Remove the containers and network created in this lab exercise.

### Excellent Job! You have completed the lab exercise!