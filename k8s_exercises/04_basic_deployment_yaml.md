# Exercise #4 - Basic Deployment with YAML 

## Steps

1. Using the command line to create deployments is great for ad hoc deployments. But for real applications specifying the deployment with a YAML file works better.

Feel free to use this resource to help you with the lab: [https://kubernetes.io/docs/concepts/workloads/controllers/deployment/](https://kubernetes.io/docs/concepts/workloads/controllers/deployment/)

Create a new file named: `microbot.yml`

2. There are sections to the YAML file: API, Kind, Metadata, and Spec. Add the following YAML to the file.

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
spec:
```

3. Under the `metadata` property, add a `name` property with the value: microbot

```yaml
metadata:
  name: microbot
```

  Compare the `metadata.name` to the command-line command `kubectl create deployment microbot`. See how the name from the command-line is the name of deployment in the YAML file?

4. Under the `specs` property, add the following YAML. For now, ignore the labels, selectors, and replicas.

```yaml
spec:
  replicas: 1
  selector:
    matchLabels:
      app: microbot
  template:
    metadata:
      labels:
        app: microbot
    spec:
      containers:
      - name: microbot
        image: dontrebootme/microbot:v1
```

5. Using the kubectl `apply` command, deploy the YAML configuration to the `microbot2` namespace. Please create the namespace before performing the deployment.

```bash
kubectl apply -f ./microbot.yml -n microbot2
```

6. Get all of the objects from the `microbot2` namespace. Then, get all of the objects from the `microbot` namespace. Compare them. The same deployment was created from the command-line and the YAML file.

7. Do not delete the deployments or namespaces. They will be used in the next exercise.

### Excellent Job! You have completed the lab exercise!