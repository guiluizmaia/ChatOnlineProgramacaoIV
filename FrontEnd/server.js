const express = require('express');

const app = express();

const http = require('http').createServer(app);

const io = require('socket.io')(http);

app.use(express.static(__dirname + '/src'));

app.get('/', (req, res) =>{
    res.sendFile(__dirname+'/src/index.html');
})

app.get('/search', (req, res) =>{
    res.sendFile(__dirname+'/src/search.html');
})

http.listen(3000, () =>{
    console.log('Server is running');
})

io.on('connection', (socket) => {
    console.log('New connection', socket.id);
    socket.on('new', (response) => {
        socket.broadcast.emit('add', response);
    })
})

