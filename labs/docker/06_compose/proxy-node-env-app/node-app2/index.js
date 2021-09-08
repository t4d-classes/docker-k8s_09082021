const express = require('express');
const app = express();
const port = 80;

app.get('/', (req, res) => {
  res.send('APP 2!');
});

app.listen(port, () => {
  console.log(`App2 listening at port ${port}`);
});