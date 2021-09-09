const http = require('http');

const server = http.createServer((req, res) => {

  res.writeHead(200);
  res.end("version: 2\npath: " + req.url + "\napp name: " + process.env.app_name);

});

server.listen(80, (err) => {

  if (err) {
    console.log(err);
    return;
  }

  console.log("listening on port 80");

});



