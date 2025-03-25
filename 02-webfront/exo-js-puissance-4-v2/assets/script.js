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
    
    // check diagonal G/D
    // for (let u = 0; u <= 3; u++) {
    //     const colonneCourante = [];
    //     for (let i = 0; i < monTab[monTab.length-1].length; i++) {
    //         if((monTab.length-1)-i >= 0 && i+u < 7){
    //             colonneCourante.push(monTab[(monTab.length-1)-i][i+u]);
    //             //monTab[(monTab.length-1)-i][i+u] = "r";
    //         } 
    //     }
    //     if(colonneCourante.toString().includes("r,r,r,r")){
    //         gagnant = "rouge";
    //         console.log("rouge a gagné !"); 
    //     }
    //     else if(colonneCourante.toString().includes("j,j,j,j")){
    //         gagnant = "jaune";
    //         console.log("jaune a gagné !"); 
    //     }
    // }

    // for (let u = monTab.length-(monTab.length-1); u < monTab.length-3; u++) {
    //     const colonneCourante = [];
    //     console.log(u);
    //     for (let i = u; i < monTab[monTab.length-1].length ; i++) {
    //         if((monTab.length-1)-i >= 0 && i < 7){
    //             colonneCourante.push(monTab[(monTab.length-1)-i][i-u]);
    //             //monTab[(monTab.length-1)-i][i-u] = "j";  
    //         }
    //     }
    //     if(colonneCourante.toString().includes("r,r,r,r")){
    //         gagnant = "rouge";
    //         console.log("rouge a gagné !"); 
    //     }
    //     else if(colonneCourante.toString().includes("j,j,j,j")){
    //         gagnant = "jaune";
    //         console.log("jaune a gagné !"); 
    //     }
    // }

    // check diagonal D/G
    // monTab[5][6] = "r";
    // monTab[4][5] = "r";
    // monTab[3][4] = "r";
    // monTab[2][3] = "r";


     for (let u = 0; u <= 3; u++) { // 4 première case en haut a gauche
        for (let i = 0; i < monTab[monTab.length-1].length; i++) { // parcours la ligne entière
            if((monTab.length-1)-i >= 0 && i+u < 7){ // controle valeurs x y dans limite tableau
                monTab[(monTab.length-1)-i][i+u] = "r"; // y = (ligneMax-1)-i | i de 0 à 6 && x = i+u
                console.log("y : "+((monTab.length-1)-i)+" x : "+(i+u));
                console.log(i);
                
                
            } 
        }
    }

    
    return gagnant;
}

const unTableau = genererTableau(6, 7);

afficherTableau(unTableau);

ajouterPion(unTableau);
