let motos = [];
let connection = null;
getData();
setupSignalR();
let motoIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:34767/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("MotoCreated", (user, message) => {
        getData();
    });

    connection.on("MotoDeleted", (user, message) => {
        getData();
    });

    connection.on("MotoUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}



async function getData() {
    await fetch('http://localhost:34767/moto')
        .then(x => x.json())
        .then(y => {
            motos = y;
            //console.log(motos);
            displayMoto();
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



function displayMoto() {
    document.getElementById('resultarea').innerHTML = "";
    motos.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.motoId + "</td><td>" + t.model + "</td><td>" +
        `<button type="button" onclick="remove(${t.motoId})">Delete</button>` + 
        `<button type="button" onclick="showupdate(${t.motoId})">Update</button>`
            + "</td></tr>";
        //console.log(t.model);
    });
}

function showupdate(id) {
    document.getElementById('motonametoupdate').value = motos.find(t => t['motoId'] == id)['model'];
    document.getElementById('updateformdiv').style.display = 'flex';
    motoIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:34767/moto/' + id, {
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

function create() {
    let name = document.getElementById('motoname').value;
    fetch('http://localhost:34767/moto', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { model: name }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
    //display();
    
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('motonametoupdate').value;
    
    fetch('http://localhost:34767/moto', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { model: name, motoId: motoIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
    //display();

}
let maxsold = [];
function GetMaxSoldCompany() {
    
    fetch('http://localhost:34767/Stat/GetMaxSoldCompany')
        .then(x => x.json())
        .then(y => {
            maxsold = y;
            maxsold.forEach(t => {
                document.getElementById('maxsoldcompany_result_data').innerHTML +=
                    "<tr><td>" + t + "</td></tr>";
            });
            document.getElementById('maxsoldcompany_result').style.display = 'flex';
        });
}
let olderthan = [];
function CompanyOlderThan70() {

    fetch('http://localhost:34767/Stat/GetCompanyOlderThan70')
        .then(x => x.json())
        .then(y => {
            olderthan = y;
            olderthan.forEach(t => {
                document.getElementById('getcompanyolder_result_data').innerHTML +=
                    "<tr><td>" + t + "</td></tr>";
            });
            document.getElementById('getcompanyolder_result').style.display = 'flex';
        });
}