// 
const dataStats = document.querySelector("#data-stats"); 

async function getCardGame(){
    const url = "https://arfp.github.io/tp/web/javascript/03-cardgame/cardgame.json";
    try{
        // interroger api
        const response = await fetch(url);
        // Gestion erreur
        if(!response.ok){
            throw new Error(`Response status: ${response.status}`);
        }
        // Récupérer au format json
        const json = await response.json();
        //console.log(json);
        return json;
    }
    catch(error){
        // Afficher l'erreur dans la console
        console.error(error.message);
    }
}

function addCell(myTRow){
    myTRow.insertCell();
}

// créer ligne tableau
function addCard(myTBody){
    const myTRow = myTBody.insertRow();
    const statsCards = getCardGame();
    console.log("stats : "+statsCards);
    statsCards.forEach(card => {
        const myCell = addCell(myTRow);
        myCell.setAttribute()
    });
}

addCard(dataStats);