# Exercise #3 - Basic Deployment with Namespaces

## Steps

1. Open a terminal window, and run the following command.

```bash
kubectl create deployment microbot \
  --image=dontrebootme/microbot:v1
```

2. Get all of the namespaces and look for "default pod/microbot-".

```bash
kubectl get all --all-namespaces
```

3. Delete the deployment, and confirm the deletion by getting all objects for all namespaces.

```bash
kubectl delete deployment microbot
```

4. What namespace is the pod in? Should we deploy applications to the default namespace? Create a new namespace named `microbot`.

5. Deploy microbot deployment again, but this time add a namespace.

```bash
kubectl create deployment microbot \
  --image=dontrebootme/microbot:v1
  -n microbot
```

6. Get all objects for all namespaces. Which namespace is the microbot in?

7. Get all object for only the microbot namespace. Does the deployment, replica set, and the pod appear?

```bash
kubectl get all -n microbot
```

8. Do not delete the deployment and the namespace. They will be needed in the next exercise.

### Excellent Job! You have completed the lab exercise!