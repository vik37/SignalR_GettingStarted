"use strict"

const signalrConnection = new signalR.HubConnectionBuilder()
                        .withUrl("/messagebroker")
                        .build();

signalrConnection.start().then(function () {
    console.log("SignalR Hub Connection");
}).catch(function (err) {
    return console.error(err.toString());
});

let messageCount = 0; 

signalrConnection.on("onMessageReceived", function (eventMessage) {
    messageCount++;
    const messageCountH4 = document.getElementById("messageCount");
    messageCountH4.innerText = "Messages: " + messageCount.toString();
    const ul = document.getElementById("messages");
    const li = document.createElement("li");
    li.innerText = messageCount.toString();

    for (const property in eventMessage) {
        const newDiv = document.createElement("div");
        const classAttribute = document.createAttribute("style");
        classAttribute.value = "font-size: 80%;";
        newDiv.setAttributeNode(classAttribute);
        const newContent = document.createTextNode(`${property}: ${eventMessage[property]}`);
        newDiv.appendChild(newContent);
        li.appendChild(newDiv);
    }
    ul.appendChild(li);
    window.scrollTo(0, document.body.scrollHeight);
});