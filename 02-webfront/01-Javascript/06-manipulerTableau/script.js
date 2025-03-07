const people = ['Mike Dev', 'John Makenzie', 'Léa grande'];
const root = document.querySelector('div');

// Afficher une liste désordonnée des personnes de listePersonnes
const ul = document.querySelector('#people-list');

function displayPeopleList(){
    ul.innerHTML = "";
    people.forEach(element => {
        let li = document.createElement('li');
        li.textContent = element;
        ul.appendChild(li);
    });
}

displayPeopleList();

// Créer tableau
let myTable = document.createElement('table');
root.appendChild(myTable);
myTable.setAttribute('id', 'tableData');
myTable.setAttribute('cellSpacing', '0');
myTable.setAttribute('cellPadding', '10');
myTable.setAttribute('style', 'min-width:500px;')
myTable.style.backgroundColor='#637081';

// Créer en tete
function addCellTitle(row, text){
    let myCell = document.createElement('th');
    myCell.setAttribute('Style', 'border:1px solid #7C98B3; font-weight:bold; font-family:tahoma;');
    myCell.textContent = text;
    row.appendChild(myCell);
}

// Créer cellule
function addCell(row, text){
    let myCell = row.insertCell();
    myCell.setAttribute('Style', 'border:1px solid #7C98B3; font-family:times;');
    myCell.textContent = text;
    return myCell;
}

// remplir les th
const myHeader = myTable.createTHead();
const myTitleRow = myHeader.insertRow(); 
let tableTitle = ["nom", "prenom", "email", "supprimer"];

for (let i = 0; i < tableTitle.length; i++) {
    addCellTitle(myTitleRow, tableTitle[i]);
}

// function pour créer le tBody
function createTBody(userTable){
    if(document.querySelector("#tbody-users")){
        document.querySelector("#tbody-users").remove();
    }
    const myBody = userTable.createTBody();
    myBody.setAttribute('id', 'tbody-users');
    return document.querySelector("#tbody-users");
}

// Function pour ajouter des utilisateurs dans le tbody
function addRow(tableBody){
    console.log(people);
    for (let i = 0; i < people.length; i++) {
        const myRow = tableBody.insertRow();
        const myPerson = people[i].split(" ");
        let firstName = myPerson[0];
        let lastName = myPerson[1];

        let email=`${firstName}.${lastName}${"@example.com"}`;
        addCell(myRow, lastName);
        addCell(myRow, firstName);
        addCell(myRow, email);
        let rowSupp = addCell(myRow, "X");
        rowSupp.setAttribute('style', 'border:1px solid #7C98B3; font-family:Arial; font-weight:bold; text-align:center; cursor:pointer;');
        rowSupp.setAttribute('class', 'rowSupp');
    }
}

// Ajouter row au tbody
addRow(createTBody(myTable));

// Supprimer utilisateurs
myTable.addEventListener('click', function(event){
    if(event.target.classList.contains('rowSupp')){
        const usersBody = event.target.parentElement;
        let rowIndice = usersBody.rowIndex - 1;
        if (rowIndice >= 0) {
            people.splice(rowIndice, 1);
            document.querySelector("#tbody-users").deleteRow(rowIndice);
            displayPeopleList();
        }
    }
});

// let allRowSupp = document.querySelectorAll('.rowSupp');
// allRowSupp.forEach(element => {
//     element.addEventListener('click', function removeUser() {
//         console.log('click');
//         let myBodyTest = element.parentElement;
//         let rowIndice = myBodyTest.rowIndex - 1;       
//         if (rowIndice >= 0) {
//             people.splice(rowIndice, 1);
//             document.querySelector("#tbody-users").deleteRow(rowIndice);
//             displayPeopleList();
//         }
//     });
// });

// Ajouter utilisateurs
const btnAdd = document.querySelector('#btn-add');
btnAdd.setAttribute('style', 'cursor:pointer;');

btnAdd.addEventListener('click', function addUser(){
    const fName = document.querySelector('#firstname').value;
    const lName = document.querySelector('#lastname').value;
    people.push(`${fName} ${lName}`);
    console.log(people);
    displayPeopleList();
    addRow(createTBody(myTable));
    allRowSupp = document.querySelectorAll('.rowSupp');
});