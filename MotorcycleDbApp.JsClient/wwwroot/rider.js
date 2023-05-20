let riders = [];
let connection = null;
getData();
setupSignalR();
let riderIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:34767/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RiderCreated", (user, message) => {
        getData();
    });

    connection.on("RiderDeleted", (user, message) => {
        getData();
    });

    connection.on("RiderUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}



async function getData() {
    await fetch('http://localhost:34767/rider')
        .then(x => x.json())
        .then(y => {
            riders = y;
            //console.log(motos);
            displayRider();
        });
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



function displayRider() {
    document.getElementById('resultarea').innerHTML = "";
    riders.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.riderId + "</td><td>"
        + t.name + "</td><td>" +
        `<button type="button" onclick="removeRider(${t.riderId})">Delete</button>` +
        `<button type="button" onclick="showupdateRider(${t.riderId})">Update</button>`
            + "</td></tr>";
    });
}

function showupdateRider(id) {
    document.getElementById('ridernametoupdate').value = riders.find(t => t['riderId'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    riderIdToUpdate = id;
}

function removeRider(id) {
    fetch('http://localhost:34767/rider/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
}

function createRider() {
    let name = document.getElementById('ridername').value;
    fetch('http://localhost:34767/rider', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
    //display();

}

function updateRider() {
    document.getElementById('updateformdiv').style.display = 'none';
    let namer = document.getElementById('ridernametoupdate').value;

    fetch('http://localhost:34767/rider', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: namer, riderId: riderIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
    //display();

}
let morethan = [];
function HasMoreThan800ccmMoto() {

    fetch('http://localhost:34767/Stat/GetHasMoreThan800ccmMoto')
        .then(x => x.json())
        .then(y => {
            morethan = y;
            morethan.forEach(t => {
                document.getElementById('morethan800_result_data').innerHTML +=
                    "<tr><td>" + t + "</td></tr>";
            });
            document.getElementById('morethan800_result').style.display = 'flex';
        });
}
let aprilia = [];
function HasAprilia() {

    fetch('http://localhost:34767/Stat/HasAprilia')
        .then(x => x.json())
        .then(y => {
            aprilia = y;
            aprilia.forEach(t => {
                document.getElementById('hasaprilia_result_data').innerHTML +=
                    "<tr><td>" + t + "</td></tr>";
            });
            document.getElementById('hasaprilia_result').style.display = 'flex';
        });
}
let etz = [];
function HasETZ() {

    fetch('http://localhost:34767/Stat/HasETZModel')
        .then(x => x.json())
        .then(y => {
            etz = y;
            etz.forEach(t => {
                document.getElementById('hasetz_result_data').innerHTML +=
                    "<tr><td>" + t + "</td></tr>";
            });
            document.getElementById('hasetz_result').style.display = 'flex';
        });
}





