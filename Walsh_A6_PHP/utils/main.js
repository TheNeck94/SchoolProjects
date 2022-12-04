window.onload  = function(){
    console.log("Window onLoad: ");
    document.querySelector("#getData").addEventListener("click", getData);
    document.querySelector("#addCarDoneBtn").addEventListener("click", addCar);
    document.querySelector("#deleteCar").addEventListener("click", deleteItem);
    document.querySelector("#updateCar").addEventListener("click", updateItem);
    document.querySelector("table").addEventListener("click", handleRowClick);
};

async function getData(){           //Code Resource: https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream
    let url = '../api/getAllItems.php';
    let resp = await fetch(url)
                .then((response) => response.body)
                .then((rb) =>{
                    const reader = rb.getReader();
                    return new ReadableStream({
                        start(controller){
                            function push() {
                              reader.read().then(({ done, value }) => {
                                if (done) {
                                  controller.close();
                                  return;
                                }
                                controller.enqueue(value);
                                push();
                              });
                            }
                            push();
                        }});})
        .then((stream) =>
        new Response(stream, { headers: { 'Content-Type': 'text/html' } }).text()
      )
  .then((result) => {
    buildTable(result);
  });   
}
async function getCurrentIDs(){
   let url = '../api/getObjectIds.php';
   let idArr = [];
   let resp = await fetch(url)
                .then((response) => response.body)
                .then((rb) =>{
                    const reader = rb.getReader();
                    return new ReadableStream({
                        start(controller){
                            function push() {
                              reader.read().then(({ done, value }) => {
                                if (done) {
                                  controller.close();
                                  return;
                                }
                                controller.enqueue(value);
                                push();
                              });
                            }
                            push();
                        }});})
        .then((stream) =>
        new Response(stream, { headers: { 'Content-Type': 'text/html' } }).text()
      )
  .then((result) => {
    idArr = result;
  });
  return idArr;
  
}
async function buildTable(dbResp){
    console.log("Build Table Called: ");
    let currentIDs = await getCurrentIDs();
    let IDs = JSON.parse(currentIDs);
    document.querySelector("#deleteCar").setAttribute("disabled", "disabled");
    document.querySelector("#updateCar").setAttribute("disabled", "disabled");
    let table = document.getElementById("tableBody");
    table.innerHTML = "";
    let cars = JSON.parse(dbResp);
    let outputHTML = "";
    for(i =0; i<cars.length; i++){
    outputHTML +=   "<tr>" +
                    "<td>" + IDs[i]  + "</td>" +
                    "<td>" + cars[i].year   + "</td>" +
                    "<td>" + cars[i].make   + "</td>" +
                    "<td>" + cars[i].model  + "</td>" +
                    "<td>" + cars[i].colour + "</td>" +
                    "</tr>";
    }
    table.innerHTML = outputHTML;
}

async function resetID(){
    let currentIDs = [];
    currentIDs = await getCurrentIDs();
    let count = JSON.parse(currentIDs).length;
    console.log("Reset ID Called: ");
    console.log("Count: ",count," currentIDs: ",currentIDs);
    let url = "../api/resetIDCounter.php";
    let payload = {
      newIndex: count  
    };
    let resp = fetch(url, {
        method: 'POST',
        body: JSON.stringify(payload)
    }).then((response) => response.text()).then((text) => console.log("Reset ID Response: ",text));
}

async function addCar(){
    event.preventDefault();
    console.log("addCar Called: ");
    let url = '../api/insertItem.php';
    let div = document.getElementById("addCarFormDiv");
    let year = document.getElementById("Year").value;
    let make = document.getElementById("Make").value;
    let model = document.getElementById("Model").value;
    let colour = document.getElementById("Colour").value;
    let numOfIDs = await getCurrentIDs();
    console.log(numOfIDs);
    let obj = {
        Year:   year,
        Make:   make,
        Model:  model,
        Colour: colour
    };
    let resp = await fetch(url, {
        method: 'POST',
        body:   JSON.stringify(obj)
    }).then((response) => response.json())
            .then((responseData) => {
                console.log(responseData);
                div.classList = "collapse hide";
                return responseData;
            });
    getData();
}

