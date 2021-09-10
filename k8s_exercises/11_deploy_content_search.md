# Exercise #11 - Deploy Content Search

## Steps

1. Please review the following Docker Compose YAML file.

```yaml
version: "3.8"
services:
  webserver:
    build:
      context: .
      dockerfile: TrainingContentSearchWebServerDockerfile
    ports:
      - "5080:80"
    environment:
      ASPNETCORE_ENVIRONMENT: Production
      TrainingContentCatalog_ConnectionStrings__TrainingCatalogDbServer: mongodb://root:dbpass@mongo:27017
      TrainingContentCatalog_ConnectionStrings__TrainingCatalogCacheServer: redis:6379
    links:
      - "mongo"
      - "redis"
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
  mongodata: {}
  redisdata: {}
  redisinsightdata: {}
```

2. From your terminal, change into the `labs/k8s/11_deploy_content_search/content-search/src`.

3. Build the Docker image with the `TrainingContentSearchWebServerDockerfile` and tag it with `content-search-web`. To use a non-standard Dockerfile, consider using the `--file` option when building.

4. Tag the image for pushing the image to the K8s registry.

```bash
docker tag content-search-web localhost:32000/content-search-web
```

5. Push the image to the MicroK8s registry.

```bash
docker push localhost:32000/content-search-web
```

6. Create three YAML configuration files: persistent volume claims, deployments, and services. Apply them in the order listed.

7. The web app has two parts. Update the URLs for your web deployment Node Port value.

- Search: [http://t4dprep0.databots.cloud:31720](http://t4dprep0.databots.cloud:31720)
- Admin Tool: [http://t4dprep0.databots.cloud:31720/admin/content-tool](http://t4dprep0.databots.cloud:31720/admin/content-tool)

Add some entries to the search engine, then search for them. Please enter reasonable values. If you run into problems entering values, do not worry we will demo in class at the end of the lab exercise.


### Excellent Job! You have completed the lab exercise!