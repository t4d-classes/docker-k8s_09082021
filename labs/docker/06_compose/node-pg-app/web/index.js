const { Client } = require('pg');

const getColors = async () => {

  const client = new Client();
  await client.connect();
  const res = await client.query('SELECT color_name FROM colors');
  
  await client.query('insert into colors (color_name, hexcode) values (\'new color\', \'new hexcode\');');

  await client.end();

  return res.rows;

};

const express = require('express');
const app = express();
const port = process.env.PORT ?? 80;

app.get('/', async (req, res) => {
  res.send(await getColors());
});

app.listen(port, () => {
  console.log(`Node App listening at port ${port}`);
});