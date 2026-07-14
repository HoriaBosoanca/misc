// Globals & Startup

let messagebox
let inputfield

document.addEventListener("DOMContentLoaded", function() {
    messagebox = document.getElementById("messagebox")
    inputfield = document.getElementById("inputfield")
    fetchAllMessages()
});

// Create Message When Pressing Enter

async function keydown(e){
    if(e.key == "Enter"){
        const input = inputfield.value
        const responseId = await addMessageToDatabase(input)
        loadMessage(responseId, input)
        inputfield.value = "" // clear input box
    }
}

// Methods

function fetchAllMessages(){
    fetch("messages_api/message", {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(data => {
        if(!data.ok){
            throw new Error("Response isn't ok.")
        }
        return data.json()
    })
    .then(data => {
        data.forEach(message => {
            loadMessage(message.id, message.text)
        });
    })
    .catch(error => console.log(error))
}

function loadMessage(id, input){
    const newParagraph = document.createElement("p")
    newParagraph.innerText = "ID-" + id.toString() + ": " + input
    newParagraph.classList.add("message") // add css

    const newDiv = document.createElement("div")
    newDiv.appendChild(newParagraph)
    newDiv.classList.add("message-div")

    messagebox.appendChild(newDiv)
    messagebox.scrollTop = messagebox.scrollHeight // scroll down
}

async function addMessageToDatabase(content){ // returns the id of the newly added message
    try{
        const response = await fetch("messages_api/message", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                text: content
            })
        })

        if(!response.ok){
            throw new Error("Response isn't ok.")
        }

        const data = await response.json();
        return data.id
    }
    catch(error){
        console.log(error)
    }
}
