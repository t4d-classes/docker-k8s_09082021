# Exercise #1 - Explore MicroK8s

## Steps

1. To run MicroK8s commands utilize the `microk8s` CLI. Run the following command:

```bash
microk8s
```

2. To stop MicroK8s, run the following command. Be patient, it can take moment or two to stop.

```bash
microk8s stop
```

3. To start MicroK8s, run the following command. Be patient, it can take moment or two to start.

```bash
microk8s start
```

4. Another useful command to verify the configuration of MicroK8s is the inspect command. Run the following command to inspect MicroK8s cluster.

```bash
microk8s inspect
```

5. To see the current status of MicroK8s, including the enabled addons, run the following command:

```bash
microk8s status
```

6. While the MicroK8s CLI is great for inspecting the MicroK8s cluster, generally, you will not be using MicroK8s. Instead you will be using a tool named `kubectl` to access the K8s cluster. To connect to the cluster you will be to add the content of the K8s cluster to your `~/.kube/config` file

To view the context of the MicroK8s cluster, run the following command:

```bash
microk8s config
```

7. This configuration was added to your `~/.kube/config` as part of the lab machine provisioning. Run the following command to replace the configuration.

```bash
microk8s config > ~/.kube/config
```

8. Run the following command to list the available contexts.

```bash
kubectl config get-contexts
```

9. While we only have one context, to select a context from among many, the `use-content` subcommand is used. Select the MicroK8s context now.

```bash
kubectl config use-context microk8s
```

10. Vie the current context with the following command:

```bash
kubectl config current-context
```

11. Confirm you can view the objects in the K8s cluster:

```bash
kubectl get all --all-namespaces
```

### Excellent Job! You have completed the lab exercise!