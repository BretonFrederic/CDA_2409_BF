export class PuissanceQuatre{

    // Constructeur
    constructor(balise, ligne, colonne){
        if(ligne < 6){
            ligne = 6;
        }
        if(colonne < 7){
            colonne = 7;
        }
        this.ligne = ligne;
        this.colonne = colonne;
        this.balise = balise;
        this.maTable = "";
    }

    // méthodes
    genererGrille(){
        this.maTable = document.createElement("table");
        this.balise.appendChild(this.maTable);
        // const monTHead = document.createElement("thead");
        // this.maTable.appendChild(monTHead);
        // const monTr = document.createElement("tr");
        // monTHead.appendChild(monTr);
        // for (let j = 0; j < this.colonne; j++) {
        //     const maCellTitre = document.createElement("th");
        //     maCellTitre.id = `col-${j}`;
        //     maCellTitre.textContent = `Ajouter ${j}`;
        //     monTr.appendChild(maCellTitre);   
        // }
        const monTBody = document.createElement("tbody");
        this.maTable.appendChild(monTBody);
        for (let i = 0; i < this.ligne; i++) {
            const monTr = document.createElement("tr");
            monTr.id = `row-${i}`;
            monTBody.appendChild(monTr);
            for (let u = 0; u < this.colonne; u++) {
                const maCell = document.createElement("td");
                maCell.classList = "cellule";
                // ligne, colonne, couleur
                maCell.textContent = `${i}${u}b`;
                monTr.appendChild(maCell);   
            }
        }
    }

    ajouterPion(){
        let tourNumero = 0;
        this.balise.addEventListener("click", (event)=>{
            console.log(event.target);
            if(event.target.textContent.length === 3 && tourNumero < 42){
                let couleurPion = "#000000";
                let refCouleurCellule = "b";
                if(tourNumero%2 == 0){
                    couleurPion = "background-color: #ff0000;";
                    refCouleurCellule = "r";
                }
                else if(tourNumero%2 != 0){
                    couleurPion = "background-color: #ffee00;";
                    refCouleurCellule = "j";
                }
                const cellules = document.getElementsByClassName("cellule");
                let maColonne = [];
                for (let index = 0; index < cellules.length; index++) {
                    if(cellules[index].textContent.charAt(1) === event.target.textContent.charAt(1) && cellules[index].textContent.charAt(2) == "b"){
                        maColonne.push(cellules[index]);
                    }
                }
                // console.log(maColonne[maColonne.length-1].textContent);
                if(maColonne.length > 0){
                    maColonne[maColonne.length-1].textContent = maColonne[maColonne.length-1].textContent.replace("b", refCouleurCellule);
                    maColonne[maColonne.length-1].setAttribute("style", couleurPion);
                    tourNumero += 1;
                    console.log(tourNumero);
                } 
            }
            this.#verifierGagnant();
        });
    }

    #verifierGagnant(){
        console.log(this.maTable.textContent);
        // récupérer ligne courante du bas vers le haut, .test(regex)
    }
}