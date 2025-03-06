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

// tBody
const myBody = myTable.createTBody();
for (let i = 0; i < people.length; i++) {
    const myRow = myBody.insertRow();
    const myPerson = people[i].split(" ");
    let firstName = myPerson[0];
    let lastName = myPerson[1];
    //let email = firstName+"."+lastName+"@example.com";

    let email=`${firstName}.${lastName}${"@example.com"}`;
    addCell(myRow, lastName);
    addCell(myRow, firstName);
    addCell(myRow, email);
    let rowSupp = addCell(myRow, "X");
    rowSupp.setAttribute('style', 'border:1px solid #7C98B3; font-family:Arial; font-weight:bold; text-align:center; cursor:pointer;');
    rowSupp.setAttribute('class', 'rowSupp');
}

const allRowSupp = document.querySelectorAll('.rowSupp');

allRowSupp.forEach(element => {
    element.addEventListener('click', function () {
        let myBodyTest = element.parentElement;
        let rowIndice = myBodyTest.rowIndex - 1;
        
        if (rowIndice >= 0) {
            people.splice(rowIndice, 1);
            myBody.deleteRow(rowIndice);
            displayPeopleList();
        }
    });
});