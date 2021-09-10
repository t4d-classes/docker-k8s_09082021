# Exercise #14 - Docker Compose Data 

## Steps

1. For this exercise, you will use some prepared files in the `labs/06_compose/node-pg-app`.

2. Bring up the Docker Compose configuration, but not in detached mode. Observe what is created when the PostgreSQL container is created.

3. From the terminal window, type `CTRL-C`. Are the containers stopped only or stopped and removed? Now, bring down the Docker Compose configuration. Are the containers stopped only or stopped and removed?

4. Bring up the Docker Compose configuration, but not in detached mode. Observe what is created when the PostgreSQL container is created. What the database re-created?

5. Each time the Docker Compose configuration is brought down, the database is lost because it is stored on the PostgreSQL container itself. Update the Docker Compose configuration to store the database on a Docker volume. The database is stored on the following path within the container:

```bash
/var/lib/postgresql/data
```

6. Repeat the process of bringing the Docker Compose configuration back up, then down, then back up again. Was the database recreated? Why or why not?

### Excellent Job! You have completed the lab exercise!