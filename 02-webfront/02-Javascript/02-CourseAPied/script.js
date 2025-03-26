const listRunners = document.querySelector("#list-runners");
const nbParticipants = document.querySelector("#nb-participants");
const winner = document.querySelector("#winner");
const timeAvg = document.querySelector("#time-avg");
const allCheckbox = document.querySelectorAll(".checkbox");

let dataRunners = [];

// Récupérer le json
async function downloadJson(jsonUrl){
    try {
        const response = await fetch(jsonUrl);
        if(!response.ok){
            throw new Error(`Reponse status : ${response.status}`)
        }
        const myJson = await response.json();
        dataRunners = myJson;
        console.log(dataRunners);

        // Générer les données dans le tableau
        generateDataTable(dataRunners, listRunners);

        // Afficher résultat de la course
        displayResult(dataRunners);
        

    } catch (error) {
        console.log(error.message);
    } 
}

// Fonction pour ajouter une cellule
function addCell(row, text){
    const myCell = row.insertCell();
    myCell.textContent = text;
    myCell.setAttribute("style", "padding: 5px;");
    row.appendChild(myCell);
}

// Fonction pour ajouter une ligne
function addRow(myTBody, dataJson, currentIndex){
    const myRunner = myTBody.insertRow();
    addCell(myRunner, dataJson[currentIndex].pays);
    const fullname = dataJson[currentIndex].nom.split(" ");
    const lastname = fullname[0];
    const firstname = fullname[1];
    addCell(myRunner, lastname);
    addCell(myRunner, firstname);
    const timeMin = Math.floor(dataJson[currentIndex].temps/60);
    let timeSec = (dataJson[currentIndex].temps%60);
    if(timeSec < 10){
        timeSec = `0${timeSec}`;
    }
    const finalTime = `${timeMin}min${timeSec}s`;
    addCell(myRunner, finalTime);
}

// Fonction qui génère les données du tableau
function generateDataTable(dataJson, myTBody){
    myTBody.innerHTML =  "";
    dataJson.sort((a, b) => a.temps - b.temps);
        for (let index = 0; index < dataJson.length; index++) {
        addRow(myTBody, dataJson, index);
    }
}

// Fonction qui affiche résultat de la course
function displayResult(myData){
    nbParticipants.textContent = `${myData.length} participants`;
    const fullname = myData[0].nom.split(" ");
    const lastname = fullname[0];
    const firstname = fullname[1];
    winner.textContent = `Gagnant : ${firstname} ${lastname}`;
    const avgTime = myData.reduce((acc, obj) =>  acc + obj.temps, 0)/myData.length;
    const avgTimeMin = Math.floor(avgTime/60);
    let avgTimeSec = Math.floor(avgTime%60);
    if(avgTimeSec < 10){
        avgTimeSec = `0${avgTimeSec}`;
    }
    timeAvg.textContent = `Temps moyen : ${avgTimeMin} minutes et ${avgTimeSec} secondes`;
    console.log(avgTimeMin);
}

// Fonction qui filtre la liste du tableau
// function filterDataRunners(inputCheckbox, dataJson){
    
//     return dataJson;
// }

allCheckbox.forEach(checkbox => {
    console.log(checkbox.checked);
    if(checkbox.checked === true){
        //
    }
});

downloadJson("./resultat10000metres.json");
