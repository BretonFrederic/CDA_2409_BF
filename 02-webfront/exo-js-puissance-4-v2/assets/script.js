const monSupport = document.getElementById("support");
const monTBody = document.getElementById("monTbody");

// Tableau logique
const monTableau = [];
const nbrCol = 7;
const nbrL = 6;

for (let i = 0; i < nbrL; i++) {
    let ligne = [];
    for (let u = 0; u < nbrCol; u++) {
        ligne.push("b");
    }
    monTableau.push(ligne);
    //console.log(monTableau[0].length);
    
}
//console.log(monTableau);

// Générer tableau graphique
function genererTableau(tableauLogique){
    monTBody.innerHTML = "";
    for (let i = 0; i < tableauLogique.length; i++) {
        const maLigne = document.createElement("tr");
        monTBody.appendChild(maLigne);
        for (let u = 0; u < tableauLogique[0].length; u++) {
            const maCell = document.createElement("td");
            maCell.textContent = `${i}${u}`;
            console.log(tableauLogique[i][u]);
            if(tableauLogique[i][u] == "r"){
                maCell.classList.add("red");
            }
            maLigne.appendChild(maCell);
        }
    }
}

genererTableau(monTableau);

monSupport.addEventListener('click', (event)=>{
    //console.log(event.target.textContent);
    console.log(event.target);

    const celluleCourante = event.target.textContent;
    console.log(celluleCourante[0]+celluleCourante[1]);

    if(monTableau[celluleCourante[0]][celluleCourante[1]] != "b"){
        for (let i = 0; i < monTableau.length; i++) {
            monTableau[celluleCourante[i]][celluleCourante[1]] = "r";
        }
    }
    

    genererTableau(monTableau);
    
    // monTableau[0][0] = "r";
     console.log(monTableau);
    
})