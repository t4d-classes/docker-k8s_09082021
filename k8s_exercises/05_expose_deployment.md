# Exercise #5 - Expose Deployment

## Steps

1. While running pods is great, generally, pods needs to be accessible to the use so that they can utilize the application. While there are several ways to expose a pod, one of the simplest ways it to expose a pod on the port of the node it is running on.

Use the `expose` command to expose the deployment on port 8080 of the node.

```bash
kubectl expose deployment microbot \
  --type=NodePort \
  --port=80 \
  --name=microbot \
  -n microbot
```

2. Get all of the objects for the `microbot` namespace. Do you see a new object? What kind of object is it? What port is on the pod mapped to on the node? Make note of the port number on the node as it will be needed in the next step.


3. From the terminal, use the `curl` command to download the web page from the exposed deployment using the port on the node.

```bash
curl http://localhost:8080
```

Did a web page download?

4. Open a web browser on your local machine. Browse to the following URL, replacing the host name with the host name of your lab machine and the port number with the dynamically allocated port number from earlier.

```bash
http://student0.databots.cloud:30290
```

Did the web page display?

5. Do not delete the deployment, namespace or the new service. They will be needed in the next lab exercise.

### Excellent Job! You have completed the lab exercise!