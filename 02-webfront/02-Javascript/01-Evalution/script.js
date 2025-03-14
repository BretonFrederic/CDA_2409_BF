const myTbody = document.querySelector("#body-table");
const failinGrade = 12;

async function downloadJson() {
    try {
        const url = "./eval.json";
        const response = await fetch(url); 
        if(!response.ok){
            throw new Error(`Reponse status : ${response.status}`);
        }
        const json = await response.json();

        await addRow(myTbody, json, failinGrade);

        await displayInfo(json, failinGrade);
    } catch (error) {
        console.log(error.message);
    }   
}

async function addRow(tBody, jSon, fGrade){
    const myData = jSon.sort((a, b) => b.grade - a.grade);
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

async function displayInfo(jSon, fGrade) {
    const nbStudents = document.querySelector("#nb-students");
    const avg = document.querySelector("#avg");
    const aboveAvg = document.querySelector("#above-avg");
    const failure = document.querySelector("#failure");
    nbStudents.textContent = `Nombre d'étudiants : ${jSon.length}`;
    let sum=0;
    jSon.forEach(student => {
        sum += student.grade;
    });
    const avgGrades = sum/jSon.length;
    let nbAboveAvg = 0;
    jSon.forEach(student => {
        if(student.grade > avgGrades){
            nbAboveAvg++;
        }
    });
    avg.textContent = `Moyenne de la classe : ${avgGrades}`;
    aboveAvg.textContent = `Nombre d'étudiants au dessus de la moyenne : ${nbAboveAvg}`;
    failure.textContent = `Note éliminatoire : ${fGrade}`;
}

downloadJson();