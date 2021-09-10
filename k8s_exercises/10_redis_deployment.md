# Exercise #10 - Redis Deployment

## Steps

1. Please review the Docker Compose configuration.

```yaml
services:
  redis:
    image: "redis:6.2.5-alpine"
    ports:
      - "6379:6379"
    volumes:
      - "redisdata:/data"
  redisinsight:
    image: "redislabs/redisinsight:1.10.1"
    ports:
      - "8001:8001"
    volumes:
      - "redisinsightdata:/db"
    links:
      - "redis"
volumes:
  redisdata: {}
  redisinsightdata: {}
```

3. Utilize kubectl to deploy the above configuation with a YAML file. Create the deployment in a namespace named `redis`. The node port for the Redis Insight web application can any random value assigned by the K8s cluster. It does not have to be 8001.

Hint: For this lab do not create everything in one YAML file. Create one YAML file for the persistent volume claims, one for the deployments, and one for the servics. Then apply the files one at a time.

4. Access the Redis Insight web application from your local web browser to view the Redis database installed in the `redis` namespace. You will need to accept some agreements from the publisher of the image. When connecting to the existing Redis database, use the following credentials:

- Host: redis
- Port: 6379
- User: redis

Save the changes, then click the `redis` tile to view the database.

5. Delete the `redis` namespace and all resources in it.

### Excellent Job! You have completed the lab exercise!