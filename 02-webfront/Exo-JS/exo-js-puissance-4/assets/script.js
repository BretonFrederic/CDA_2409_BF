const unSupport = document.getElementById("support");
const unTBody = document.getElementById("monTbody");
const info = document.getElementById("info");
const nouvellePartie = document.getElementById("nouvellePartie");

// Fonction générer la matrice
function genererTableau(ligneNbr, colonneNbr){
    const monTableau = [];
    // const monTableau = [...Array(6)].map(() => Array(7).fill(''));

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
function afficherTableau(monTab, monTBody){
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

// Afficher couleur joueur 1
info.classList.add("red");
info.textContent = "Joueur 1";

// Fonction ajouter pion
function ajouterPion(monTab, monSupport, monTBody){
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
                        info.classList.remove("red");
                        info.classList.add("yellow");
                        info.textContent = "Joueur 2";
                        ajouterPion = true;
                        numTour++;
                    }
                    else if(numTour%2 != 0){
                        monTab[i][numCol] = "j";
                        info.classList.remove("yellow");
                        info.classList.add("red");
                        info.textContent = "Joueur 1";
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
            if(vainqueur == "rouge"){
                info.classList.remove("yellow");
                info.classList.add("red");
                info.textContent = "Gagné !";
            }
            else if(vainqueur == "jaune"){
                info.classList.remove("red");
                info.classList.add("yellow");
                info.textContent = "Gagné !";
            }

            // Mise à jour du tableau
            afficherTableau(monTab, monTBody);
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
            info.textContent = "Gagné !";
            console.log("rouge a gagné !"); 
        }
        else if(monTab[i].toString().includes("j,j,j,j")){
            gagnant = "jaune";
            info.textContent = "Gagné !";
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
            info.textContent = "Gagné !";
            console.log("rouge a gagné !"); 
        }
        else if(colonneCourante.toString().includes("j,j,j,j")){
            gagnant = "jaune";
            info.textContent = "Gagné !";
            console.log("jaune a gagné !"); 
        }
    }
    
    // Check diagonales
    const abscisseMax = monTab[0].length-1;
    const ordonneeMax = monTab.length-1;
    const checkHorizontal = monTab[0].length-3;

    for (let u = 0; u < checkHorizontal; u++) {
        const diagonaleCouranteD = [];
        const diagonaleCouranteG = [];
        for (let i = 0; i <= ordonneeMax; i++) {
            if(ordonneeMax-i >= 0 && i+u <= abscisseMax){
                //monTab[ordonneeMax-i][i+u] = "r";
                diagonaleCouranteD.push(monTab[ordonneeMax-i][i+u]);
            }
            if(ordonneeMax-i >= 0 && abscisseMax-i-u >= 0){
                //monTab[ordonneeMax-i][abscisseMax-i-u] = "r";
                diagonaleCouranteG.push(monTab[ordonneeMax-i][abscisseMax-i-u]);
            }
        }
        if(diagonaleCouranteD.toString().includes("r,r,r,r") || diagonaleCouranteG.toString().includes("r,r,r,r")){
            gagnant = "rouge";
            info.textContent = "Gagné !";
            console.log("rouge a gagné !");
        }
        else if(diagonaleCouranteD.toString().includes("j,j,j,j") || diagonaleCouranteG.toString().includes("j,j,j,j")){
            gagnant = "jaune";
            info.textContent = "Gagné !";
            console.log("jaune a gagné !");
        }
    }

    for (let i = 3; i < ordonneeMax; i++) {
        const diagonaleCouranteD = [];
        const diagonaleCouranteG = [];
        for (let u = 0; u <= abscisseMax; u++) {
            if(i-u >= 0 && u <= abscisseMax){
                //monTab[i-u][u] = "r";
                diagonaleCouranteD.push(monTab[i-u][u]);
            }
        }
        for (let u = 0; u <= abscisseMax; u++) {
            if(i-u >= 0 && abscisseMax-u >= 0){
                //monTab[i-u][abscisseMax-u] = "r";
                diagonaleCouranteG.push(monTab[i-u][abscisseMax-u]);
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

nouvellePartie.addEventListener('click', ()=>{
    location.reload();
});

afficherTableau(unTableau, unTBody);

ajouterPion(unTableau, unSupport, unTBody);
