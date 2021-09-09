# Exercise #2 - K8s Namespaces

## Steps

1. Namespaces enable the logical organization of K8s objects. List the namespaces in your MicroK8s cluster.

```bash
kubectl get namespaces
```

2. Create a new namespace named `microbot`.

```bash
kubectl create namespace microbot
```

3. List the namespaces in the cluster. Is the `microbot` namespace listed? How old is it?

```bash
kubectl get namespaces
```

4. Remove the `microbot` namespace.

```bash
kubectl delete namespace microbot
```

5. List the namespaces to confirm that is has been deleted.

### Excellent Job! You have completed the lab exercise!