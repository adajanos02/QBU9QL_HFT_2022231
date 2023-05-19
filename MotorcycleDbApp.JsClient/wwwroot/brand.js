let brands = [];
let connection = null;
getData();
setupSignalR();
let brandIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:34767/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getData();
    });

    connection.on("BrandDeleted", (user, message) => {
        getData();
    });

    connection.on("BrandUpdated", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();

}

async function getData() {
    fetch('http://localhost:34767/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            //console.log(y);
            displayBrand();
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

function displayBrand() {
    document.getElementById('resultarea').innerHTML = "";
    brands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.brandId + "</td><td>" + t.name + "</td><td>" +
            `<button type="button" onclick="removeBrand(${t.brandId})">Delete</button>` +
            `<button type="button" onclick="showupdateBrand(${t.brandId})">Update</button>`
            + "</td></tr>";
        
    });
}
function showupdateBrand(id) {
    document.getElementById('brandnametoupdate').value = brands.find(t => t['brandId'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    brandIdToUpdate = id;
}

function removeBrand(id) {
    fetch('http://localhost:34767/brand/' + id, {
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

function createBrand() {
    let name = document.getElementById('brandname').value;
    fetch('http://localhost:34767/brand', {
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

function updateBrand() {
    document.getElementById('updateformdiv').style.display = 'none';
    let namer = document.getElementById('brandnametoupdate').value;

    fetch('http://localhost:34767/brand', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: namer, brandId: brandIdToUpdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => { console.error('Error:', error); });
    //display();

}