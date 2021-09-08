const express = require('express');
const app = express();
const port = 80;

app.get('/', (req, res) => {
  res.send('APP 1!');
});

app.listen(port, () => {
  console.log(`App1 listening at port ${port}`);
});