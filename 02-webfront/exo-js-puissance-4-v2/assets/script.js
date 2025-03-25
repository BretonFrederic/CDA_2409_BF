const monSupport = document.getElementById("support");
const monTBody = document.getElementById("monTbody");

// Fonction générer la matrice
function genererTableau(ligneNbr, colonneNbr){
    const monTableau = [];

    for (let i = 0; i < ligneNbr; i++) {
        let ligne = [];
        for (let u = 0; u < colonneNbr; u++) {
            ligne.push("b");
        }
        monTableau.push(ligne);
    }
    return monTableau;
}

// Fonction afficher tableau
function afficherTableau(monTab){
    monTBody.innerHTML = "";
    for (let i = monTab.length-1; i >= 0; i--) {
        const maLigne = document.createElement("tr");
        monTBody.appendChild(maLigne);
        for (let u = 0; u < monTab[0].length; u++) {
            const maCell = document.createElement("td");
            maCell.textContent = `${i}${u}`;
            if(monTab[i][u] == "r"){
                maCell.classList.add("red");
            }
            else if(monTab[i][u] == "j"){
                maCell.classList.add("yellow");
            }
            else{
                maCell.classList.add("black");
            }
            maLigne.appendChild(maCell);
        }
    }
}

// Fonction ajouter pion
function ajouterPion(monTab){
    let numTour = 0;
    let gagnant = false;
    monSupport.addEventListener('click', (event)=>{
        if(numTour < 42 && gagnant === false && event.target.textContent.length === 2){
            const celluleCourante = event.target.textContent;
            const numCol = celluleCourante.charAt(1);

            let ajouterPion = false;
            for (let i = 0; i < monTab.length; i++) {
                if(monTab[i][numCol] == "b" && ajouterPion == false){
                    if(numTour%2 == 0){
                        monTab[i][numCol] = "r";
                        ajouterPion = true;
                        numTour++;
                    }
                    else if(numTour%2 != 0){
                        monTab[i][numCol] = "j";
                        ajouterPion = true;
                        numTour++;
                    }
                }
            }
            ajouterPion = false;
            const vainqueur = verifierGagnant(monTab);
            if(vainqueur !== ""){
                gagnant = true;
            }

            afficherTableau(monTab);
        }  
    });
}

// Fonction vérifier gagnant
function verifierGagnant(monTab){
    // check horizontal
    let gagnant = "";
    for (let i = monTab.length-1; i >= 0; i--) {
        if(monTab[i].toString().includes("r,r,r,r")){
            gagnant = "rouge";
            console.log("rouge a gagné !"); 
        }
        else if(monTab[i].toString().includes("j,j,j,j")){
            gagnant = "jaune";
            console.log("jaune a gagné !"); 
        }
    }

    // check vertical
    for (let i = 0; i < monTab[0].length; i++) {
        const colonneCourante = [];
        for (let u = 0; u < monTab.length; u++) {
            colonneCourante.push(monTab[u][i]);
        }
        if(colonneCourante.toString().includes("r,r,r,r")){
            gagnant = "rouge";
            console.log("rouge a gagné !"); 
        }
        else if(colonneCourante.toString().includes("j,j,j,j")){
            gagnant = "jaune";
            console.log("jaune a gagné !"); 
        }
    }
    
    // Verifier vainqueur sur les diagonales

    const abscisseMax = monTab[0].length-1;
    const ordonneeMax = monTab.length-1;
    const checkHorizontal = monTab[0].length-3;

    for (let u = 0; u < checkHorizontal; u++) {
        const diagonaleCouranteD = [];
        const diagonaleCouranteG = [];
        for (let i = 0; i <= ordonneeMax; i++) {
            if(ordonneeMax-i >= 0 && i+u <= abscisseMax){
                //monTab[ordonneeMax-i][i+u] = "r"; // VALEUR A PUSH
                diagonaleCouranteD.push(monTab[ordonneeMax-i][i+u]);
            }
            if(ordonneeMax-i >= 0 && abscisseMax-i-u >= 0){
                //monTab[ordonneeMax-i][abscisseMax-i-u] = "r"; // VALEUR A PUSH
                diagonaleCouranteG.push(monTab[ordonneeMax-i][abscisseMax-i-u]);
            }
        }
        if(diagonaleCouranteD.toString().includes("r,r,r,r") || diagonaleCouranteG.toString().includes("r,r,r,r")){
            gagnant = "rouge";
            console.log("rouge a gagné !"); 
        }
        else if(diagonaleCouranteD.toString().includes("j,j,j,j") || diagonaleCouranteG.toString().includes("j,j,j,j")){
            gagnant = "jaune";
            console.log("jaune a gagné !"); 
        }
    }
    
    return gagnant;
}

const unTableau = genererTableau(6, 7);

afficherTableau(unTableau);

ajouterPion(unTableau);
