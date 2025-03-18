const myTbody = document.querySelector("#body-table");
const btnAdd = document.querySelector("#btn-add");
const failinGrade = 12;
let studentsData = [];

async function downloadJson() {
    try {
        const url = "./eval.json";
        const response = await fetch(url); 
        if(!response.ok){
            throw new Error(`Reponse status : ${response.status}`);
        }
        const json = await response.json();
        studentsData = json;

        await addSudent(studentsData);
        
        console.log(studentsData);

        await addRow(myTbody, studentsData, failinGrade);
        await displayInfo(studentsData, failinGrade);

    } catch (error) {
        console.log(error.message);
    }   
}

async function addRow(tBody, jsonData, fGrade){
    tBody.innerHTML = "";
    const myData = jsonData.sort((a, b) => b.grade - a.grade);
    myData.forEach(student => {
        const tRow = tBody.insertRow();
        const name = student.fullname.split(" ");
        addCell(tRow, name[0]);
        addCell(tRow, name[1]);
        addCell(tRow, student.grade);
        if(student.grade < fGrade){
            addCell(tRow, "Non");
        }
        else{
            addCell(tRow, "Oui");
        }
    });
}

function addCell(tRow, text){
    const tdCell = tRow.insertCell();
    tdCell.textContent = text;
    tdCell.setAttribute("style", "border: 2px solid var(--color5); background-color: var(--color4); padding: 5px;");

}

async function displayInfo(jsonData, fGrade) {
    const nbStudents = document.querySelector("#nb-students");
    const avg = document.querySelector("#avg");
    const aboveAvg = document.querySelector("#above-avg");
    const failure = document.querySelector("#failure");
    nbStudents.textContent = `Nombre d'étudiants : ${jsonData.length}`;
    let sum=0;
    jsonData.forEach(student => {
        sum += student.grade;
    });
    const avgGrades = (sum/jsonData.length).toFixed(2);
    let nbAboveAvg = 0;
    jsonData.forEach(student => {
        if(student.grade > avgGrades){
            nbAboveAvg++;
        }
    });
    avg.textContent = `Moyenne de la classe : ${avgGrades}`;
    aboveAvg.textContent = `Nombre d'étudiants au dessus de la moyenne : ${nbAboveAvg}`;
    failure.textContent = `Note éliminatoire : ${fGrade}`;
}

async function addSudent(jsonData){
    btnAdd.addEventListener('click', ()=>{
        const regexName = /^[a-zàâäéèêëïîôöùûüÿç]{2,20}\s[a-zàâäéèêëïîôöùûüÿç]{2,20}$/i;
        let newStudentName = document.querySelector("#name").value;
        let newStudentGrade = document.querySelector("#grade").value;
        newStudentGrade = parseFloat(newStudentGrade);
        if(newStudentName.match(regexName) && newStudentGrade >= 0 && newStudentGrade <= 20){
            const name = newStudentName.split(" ");
            // const lName = name[0].charAt(0).toUpperCase()+name[0].substring(1);
            const lName = name[0].slice(0,1).toUpperCase()+name[0].slice(1).toLowerCase();
            const fName = name[1].slice(0,1).toUpperCase()+name[1].slice(1).toLowerCase();
            newStudentName = `${lName} ${fName}`;
            jsonData.push({ "fullname": newStudentName, "grade": newStudentGrade });
            console.log(studentsData);
        }
        // Mise à jour affichage
        addRow(myTbody, jsonData, failinGrade);
        displayInfo(jsonData, failinGrade);
    });
}

downloadJson();