# Exercise #10 - Bind Mount

## Steps

1. Review [Node.js Docker Image Documentation](https://github.com/nodejs/docker-node/blob/master/README.md#how-to-use-this-image).

2. For this exercise, you will use some prepared files in the `labs/03_storage/node-dev`.

3. Create a container which bind mounts the "src" folder.

```bash
docker create -it \
  -v "$(pwd)"/src:/home/node/app \
  -p 80:3000 \
  --name node-demo1 \
  node /bin/bash
```

4. Start the "node-demo1" container. And open a bash session within it.

5. Change into the "/home/node/app" folder.

```bash
cd /home/node/app
```

6. Install NPM packages.

```bash
npm install
```

7. Start the Node.js application.

```bash
npm start
```

8. Open a web browser and navigate to the following URL, replacing the "YOUR_HOST_NAME" with the host name of your Ubuntu Linux server.

```bash
http://YOUR_HOST_NAME
```

9. Verify the "Hello World!" message from the Node.js Express web application appears.

10. Start a second SSH session with the Linux server, and change into the "labs/03_storage/node-dev" folder.

11. Modify the "src/index.js" file. Change the 'Hello World!' string to 'Docker is cool!'.

12. Refresh the web page. Did the content change? For this Node.js Express web application to run, did you have to install Node.js itself on the host? Can Docker containers be used to develop on run-times not installed on the host?

13. Stop and remove the "node-demo1" container.

### Excellent Job! You have completed the lab exercise!