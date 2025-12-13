const dgram = require("dgram");
const server = dgram.createSocket("udp4");

server.on("message", (msg, rinfo) => {
    console.log(`Message from client: ${msg}`);
    server.send("Message received", rinfo.port, rinfo.address);
});

server.bind(41234, () => {
    console.log("UDP Server is running...");
});