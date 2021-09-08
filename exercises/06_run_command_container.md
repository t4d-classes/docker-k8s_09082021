# Exercise #6 - Run Command in a Container

## Steps

1. For this exercise, you will use some prepared files in the `labs/docker/02_containers/interactive-containers`.

2. Run the follow Docker command to build a custom image from a Dockerfile. We have not discussed Dockerfiles yet, so do not worry about the details of it. Just run the command to create the image.

```bash
docker build -t postgresql-interactive-demo .
```

3. Run a new container interactively with the `postgresql-interactive-demo` image.

4. From the command prompt within the container, run the following command.

```bash
ls ./docker-entrypoint-initdb.d
```

5. What file do you see? Review the `Dockerfile`. Was the file in this folder copied as part of the image build?

6. From the command prompt within the container, run the following command.

```bash
more ./docker-entrypoint-initdb.d/cars_colors.sql
```

7. Compare the contents of `./docker-entrypoint-initdb.d/cars_colors.sql` to the file named `cars_colors.sql` in the lab folder. Are they the same?

8. Exit the container, and remove it.

9. Start a new container using the `postgresql-interactive-demo` image. Do not run the container in interactive mode. Verify the container is running using the `ps` command.

10. Log into the terminal of the running container, and run the following command to access the PostgreSQL database.

```bash
psql -U appuser -b appdb
```

11. From the PSQL prompt, run the following command to query the table colors. How many colors are there?

```bash
select * from colors;
```

12. Run the following command to exit the PSQL session.

```bash
exit
```

13. Exit the container, and remove it.



### Excellent Job! You have completed the lab exercise!