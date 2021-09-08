# base flask app stage
FROM python:3.9 as base
LABEL version=2.0
LABEL maintainer="instructor@t4d.rocks"

RUN pip install pipenv

WORKDIR /usr/src/app

COPY Pipfile ./

RUN pipenv install --deploy --ignore-pipfile

ARG PORT=5050
ENV PORT=$PORT
ENV FLASK_APP=./src/main.py

# flask app dev prod
FROM base as flask-app-prod

LABEL environment=production

ENV FLASK_ENV=production

EXPOSE $PORT

WORKDIR /usr/src/app

COPY src ./src/

CMD ["--host=0.0.0.0","--port=$PORT"]
ENTRYPOINT ["pipenv", "run", "flask", "run"]

# flask app dev stage
FROM base as flask-app-dev

LABEL environment=development

ENV FLASK_ENV=development

EXPOSE $PORT

WORKDIR /usr/src/app

COPY src ./src/

CMD ["--host=0.0.0.0","--port=$PORT"]
ENTRYPOINT ["pipenv", "run", "flask", "run"]
