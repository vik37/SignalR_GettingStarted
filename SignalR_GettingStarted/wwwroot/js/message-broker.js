"use strict"

const signalrConnection = new signalR.HubConnectionBuilder()
                        .withUrl("/messagebroker")
                        .build();

signalrConnection.start().then(function () {
    console.log("SignalR Hub Connection");
}).catch(function (err) {
    return console.error(err.toString());
});