async function deleteItem(){
    console.log("Delete Button Clicked: ");
    
    let objectToBeDeleted = findHighlight();
    let idToBeDeleted = {ID: parseInt(objectToBeDeleted.ID)};
    let url = "../api/deleteItem.php";
    let payload = JSON.stringify(idToBeDeleted);
    console.log("Object to be deleted: ", payload);
    
    let resp = await fetch(url,{method: 'POST', body: payload})
               .catch(err => {console.log(err.response.data);});
    let content = await resp.text();
    let check = await console.log(content);
    if (resp.status === 200){
        console.log("Response: " + content);
        resetID();
        getData();
    }else{
        console.log(resp.status);
        console.log(resp.statusText);
        alert(resp.statusText);
    }
}



function handleRowClick(e) {
    console.log("Row Clicked");
    //add style to parent of clicked cell
    clearSelections();
    e.target.parentElement.classList.add("highlighted");
    
    // enable Delete and Update buttons
    document.querySelector("#deleteCar").removeAttribute("disabled");
    document.querySelector("#updateCar").removeAttribute("disabled");
}

function clearSelections() {
    let trs = document.querySelectorAll("tr");
    for (let i = 0; i < trs.length; i++) {
        trs[i].classList.remove("highlighted");
    }
}

async function updateItem(){
    let currIDs = await getCurrentIDs();
    let selectedCar = findHighlight();
    if(currIDs.includes(selectedCar.ID) === false){
        alert("Error: ID sent not Valid", selectedCar.ID);
    }else{
        document.getElementById("addCarFormDiv").classList = "collapse show";
        document.querySelector("#addCarDoneBtn").removeEventListener("click", addCar);
        document.querySelector("#addCarDoneBtn").addEventListener("click", submitUpdate);
        document.getElementById("Year").value = selectedCar.Year;
        document.getElementById("Make").value = selectedCar.Make;
        document.getElementById("Model").value = selectedCar.Model;
        document.getElementById("Colour").value = selectedCar.Colour;
    } 
}

async function submitUpdate(){
    event.preventDefault();
    let url = '../api/updateItem.php';
    let selectedCar = findHighlight();
    let div = document.getElementById("addCarFormDiv");
    let year = document.getElementById("Year").value;
    let make = document.getElementById("Make").value;
    let model = document.getElementById("Model").value;
    let colour = document.getElementById("Colour").value;
    let ID = {ID: selectedCar.ID};
    let obj = {
        Year:   year,
        Make:   make,
        Model:  model,
        Colour: colour
    };
    let payload = {
        ID: ID,
        Data: obj
    };
    let resp = await fetch(url, {
        method: 'POST',
        body:   JSON.stringify(payload)
    }).then((response) => response.json() //.then((text) => {console.log(text);}));
            .then((responseData) => {
                console.log(responseData);
                return responseData;
            }));  

    div.classList = "collapse hide";
    getData();
    document.querySelector("#addCarDoneBtn").addEventListener("click", addCar);
}

function findHighlight(){
    let rows = document.querySelectorAll("tr");
    let HL;
    for (i = 0; i< rows.length; i++){
        if(rows[i].className === "highlighted"){
            HL = rows[i];
            break;
        }
    }
    let obj = {
        ID: HL.childNodes[0].innerHTML,
        Year: HL.childNodes[1].innerHTML,
        Make: HL.childNodes[2].innerHTML,
        Model: HL.childNodes[3].innerHTML,
        Colour: HL.childNodes[4].innerHTML
    };
//    console.log("OBJ to be deleted: ");
//    console.log(obj);
    return obj;
}


