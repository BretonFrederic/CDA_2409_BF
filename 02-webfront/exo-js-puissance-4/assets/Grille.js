export class GrillePuissanceQuatre{
    constructor(ligne, colonne){
        this.ligne = ligne;
        this.colonne = colonne;
    }

    genererGrille(maDiv){
        const maTable = document.createElement("table");
        maDiv.appendChild(maTable);
        const monTHead = document.createElement("thead");
        maTable.appendChild(monTHead);
        const monTr = document.createElement("tr");
        monTHead.appendChild(monTr);
        for (let j = 0; j < this.colonne; j++) {
            const maCell = document.createElement("th");
            maCell.textContent = `${j}`;
            monTr.appendChild(maCell);   
        }
        const monTBody = document.createElement("tbody");
        maTable.appendChild(monTBody);
        for (let i = 0; i < this.ligne; i++) {
            const monTr = document.createElement("tr");
            monTBody.appendChild(monTr);
            for (let u = 0; u < this.colonne; u++) {
                const maCell = document.createElement("td");
                maCell.textContent = `${i}${u}`;
                monTr.appendChild(maCell);   
            }
        }
    }
}