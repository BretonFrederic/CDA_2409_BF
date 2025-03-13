const myTBody = document.querySelector("#data-stats");
const myTh = document.querySelectorAll("th");

// fonction qui interroge une api récupère les données les parse/analyse et structure en json et initialise un tableau d'objets littéraux
async function getCardGame(){
    const url = "https://arfp.github.io/tp/web/javascript/03-cardgame/cardgame.json";

    try {
        // interroger api
        const response  = await fetch(url); // avec await --> reponse | sans await --> promesse
        // console.log(response);

        // Gestion erreur
        if(!response.ok){
            throw new Error(`Response status: ${response.status}`);
        }
        const json = await response.json(); // avec await --> objets littéraux | sans await --> promesse
        // console.log(json);
    
        await addCards(json);
        await displayMaxVictories(json);
        await displayBestRatio(json);
    } catch (error) {
        // Afficher l'erreur dans la console
        console.error(error.message);
    }
}

function addCell(row, myText){
    const myCell = row.insertCell();
    myCell.textContent = myText;
    myCell.setAttribute("style", "text-align:center; padding:8px 0px;");
}

async function addCards(myJson){
        // Ajouter les cards dans tableau
        for (let u = 0; u < myJson.length; u++) {
            const myRow = myTBody.insertRow();
            let numLine = u + 1;
            if(numLine%2 === 0){
                myRow.setAttribute("style", "background-color:#eeeeee;")
            }
            
            // Titre cellule est égale à clé d'objet ajouter valeur associée dans cellule de ligne courante
            for (let i = 0; i < myTh.length; i++) {
                const obj = myJson.find(card => card.id == numLine);
                if(myTh[i].textContent == "description"){
                    addCell(myRow, "");
                }
                else if(myTh[i].textContent in obj){
                    addCell(myRow, obj[myTh[i].textContent]);
                }
                else{
                    addCell(myRow, "unknown");
                }
            }
        }
}

async function displayMaxVictories(myJson) {
    const pVictories = document.querySelector("#max-vitories");
    let maxPlayed = 0;
    let nameCard = "";
    let totalVictory = 0;
    myJson.forEach(card => { 
        if(card.played > maxPlayed){
            maxPlayed = card.played;
            nameCard = card.name;
            totalVictory = card.victory;
        }
    });

    pVictories.innerHTML = `${nameCard} avec un nombre de victoires de <span style="font-weight: bold;"> ${totalVictory} </span> a le plus de parties jouées :<span style="font-weight: bold;">  ${maxPlayed} </span>`;
    
}

async function displayBestRatio(myJson) {
    const pRatio = document.querySelector("#best-ratio");
    let bestRatio = 0;
    let nameCard = "";
    let played = 0;
    let totalVictory = 0;
    myJson.forEach(card => {
        // card.victory + 0.5*draw/card.defeat
        if(card.victory*100/(card.played-card.draw) > bestRatio){
            bestRatio = (card.victory*100/(card.played-card.draw)).toFixed(2);
            nameCard = card.name;
            totalVictory = card.victory;
            played = card.played;
        }
    });
    pRatio.innerHTML = `${nameCard} avec un nombre de parties de <span style="font-weight: bold;">  ${played} </span> et un nombre de victoires de <span style="font-weight: bold;"> ${totalVictory} </span> a le meilleur ratio victoires/défaites :<span style="font-weight: bold;"> ${bestRatio} % </span>(les matchs nuls sont ignorés).`;
    
}

getCardGame();


