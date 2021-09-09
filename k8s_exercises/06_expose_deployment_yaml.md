# Exercise #6 - Expose Deployment with YAML

## Steps

1. Open the `microbot.yml` file. To add a second object definition, add the following line of text at the end of the file.

```yaml
---
```

2. Add a new service object definition. Please review the K8s documentation here: [https://kubernetes.io/docs/concepts/services-networking/service/#defining-a-service](https://kubernetes.io/docs/concepts/services-networking/service/#defining-a-service)

Similar to other kinds of objects, add the four top-level properties of a service object.

```yaml
apiVersion: v1
kind: Service
metadata:
spec:
```

3. Give the service a `name` of `microbot`.

4. Add the following `spec` definition for service.

```yaml
type: NodePort
selector:
    app: microbot
ports:
  - port: 80
```

5. Apply the deployment using the `apply` command. There is no need to delete the original deployment. Make sure you deploy to the `microbot2` namespace.

6. Get all of the objects from the `microbot2` namespace. Then, get all of the objects from the `microbot` namespace. Compare them. The same deployment was created from the command-line and the YAML file.

7. Verify the web page loads for the pod and service for the `microbot2` namespace.

8. Delete all objects in the `microbot` and `microbot2` namespaces.

### Excellent Job! You have completed the lab exercise!