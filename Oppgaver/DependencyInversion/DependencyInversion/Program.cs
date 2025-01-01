using DependencyInversion;
using DependencyInversion.Server;

var server = new ChatServer();

var client1 = new ChatClient("Per",server);
var client2 = new ChatClient("Pål",server);
var client3 = new ChatClient("Espen",server);

client1.Say("Hello");
client2.Say("Hello");
client3.Say("Hello");