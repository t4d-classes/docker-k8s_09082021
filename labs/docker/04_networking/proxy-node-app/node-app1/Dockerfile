FROM node

WORKDIR /home/node/app

COPY package.json ./

RUN npm install

COPY index.js ./

CMD ["start"]

ENTRYPOINT ["npm", "run"]

EXPOSE 80