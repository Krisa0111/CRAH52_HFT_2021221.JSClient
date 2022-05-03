let clubss = [];
let connection = null;

let clubidtoupdate = -1;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30907/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ClubsCreated", (user, message) => {
        getdata();
    });

    connection.on("ClubsDeleted", (user, message) => {
        getdata();
    });

    connection.on("ClubsUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:30907/clubs')
        .then(x => x.json())
        .then(y => {
            clubss = y;
            console.log(clubss);
            display();
        });
}



function display() {
    document.getElementById('resultarea').innerHTML = "";
    clubss.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>"
            + t.clubID + "</td><td>"
            + t.clubName + "</td><td>"
            + t.capacity + "</td><td>"
            + t.baseTicketPrice + "</td><td>"
            + t.president + "</td><td>"
            + t.shortDesc + "</td><td>"
            + `<button type="button" onclick="remove(${t.clubID})">Delete</button> ` +
                `<button type="button" onclick="showupdate(${t.clubID})">Update</button> ` +"</td></tr>";

    });
}

function showupdate(id) {
    document.getElementById('clubIDToUpdate').value = clubss.find(t => t['clubID'] == id)['clubID'];
    document.getElementById('clubNameToUpdate').value = clubss.find(t => t['clubID'] == id)['clubName'];
    document.getElementById('capacityToUpdate').value = clubss.find(t => t['clubID'] == id)['capacity'];
    document.getElementById('baseTicketPriceToUpdate').value = clubss.find(t => t['clubID'] == id)['baseTicketPrice'];
    document.getElementById('presidentToUpdate').value = clubss.find(t => t['clubID'] == id)['president'];
    document.getElementById('shortDescToUpdate').value = clubss.find(t => t['clubID'] == id)['shortDesc'];
    document.getElementById('updateformdiv').style.display = 'flex';
    clubidtoupdate = id;
}

function remove(id) {
    fetch('http://localhost:30907/clubs/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application.json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Succes', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let id = document.getElementById('clubID').value;
    let name = document.getElementById('clubName').value;
    let capacity = document.getElementById('capacity').value;
    let baseticketprice = document.getElementById('baseTicketPrice').value;
    let president = document.getElementById('president').value;
    let shortdescription = document.getElementById('shortDesc').value;
    fetch('http://localhost:30907/clubs', {
        method: 'POST',
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify({
                clubID: id,
                clubName: name,
                capacity: capacity,
                baseTicketPrice: baseticketprice,
                president: president,
                shortDesc:shortdescription}),})
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {console.error('Error:', error);});
    
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let nameToUpdate = document.getElementById('clubNameToUpdate').value;
    let capacityToUpdate = document.getElementById('capacityToUpdate').value;
    let baseticketpriceToUpdate = document.getElementById('baseTicketPriceToUpdate').value;
    let presidentToUpdate = document.getElementById('presidentToUpdate').value;
    let shortdescriptionToUpdate = document.getElementById('shortDescToUpdate').value;
    fetch('http://localhost:30907/clubs', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            clubID: clubidtoupdate,
            clubName: nameToUpdate,
            capacity: capacityToUpdate,
            baseTicketPrice: baseticketpriceToUpdate,
            president: presidentToUpdate,
            shortDesc: shortdescriptionToUpdate
        }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}