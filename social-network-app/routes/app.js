var url = require('url');
var fs = require('fs');

function renderHTML(path, response) {
    response.writeHead(200, {'Content-Type': 'text/html'});
    fs.readFile(path, null, function(error, data){
        if(error) {
            response.writeHead(404);
            response.write('File not found');
        }else{
            response.write(data);
        }
        response.end();
    });

}

module.exports = {
  handleRequest: function (request, response) {
      response.writeHead(200, {'Content-Type': 'text/html'});

        var path = url.parse(request.url).pathname;
        switch (path){
            case '/':
                renderHTML('../views/index.html', response);
                break;
            case '/login':
                renderHTML('../views/login.html', response);
                break;
            case '/about':
                renderHTML('../views/about.html', response);
            default:
                response.writeHead(404);
                response.write('Route not defined');
                response.end();
                break;
        }
  }
};

