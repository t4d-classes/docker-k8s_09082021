# Exercise #13 - Docker Compose Environment Variables

## Steps

1. For this exercise, you will use some prepared files in the `labs/06_compose/proxy-node-env-app`.

2. Bring up the Docker Compose configuration, but not in detached mode. Review the output to the console.

3. Using the Linux host name and a web browser, navigate to these two URLs.

```bash
http://YOUR_HOST_NAME/www1/

http://YOUR_HOST_NAME/www2/
```

4. When you accessed each URL what loaded up for you? Review the `nginx-proxy/default.conf`. What port number is the "www1" location configured for?

5. Review the `node-app1/index.js` file. What environment variable can be set to configure the port number?

6. Add the `PORT` environment variable to the Docker Compose configuration file. Set the `PORT` value to `5000`.

7. Rebuild the Docker Configuration and bring it up.

8. Using the Linux host name and a web browser, navigate to the "www1" URL.

```bash
http://YOUR_HOST_NAME/www1/
```

9. Does it work?

10. Bring down the Docker Compose configuration.

### Excellent Job! You have completed the lab exercise!