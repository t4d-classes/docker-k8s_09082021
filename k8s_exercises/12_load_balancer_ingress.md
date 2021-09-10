# Exercise #12 - Load Balancer and Ingress

## Steps

1. Create a new folder, and copy the YAML files from the previous content search lab exercise into the new folder.

2. Run the following command to ensure the MicroK8s addons `metallb` and `ingress` are enabled.

```bash
microk8s status
```

These addons should be listed under enabled.

3. Create a new YAML file named `service-ingress.yml`. Add the following configuration to it.

```yaml
apiVersion: v1
kind: Service
metadata:
  name: ingress
  namespace: ingress
spec:
  selector:
    name: nginx-ingress-microk8s
  type: LoadBalancer
  ports:
    - name: http
      protocol: TCP
      port: 80
      targetPort: 80
```

4. Apply the `service-ingress.yml` to the K8s cluster. When applying, do not specify a namespace from the command line.

5. What is the name of the pod executing within the `ingress` namespace?

```bash
kubectl get pod -n ingress
```

6. Use the `describe` command to the view the ingress pod found in the previous set. Search the output for `ingress-class`. What is the class? This class will be used to connect Ingress resources to the MicroK8s Ingress service.

7. Review the files in the `labs/k8s/12_load_balancer_ingress` folder. These are the three service files from the previous lab. Please observe there are three files: `pvc`, `deployment`, and `service`. These files should be similar to your previous lab files but will mostly likely not be the exact same.

8. We need to upgrade the service file to use an ingress instead of a node port to make the content search web app available on port 80 on the host name/public ip. In the `content-search-service.yml` file there is a service named `web`. The `web` service is a node port service for the content search web deployment. Identify the equivalent service in your configuration.

9. From your version of the `web` service, remove the `spec.type` property from the configuration file. This will cause the service to default to being a Clustered IP service only.

9. Add the following Ingress resource definition to the end of your `service` file.

```yaml
apiVersion: networking.k8s.io/v1
kind: Ingress
metadata:
  name: web-ingress
  annotations:
    kubernetes.io/ingress.class: public
  labels:
    app: content-search-app
spec:
  rules:
  - host: t4dprep0.databots.cloud
    http:
      paths:
      - path: /
        pathType: Prefix
        backend:
          service:
            name: web
            port:
              number: 80
```

Update the `rules[].host` to the host name of your lab machine. Update the `backend.service.name` to be the name of your service for the content search web deployment. Confirm that the value of the `kubernetes.io/ingress.class` annotation matches the class name you found earlier.

10. Apply your `service` YAML file, be sure to include the namespace you used for the content search application in the command.

11. Attempt to load the web site with your host name on your local computer's web browser.

```bash
http://student0.databots.cloud
```

12. If it loads, then great! If not, check the service table to make sure the ingress load balancer has an ip address. Also, check the logs of the various ingress and content search pods.

### Excellent Job! You have completed the lab exercise!