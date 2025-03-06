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

// Fonction pour générer l'email
function createMail(fName, lName){
    const eMail = fName.toLowerCase()+"."+lName.toLowerCase()+"@example.com";
    return eMail;
}

modifyRow();

// Fonction pour ajouter cellule et son texte pour chaque cellule du tbody
function modifyRow(){
    addCell(myRow, myEmployee.lastname);
    addCell(myRow, myEmployee.firstname);
    addCell(myRow, myEmployee.birthday);
    addCell(myRow, createMail(myEmployee.firstname, myEmployee.lastname));
    addCell(myRow, myEmployee.salary+ " €");
}

// Fonction pour mettre à jour les cellules
function updateRow(){
    tabCell=document.querySelectorAll("td");
    tabCell.forEach((e)=>{e.remove()});
    modifyRow();
}

function checkValue(myValue, element){
    // Vérification nom et prénom
    if(element == document.querySelector("#lastname") || element == document.querySelector("#firstname")){
        const regexName = /^[A-Z]{0,1}[a-zàâäéèêëïîôöùûüÿç]{2,20}[-]{0,1}[a-zàâäéèêëïîôöùûüÿç]{0,20}$/;
        if(myValue.match(regexName)){
            return true;
        }
        else{
            return false;
        }
    }
    // Vérification date de naissance
    if(element == document.querySelector("#birth-date")){
        console.log(Date.parse(myValue));
        if(Date.parse(myValue)){
            return true;
        }
        else{
            return false;
        }
    }
    // Vérification salaire
    if(element == document.querySelector("#salary") || element == document.querySelector("#salary")){
        const regexSalary = /^[0-9]{1,}$/;
        if(myValue.match(regexSalary)){
            return true;
        }
        else{
            return false;
        }
    }
}

// -----------------------------------------------------------------------------------------------------------

// Pré-remplir le profil
document.querySelector("#lastname").value = myEmployee.lastname;
document.querySelector("#firstname").value = myEmployee.firstname;
document.querySelector("#birth-date").value = myEmployee.birthday;
document.querySelector("#salary").value = myEmployee.salary;

// Fonction pour sauvegarder information formulaire
function saveInfo(){
    if(myEmployee.lastname !== document.querySelector('#lastname').value){
        if(checkValue(document.querySelector('#lastname').value, document.querySelector('#lastname'))){
            myEmployee.lastname = document.querySelector('#lastname').value;
            updateRow();
        }
        else{
            document.querySelector('#lastname').value = "";
        }
    }
    if(myEmployee.firstname !== document.querySelector('#firstname').value){
        if(checkValue(document.querySelector('#firstname').value, document.querySelector('#firstname'))){
            myEmployee.firstname = document.querySelector('#firstname').value;
            updateRow();
        }
        else{
            document.querySelector('#firstname').value = "";
        }
    }
    if(myEmployee.birthday !== document.querySelector('#birth-date').value){
        if(checkValue(document.querySelector('#birth-date').value, document.querySelector('#birth-date'))){
            myEmployee.birthday = document.querySelector('#birth-date').value;
            updateRow();
        }
        else{
            document.querySelector('#birth-date').value = "";
        }
    }
    if(myEmployee.salary !== document.querySelector('#salary').value){
        if(checkValue(document.querySelector('#salary').value, document.querySelector('#salary'))&&
            myEmployee.salary <= document.querySelector('#salary').value){
            myEmployee.salary = document.querySelector('#salary').value;
            updateRow();
        }
        else{
            document.querySelector('#salary').value = "";
        }
    }
}

// Sauvegarder les infos
const btnSave = document.querySelector("#btn-save");
btnSave.addEventListener('click', saveInfo);




