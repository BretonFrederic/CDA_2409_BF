const myEmployee = {
    lastname: "Doe", 
    firstname: "John", 
    birthday: "1981-11-12", 
    salary: 2150
}
const dataProfil = document.querySelector("#data-profil");

// Créer une table
const myTable = document.createElement('table');
myTable.setAttribute("style", "margin-top:20px; margin-bottom:30px; border-collapse: collapse;");
dataProfil.appendChild(myTable);

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

// Renvoyer un tableau contenant les valeurs d'un objet
const employeeArray = Object.values(myEmployee);

// Récupérer firstname et lastname de l'objet
const firstname = myEmployee.firstname;
const lastname = myEmployee.lastname;

// Générer l'email
const eMail = firstname+"."+lastname+"@example.com";

// Ajout de l'email dans le tableau
employeeArray.splice(3, 0, eMail.toLowerCase());

// Ajout du symbole monétaire pour salary
const salary = myEmployee.salary + " €";
employeeArray.splice(4, 1, salary);

// Ajouter cellule et son texte pour chaque cellule du tbody
console.log(employeeArray);
employeeArray.forEach(element => {
    addCell(myRow, element);
});

// Pré-remplir le formulaire de profil
const inputProfil = document.querySelectorAll(".input-profil");
const infoProfil = Object.values(myEmployee);

for (let index = 0; index < infoProfil.length; index++) {
    const firstN = myEmployee.firstname;
    const lastN = myEmployee.lastname;
    infoProfil.splice(0, 1, firstN);
    infoProfil.splice(1, 1, lastN);
    inputProfil[index].value = infoProfil[index];
    
}

// Contrôler les valeurs saisies dans le formulaire

// générer le nouveau email

// Enregistrer les nouvelles valeurs dans le tableau