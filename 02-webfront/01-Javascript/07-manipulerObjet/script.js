const myEmployee = {
    lastname: "Doe", 
    firstname: "John", 
    birthday: "1981-11-12", 
    salary: 2150
}
const dataProfil = document.querySelector("#data-profil");

// Créer une table -------------------------------------------------------------------------------------------
const myTable = document.createElement('table');
myTable.setAttribute("style", "margin-top:20px; margin-bottom:30px; border-collapse: collapse;");
dataProfil.appendChild(myTable);

// Créer la balise thead (dans la table)
const myTHeader = myTable.createTHead();

// Créer le tr (dans le thead)
const myTitleRow = myTHeader.insertRow();

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
let myRow = myTBody.insertRow();

// Fonction pour créer les cellules dans tbody du tableau
function addCell(row, text){
    const myCell = document.createElement('td');
    myCell.setAttribute("style", "border:2px solid #e3fae3; padding:5px; background-color:#90ee90");
    myCell.textContent = text;
    row.appendChild(myCell);
}

// Générer l'email
function createMail(fName, lName){
    const eMail = fName+"."+lName+"@example.com";
    return eMail;
}
//----------------------------------------------------------------------------------
// Renvoyer un tableau contenant les valeurs d'un objet
let employeeArray = Object.values(myEmployee);

// Récupérer firstname et lastname de l'objet
const firstname = myEmployee.firstname;
const lastname = myEmployee.lastname;



const eMail = createMail(firstname, lastname);

// Ajout de l'email dans le tableau
employeeArray.splice(3, 0, eMail.toLowerCase());

// Ajout du symbole monétaire pour salary
const salary = myEmployee.salary + " €";
employeeArray.splice(4, 1, salary);
//-----------------------------------------------------------------------------
// Ajouter cellule et son texte pour chaque cellule du tbody
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
const btnSave = document.querySelector("#btn-save");

// const regexName = /^[A-Z]{0,1}[a-zàâäéèêëïîôöùûüÿç]{1,20}[-]{0,1}[a-zàâäéèêëïîôöùûüÿç]{0,20}$/;
// const regexDate = /^[0-9]{2}-[0-9]{2}-[0-9]{4}$/;
// const regexSalary = /^[0-9]{1,}$/;

// if(!inputFirstname.match(regexName)){
//     document.querySelector("#firstname").value = "";
// }
// if(!inputLastname.match(regexName)){
//     document.querySelector("#lastname").value = "";
// }
// if(!Number.isNaN(new Date(...inputBirthDate).valueOf())){
//     document.querySelector("#birth-date").value = "";
//     console.log("date invalide");
// }

// Enregistrer les nouvelles valeurs dans le tableau
btnSave.addEventListener('click', ()=>{

    console.log(employeeArray);
    console.log(myEmployee);
    updateEmployee();
    console.log(myEmployee);
});

function updateEmployee(){
    myEmployee.lastname = document.querySelector("#lastname").value;
    myEmployee.firstname = document.querySelector("#firstname").value;
    myEmployee.birthday = document.querySelector("#birth-date").value;
    myEmployee.salary = document.querySelector("#salary").value;

    // Renvoyer un tableau contenant les valeurs d'un objet
    employeeArray = Object.values(myEmployee);
    // Supprimer la row du tbody
    myRow.remove();
    // Créer le tr (dans le tbody)
    myRow = myTBody.insertRow();
    const eMail = createMail(myEmployee.firstname, myEmployee.lastname);

    // Ajout de l'email dans le tableau
    employeeArray.splice(3, 0, eMail.toLowerCase());

    // Ajout du symbole monétaire pour salary
    const salary = myEmployee.salary + " €";
    employeeArray.splice(4, 1, salary);

    // Ajouter cellule et son texte pour chaque cellule du tbody
    employeeArray.forEach(element => {
        addCell(myRow, element);
    });
}