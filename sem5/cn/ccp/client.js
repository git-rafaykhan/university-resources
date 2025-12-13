const dgram = require("dgram");
const client = dgram.createSocket("udp4");

const message = Buffer.from("Hello from UDP Client");
client.send(message, 41234, "localhost", () => {
    console.log("Message sent");
});

client.on("message", (msg) => {
    console.log(`Response from server: ${msg}`);
    client.close();
});