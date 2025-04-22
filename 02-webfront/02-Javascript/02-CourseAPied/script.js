const myTBody = document.querySelector("#tbody");
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

        // Ajouter écart de temps
        const data = addGapTime(dataRunners);
        console.log(data);
        

        // Filtrer les coureurs des pays sélectionnés
        selectData(data, allCheckbox, myTBody);

        // Générer les données dans le tableau
        generateDataTable(data, myTBody);

        // Afficher résultat de la course
        displayResult(data);
        

    } catch (error) {
        console.log(error.message);
    } 
}

// Calculer l'écart de temps
function addGapTime(myJson){
    const bestTimeInSec = myJson.reduce((acc, obj) => {return obj.temps > acc.temps ? acc : obj}).temps;
    // pour chaque objet ajouter key gapTime valeur écart de temps
    return myJson.map(obj => ({...obj, gapTime:`+${obj.temps - bestTimeInSec}s`}));
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
    addCell(myRunner, dataJson[currentIndex].gapTime);
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
    
    // Temps moyen
    const avgTime = myData.reduce((acc, obj) => acc + obj.temps, 0)/myData.length;
    
    const avgTimeMin = Math.floor(avgTime/60);
    let avgTimeSec = Math.floor(avgTime%60);
    if(avgTimeSec < 10){
        avgTimeSec = `0${avgTimeSec}`;
    }
    timeAvg.textContent = `Temps moyen : ${avgTimeMin} minutes et ${avgTimeSec} secondes`;
}

// Fonction qui filtre les coureurs par pays sélectionnés
function selectData(dataParticipants, checkboxParticipants, tBody){
    let runnerSelected = [...dataParticipants];
 
    checkboxParticipants.forEach(checkbox => checkbox.addEventListener('change', ()=>{
        runnerSelected.splice(0,runnerSelected.length);

        // Filtrer les coureurs de la liste sélectionnée. Spread [... ] pour passer la liste de node en tableau
        const countrieSelected = [...checkboxParticipants].filter(checkbox => checkbox.checked).map(checkbox => checkbox.value);
        
        runnerSelected = dataParticipants.filter(data => countrieSelected.includes(data.pays));

        if(countrieSelected.length === 0){
            // Générer les données dans le tableau
            generateDataTable(dataParticipants, tBody);
            displayResult(dataParticipants);
        }
        else{
            // Générer les données dans le tableau
            generateDataTable(runnerSelected, tBody);
            displayResult(runnerSelected);
        }
    }));
}

downloadJson("./resultat10000metres.json");
