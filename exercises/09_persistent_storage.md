# Exercise #9 - Persistent Storage

## Lab Summary

- Create a PostgreSQL container.
- Use psql to create some data.
- Exit the container, then log back in. Use psql to view the previously created data.
- Stop the container, then start the container again.
- Log back into the container. Use psql to view the previously created data.
- Remove and re-create the container. Use psql look for the previously created data.
- Create a new PostgreSQL container with a Docker volume.
- Using psql, create some data.
- Remove and re-create the container to see the data is still there.
- Clean up all containers.

## Steps

1. Create a new PostgreSQL container. The image name is "postgres". As part of creating the container, pass the following options.

- `--name pg1`
- `-e POSTGRES_PASSWORD=testpass`

The `-e` option specifies an environment variable. The PostgreSQL image requires the "POSTGRES_PASSWORD" environment variable to be set.

2. Start the "pg1" container and open a bash terminal session in the container.

  Hint: Do not start the container in interactive mode. Rather, start the container with one command, then start the bash terminal session with another command after the container is running.

3. Log into the PostgreSQL server with the psql command-line tool.

```bash
psql -U postgres -d postgres
```

4. Run the following SQL commands.

```bash
create table colors (name varchar);

insert into colors (name) values ('red');

select * from colors;
```

The select command should return one row, the color red.

5. Exit the psql session.

```bash
\q
```

6. Exit the "pg1" container.

7. Open a new bash session in the "pg1" container. Log into PostgreSQL with psql, and select the colors. Are they still there?

8. Exit the "pg1" container. Stop the container, and start it again.

9. Open a new bash session in the "pg1" container. Log into PostgreSQL with psql, and select the colors. Are they still there?

10. Exit the "pg1" container. Stop the container, and remove it.

11. Create a new PostgreSQL container. The image name is "postgres". As part of creating the container, pass the following options.

- `--name pg1`
- `-e POSTGRES_PASSWORD=testpass`

12. Start the "pg1" container. Open a new bash session in the "pg1" container. Log into PostgreSQL with psql, and select the colors. Are they still there? What happened to them?

13. Create a new Docker volume named "pg-vol".

14. Create a new PostgreSQL container. The image name is "postgres". As part of creating the container, pass the following options.

- `--name pg1`
- `-e POSTGRES_PASSWORD=testpass`
- `-e PGDATA=/var/lib/postgresql/data/pgdata`
- `-v pg-vol:/var/lib/postgresql/data/pgdata`

15. Start the "pg1" container and open a bash terminal session in the container.

16. Log into the PostgreSQL server with the psql command-line tool.

```bash
psql -U postgres -d postgres
```

17. Run the following SQL commands.

```bash
create table colors (name varchar);

insert into colors (name) values ('red');

select * from colors;
```

18. The select command should return one row, the color red.

19. Exit the psql session.

```bash
\q
```

20. Exit the "pg1" container.

21. Stop and remove the "pg1" container. Re-create the container. Open a new bash session and log into PostgreSQL with psql. Verify the colors are still there.

22. Remove the Docker volume and containers created in this lab exercise.

### Excellent Job! You have completed the lab exercise!