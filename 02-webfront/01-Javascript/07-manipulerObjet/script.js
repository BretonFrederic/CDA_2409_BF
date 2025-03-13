// Un objet est une structure de données qui regroupe ensemble des couples clé-valeur, 
// chaque clé représentant une propriété (ou un attribut) de l'objet.

// On parle d'objet littéral pour le différencier des instances de classe qu'on appelle aussi objet. 
// Quand on dit "objet littéral", on insiste sur le fait qu'on parle de la structure de données, 
// alors que quand on parle d'"instance" on met l'accent sur le fait qu'il a été instancié via une classe.

// En réalité, dans les 2 cas ce sont bien des objets littéraux qu'on manipule.

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

// Fonction qui retire les accents d'un texte. 
// é.normalize('NFD') décompose les caractères spéciaux : é -> e+◌́  
// .replace(/[\u0300-\u036f]/g, '') retire les caractères diacritiques : e+◌́  -> e
function removeAccents(myString) {
    return myString.normalize('NFD').replace(/[\u0300-\u036f]/g, '');
  }

// Fonction pour générer l'email
function createMail(fName, lName){
    return removeAccents(fName.toLowerCase())+"."+removeAccents(lName.toLowerCase())+"@example.com";
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

// Fonction vérification si valeur saisie est valide
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
        const regexDate = /^[0-9]{4}-[0-9]{2}-[0-9]{2}$/;
        if(myValue.match(regexDate) && Date.parse(myValue) && Date.now() > new Date(myValue).getTime()){
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

// Fonction afficher message quand valeur saisie invalide
function displayInvalid(element, id){
    if(!document.querySelector('#'+id)){
        const invalideValue = document.createElement('p');
        invalideValue.textContent = "* invalide";
        invalideValue.setAttribute("id", id);
        invalideValue.setAttribute("style", "display:inline; color:red;");
        element.parentElement.appendChild(invalideValue);
    }
}

// -----------------------------------------------------------------------------------------------------------

// Pré-remplir le profil
document.querySelector("#lastname").value = myEmployee.lastname;
document.querySelector("#firstname").value = myEmployee.firstname;
document.querySelector("#birth-date").value = myEmployee.birthday;
document.querySelector("#salary").value = myEmployee.salary;

// Fonction pour enregistrer informations formulaire
function saveInfo(){
    if(myEmployee.lastname !== document.querySelector('#lastname').value){
        if(checkValue(document.querySelector('#lastname').value, document.querySelector('#lastname'))){
            myEmployee.lastname = document.querySelector('#lastname').value;
            updateRow();
            if(document.querySelector('#invalid-lname')){
                document.querySelector('#invalid-lname').remove();
            }
        }
        else{
            displayInvalid(document.querySelector('#lastname'), "invalid-lname");
        }
    }
    if(myEmployee.firstname !== document.querySelector('#firstname').value){
        if(checkValue(document.querySelector('#firstname').value, document.querySelector('#firstname'))){
            myEmployee.firstname = document.querySelector('#firstname').value;
            updateRow();
            if(document.querySelector('#invalid-fname')){
                document.querySelector('#invalid-fname').remove();
            }
        }
        else{
            displayInvalid(document.querySelector('#firstname'), 'invalid-fname');
        }
    }
    if(myEmployee.birthday !== document.querySelector('#birth-date').value){
        if(checkValue(document.querySelector('#birth-date').value, document.querySelector('#birth-date'))){
            myEmployee.birthday = document.querySelector('#birth-date').value;
            updateRow();
            if(document.querySelector('#invalid-birthday')){
                document.querySelector('#invalid-birthday').remove();
            }
        }
        else{
            displayInvalid(document.querySelector('#birth-date'), 'invalid-birthday');
        }
    }
    if(myEmployee.salary !== document.querySelector('#salary').value){
        if(checkValue(document.querySelector('#salary').value, document.querySelector('#salary'))&&
            myEmployee.salary <= document.querySelector('#salary').value){
            myEmployee.salary = document.querySelector('#salary').value;
            updateRow();
            if(document.querySelector('#invalid-salary')){
                document.querySelector('#invalid-salary').remove();
            }
        }
        else{
            displayInvalid(document.querySelector('#salary'), 'invalid-salary');
        }
    }
}

// Enregistrer les infos
const btnSave = document.querySelector("#btn-save");
btnSave.addEventListener('click', saveInfo);




