let brands = [];

let connection = null;
let brandIdToUpdate = -1;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:38806/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getdata();
    });

    connection.on("BrandDeleted", (user, message) => {
        getdata();
    });
    connection.on("BrandUpdated", (user, message) => {
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

async function getdata()
{
    await fetch('http://localhost:38806/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            //console.log(brands);
            display();
        });
}

function display()
{
    document.getElementById('resultarea').innerHTML = "";
    brands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.brandId + "</td><td>" + t.brandName
            + "</td><td>" +
        `<button type="button" onclick="remove(${t.brandId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.brandId})">Update</button>` 

                + "</td></tr>";
        
    });
}
function showupdate(id)
{
    document.getElementById('brandnametoupdate').value = brands.find(t => t['brandId'] == id)['brandName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    brandIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('brandnametoupdate').value;
    
    fetch('http://localhost:38806/brand', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                brandName: name,
                brandId: brandIdToUpdate

            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);

        });

}
function create()
{
    let name = document.getElementById('brandname').value;
    fetch('http://localhost:38806/brand', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                brandName: name
                
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
            
        });
    
}
function remove(id) {

    fetch('http://localhost:38806/brand/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null  })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);

        });

}