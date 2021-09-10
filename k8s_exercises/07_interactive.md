# Exercise #7 - Interactive

## Steps

1. Create a new namespace for this exercise. Use this namespace for all deployments.

2. Using the CLI, please deploy an `nginx` container. Expose the deployment using a NodePort mapped back to port 80 on the pod.

Hint: Check out [Docker Hub](https://hub.docker.com) to learn more about the `nginx` image.

3. View the web page with curl or your local web browser.

4. What is the name of the `nginx` pod? Use the following command to get the pod name. Note the pod name, it will be used in the next step.

```bash
kubectl get pods -n interactive
```

5. Access the `nginx` pod interactively and bring up a bash shell.

```bash
kubectl exec --stdin --tty -n interactive <POD_NAME> -- /bin/bash
```

6. Review the content of the `index.html` file. 

```bash
cat /usr/share/nginx/html/index.html
```

7. Get the Cluster IP for the NodePort service for the Nginx pod. Note the Cluster IP as it will be needed in a future step.

8. Using the CLI, please run the `ubuntu` container with a name of `terminal`.

```bash
kubectl run -i --tty -n interactive --image ubuntu terminal -- /bin/bash
```

9. Install the `curl` package on the `terminal` pod.

```bash
apt update

apt upgrade

apt install curl
```

10. Using `curl` on the `terminal` pod, download the nginx web page using the Cluster IP and port 80.

11. Exit the `terminal` pod and delete it. Delete the pod only.

12. Create a new namespace named `interactive2`. Run a new `terminal` pod in the `interactive2` namespace with the Ubuntu image. Install `curl` and attempt to download the web page from the `nginx` pod in the `interactive` namespace. Did it work?

### Excellent Job! You have completed the lab exercise!