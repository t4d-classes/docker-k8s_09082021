FROM postgres:13.0-alpine

ENV POSTGRES_DB appdb
ENV POSTGRES_USER appuser
ENV POSTGRES_PASSWORD dbpass

COPY cars_colors.sql /docker-entrypoint-initdb.d/cars_colors.sql