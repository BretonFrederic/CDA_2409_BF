// const myTBody = document.querySelector("#data-stats");

// const myRow = myTBody.insertRow();

// const myCell = myRow.insertCell();

// myCell.textContent = "test";

const myTBody = document.querySelector("#data-stats");
const myTh = document.querySelectorAll("th");

// fonction qui interroge une api récupère les données les parse/analyse et structure en json et initialise un tableau d'objets littéraux
async function getCardGame(){
    const url = "https://arfp.github.io/tp/web/javascript/03-cardgame/cardgame.json";

    const response  = await fetch(url); // avec await --> reponse | sans await --> promesse
    // console.log(response);
    
    const json = await response.json(); // avec await --> objets littéraux | sans await --> promesse
    // console.log(json);

    // Ajouter les cards dans tableau
    for (let u = 0; u < json.length; u++) {
        const myRow = myTBody.insertRow();
        let numLine = u + 1;
        if(numLine%2 === 0){
            myRow.setAttribute("style", "background-color:#eeeeee;")
        }
        
        // Titre cellule est égale à clé d'objet ajouter valeur associée dans cellule de ligne courante
        for (let i = 0; i < myTh.length; i++) {
            const obj = json.find(element => element.id == numLine);
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

function addCell(row, myText){
    const myCell = row.insertCell();
    myCell.textContent = myText;
    myCell.setAttribute("style", "text-align:center; padding:8px 0px;")
}

getCardGame();


