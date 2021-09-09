# Training Content Search

A project for searching a training content database.

## Manage Database Services

To start the databases, Docker must be running.

Here is the command to start the databases:

```bash
pwsh -Command ./db-services.ps1 start
```

Here is the command to start the databases:

```bash
pwsh -Command ./db-services.ps1 stop
```

## To Access Mongo Shell

Start a Bash Shell session on the MongoDB container:

```bash
docker exec -it training-content-search-mongodb_mongo_1 /bin/bash
```

Connect to the MongoDB with the Mongo Shell:

```bash
mongosh --port 27017 -u root --authenticationDatabase 'admin'
```
