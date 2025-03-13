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
        display(tabResult)
    }
    catch(error){
        // Afficher l'erreur dans la console
        console.error(error.message);
        tabResult = []
    }
}

const myTRow = myTBody.insertRow();

const cellId = myTRow.insertCell();

const display = (res) => {
    res.forEach(r => {
        console.log(r);
        
    })
}

getCardGame()