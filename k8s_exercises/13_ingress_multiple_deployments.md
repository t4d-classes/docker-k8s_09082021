# Exercise #13 - Ingress Multiple Deployments

## Steps

1. Change into the `labs/k8s/13_ingress_multiple_deployments` folder. Build the image with the provided `Dockerfile` and `src` folder. When building the image tag it with `node-app`. Push the `node-app` image to the MicroK8s registry.

2. Using the following YAML examples as a guide deploy three instances of the `node-app` image with following specs:

**Node App Deployment 1**
- URL: http://student0.databots.cloud/app1
- Environment Variable: app_name=app1

**Node App Deployment 2**
- URL: http://student0.databots.cloud/app2
- Environment Variable: app_name=app2

**Node App Deployment 3**
- URL: http://student0.databots.cloud/app3
- Environment Variable: app_name=app3

Deploying this application should not break the content search which should still be accessible at: http://student0.databots.cloud/.

**YAML Examples:**

Here is a sample deployment YAML for the first node app. You will need additional deployment configurations for the second and third node app.

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: node-app1-deployment
  labels:
    app: node-app1
spec:
  selector:
    matchLabels:
      pod: node-app1-pod
  template:
    metadata:
      labels:
        app: node-app1
        pod: node-app1-pod
    spec:
      containers:
        - name: node-app
          image: localhost:32000/node-app
          imagePullPolicy: Always
          ports:
            - containerPort: 80
          env:
            - name: app_name
              value: app1
```

Here is a sample service YAML for the first node app. You will need additional service configurations for the second and third node app.

```yaml
apiVersion: v1
kind: Service
metadata:
  name: node-app1-http
  labels:
    app: node-app1
spec:
  ports:
    - port: 80
  selector:
    pod: node-app1-pod
```

Here is a sample ingress YAML for the node apps. You will need to add additional host rules for this ingress configuration to support all three node app deployments.

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: node-app-ingress
  annotations:
    kubernetes.io/ingress.class: public
  labels:
    app: node-app
spec:
  rules:
  - host: t4dprep0.databots.cloud
    http:
      paths:
      - path: /app1
        pathType: Prefix
        backend:
          service:
            name: node-app1-http
            port:
              number: 80
```

3. Apply all of the YAML files to the K8s cluster.

4. Attempt to access all three nodes apps through your web browser. Also, ensure the content search app continues to load as well.

### Excellent Job! You have completed the lab exercise!