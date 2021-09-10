# Exercise #10 - Mongo Deployment

## Steps

1. Please review the Docker Compose configuration.

```yaml
services:
  mongo:
    image: "mongo:5.0.2"
    ports:
      - "27017:27017"
    volumes:
      - "mongodata:/data/db"
    environment:
      MONGO_INITDB_ROOT_USERNAME: root
      MONGO_INITDB_ROOT_PASSWORD: dbpass
  mongo-express:
    image: "mongo-express:0.54.0"
    ports:
      - "8081:8081"
    environment:
      ME_CONFIG_MONGODB_ADMINUSERNAME: root
      ME_CONFIG_MONGODB_ADMINPASSWORD: dbpass
      ME_CONFIG_MONGODB_URL: mongodb://root:dbpass@mongo:27017/
    links:
      - "mongo"
volumes:
  mongodata: {}
```

2. Utilize kubectl to deploy the above configuation with a YAML file. Create the deployment in a namespace named `mongo`. The node port for the Mongo Express web application can any random value assigned by the K8s cluster. It does not have to be 8081.

3. Access the Mongo Express web application from your local web browser to view the Mongo database installed in the `mongo` namespace. There is no login and database is already connected to.

4. Delete the `mongo` namespace and all resources in the namespace.

### Excellent Job! You have completed the lab exercise!