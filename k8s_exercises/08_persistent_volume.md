# Exercise #8 - Persistent Volumes

## Steps

1. Create a new namespace named `pgsql`.

2. Create a new YAML file named `pgsql.yml`

3. At the top of the YAML file, create a new persistent volumw claim.

```yaml
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: pgsql-pv-claim
  labels:
    app: pgsql-db
spec:
  accessModes:
    - ReadWriteOnce
  resources:
    requests:
      storage: 1Gi
---
apiVersion: v1
kind: PersistentVolumeClaim
metadata:
  name: pgadmin-pv-claim
  labels:
    app: pgsql-db
spec:
  accessModes:
    - ReadWriteOnce
  resources:
    requests:
      storage: 1Gi
```

4. Create a new deployment with the following configuration.

- Image: postgres:13.3-alpine
- Image Pull Policy: Always
- Container Name: pgsql
- Container Port: 5432

5. Under the `spec` property, below the `containers`, add the following YAML:

```yaml
volumes:
  - name: pgsql
    persistentVolumeClaim:
      claimName: pgsql-pv-claim
```

6. Under the `pgsql` container, add the following YAML:

```yaml
volumeMounts:
  - mountPath: /var/lib/postgresql
    subPath: data
    name: pgsql
```

6. Under the `pgsql` container, add the following YAML:

```yaml
env:
  - name: POSTGRES_HOST_AUTH_METHOD
    value: trust
  - name: PGDATA
    value: /var/lib/postgresql/data/pgdata
```

7. Create a new deployment with the following configuration.

- Image: dpage/pgadmin4:5.6
- Image Pull Policy: Always
- Container Name: pgadmin
- Container Port: 80

5. Under the `spec` property, below the `containera`, add the following YAML:

```yaml
volumes:
  - name: pgadmin
    persistentVolumeClaim:
      claimName: pgadmin-pv-claim
```

6. Under the `pgadmin` container, add the following YAML:

```yaml
volumeMounts:
  - mountPath: /var/lib
    subPath: pgadmin
    name: pgadmin
```

6. Under the `pgsql` container, add the following YAML:

```yaml
env:
  - name: PGADMIN_DEFAULT_EMAIL
    value: dbuser@pgadmin.local
  - name: PGADMIN_DEFAULT_PASSWORD
    value: dbpass
```

7. Create a new Clustered IP service for `pgsql` pod named `postgres`.

8. Create a new Node Port service for the `pgadmin` deployment.

9. Deploy `pgsql.yml` file in the `pgsql` namespace.

10. View the Postgresql database with the web-based admin tool. Use values from the PgAdmin environment variables to log into the web control panel. Right click on `Servers` in the tree, and click `Create Server`. To login specify the database hostname as `postgres` and specify the username as `postgres`. Do not specify a login. You should be able to login.


### Excellent Job! You have completed the lab exercise!