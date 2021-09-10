# Exercise #14 - Rollout

## Steps

1. Change into the `labs/k8s/14_rollout` folder. Build the image with the provided `Dockerfile` and `src` folder. When building the image tag it with `node-app`. Push the `node-app` image to the MicroK8s registry.

2. Use the rollout command to rollout the new instance to the `app1` deployment only. Update the deployment name and the namespace name to reflect your values for node app 1.

```bash
kubectl rollout restart deploy node-app1-deployment -n node-app
```

3. On your local web browser, navigate to `/app1`. Do you see `version: 2` in the web page?

4. On your local web browser, navigate to `/app2`. Do you see `version: 2` in the web page? Should you?

5. Rollout the new image to node app deployment 2 and 3. Verify the deployments were successful.

### Excellent Job! You have completed the lab exercise!