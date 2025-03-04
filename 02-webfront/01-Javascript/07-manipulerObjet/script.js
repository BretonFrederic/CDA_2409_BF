const myEmployee = {
    lastname: "Doe", 
    firstname: "John", 
    birthday: "1981-11-12", 
    salary: 2150
}
const principal = document.querySelector("#principal");

// Créer une table
const myTable = document.createElement('table');
myTable.setAttribute("style", "margin-top:20px; border-collapse: collapse;");
principal.appendChild(myTable);

// Créer la balise thead (dans la table)
const myTHeader = myTable.createTHead();

// Créer le tr (dans le thead)
const myTitleRow = myTHeader.insertRow();

// Créer le th (dans le tr du thead)
// const myCellTitle = document.createElement('th');
// myCellTitle.setAttribute("style", "border:2px solid #e3fae3; padding:5px; background-color:#90ee90");
// myCellTitle.textContent = "Nom";
// myTitleRow.appendChild(myCellTitle);

// Fonction pour créer les cellules titres du tableau
function addCellTitle(row, text){
    const myCellTitle = document.createElement('th');
    myCellTitle.setAttribute("style", "border:2px solid #e3fae3; padding:5px; background-color:#90ee90");
    myCellTitle.textContent = text;
    row.appendChild(myCellTitle);
}

// Ajouter cellule et son titre pour chaque titre
const myTitle = ["Nom", "Prénom", "Date de naissance", "Email", "Salaire"];
myTitle.forEach(element => {
    addCellTitle(myTitleRow, element);
});

// Créer la balise tbody (dans la table)
const myTBody = myTable.createTBody();

// Créer le tr (dans le tbody)
const myRow = myTBody.insertRow();

// Créer le td (dans le tr du tbody)
// const myCell = document.createElement('td');
// myCell.setAttribute("style", "border:2px solid #e3fae3; padding:5px; background-color:#90ee90");
// myCell.textContent = "info";
// myRow.appendChild(myCell);

// Fonction pour créer les cellules dans tbody du tableau
function addCell(row, text){
    const myCell = document.createElement('td');
    myCell.setAttribute("style", "border:2px solid #e3fae3; padding:5px; background-color:#90ee90");
    myCell.textContent = text;
    row.appendChild(myCell);
}

// Ajouter cellule et son texte pour chaque cellule du tbody
const info = ["Nom", "Prénom", "Date de naissance", "Email", "Salaire"];
info.forEach(element => {
    addCell(myRow, element);
});