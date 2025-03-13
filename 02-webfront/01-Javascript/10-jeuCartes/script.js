// 
const myTBody = document.querySelector("#data-stats");
const cellTitles = document.querySelectorAll("th");
let tabResult = [];
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
        tabResult = await response.json();

        console.log(tabResult);
        

        display(tabResult)
    }
    catch(error){
        // Afficher l'erreur dans la console
        console.error(error.message);
        tabResult = []
    }
}

// function addCell(myTRow){
//     myTRow.insertCell();
// }

// créer ligne tableau
// function addCard(myTBody){
//     const myTRow = myTBody.insertRow();
//     const statsCards = getCardGame();
//     console.log("stats : "+statsCards);
//     statsCards.forEach(card => {
//         const myCell = addCell(myTRow);
//         myCell.setAttribute()
//     });
// }

// addCard(dataStats);

// Créer ligne
const myTRow = myTBody.insertRow();

// Récupérer json 
//const statsCards = await getCardGame();
//console.log(statsCards);


// Initialiser les cellules du tableau
// for (let i = 0; i < cellTitles.length; i++) {
//     console.log(cellTitles[i].textContent);
//     console.log(statsCards[i].name);
    
//     console.log(statsCards[i].filter(key => key == cellTitles[i].textContent));
    
// }
const cellId = myTRow.insertCell();

const display = (res) => {
    res.forEach(r => {
        console.log(r);
        
    })
}

getCardGame()