// Récupérer le boutton connexion
const logIn = document.querySelector("#connection");

// Stocker l'utilisateur connecté
let currentUser;

// Fonction qui vérifie si identifiant est correct renvoie une booléen
function checkId(usersList, employeeId){
    let isValid = false;
    usersList.forEach(element => {
        const user = `${element.firstname}.${element.lastname}`.normalize("NFD").replace(/[\u0300-\u036f]/g, '').toLowerCase();
        if(employeeId == user){
            isValid = true;
            currentUser = element;
           
        }
    });
    return isValid;
}

// Fonction qui vérifie si mot de passe est correct renvoie une booléen
function checkPassword(usersList, passwordUser){
    let isValid = false;
    usersList.forEach(element => {
        if(passwordUser == element.password){
            isValid = true;
        }
    });
    return isValid;
}

// Fonction qui affiche un message d'erreur pendant 5 sescondes si identifiant ou mot de passe incorrect
function displayInvalid(myMsg){
    const errMsg = document.createElement("p");
    if(myMsg !== ""){
        errMsg.textContent = myMsg;
    }
    else{
        errMsg.textContent = "Identifiant ou mot de passe incorrect";
    }
    errMsg.setAttribute("id", "msg-invalid");
    errMsg.setAttribute("style", "padding: 12px 8px; margin: 0px 0px 5px 0px; color: #715B64; background-color: #c1ae9f; border: 2px solid #89937c;");
    document.querySelector("#title").appendChild(errMsg);
    setTimeout(function(){
        errMsg.remove();
    },5000);
}

// Fonction pour créer une session
function createSession(){
     // Créer div user-session
     const userArea = document.querySelector("#user-area");
     const userSession = document.createElement("div");
     userSession.setAttribute("id", "user-session");
     userArea.appendChild(userSession);

     // Créer div welcome
     const welcome = document.createElement("div");
     welcome.setAttribute("style", "display: flex; align-items: center;");
     userSession.appendChild(welcome);

     // Créer message de bienvenue
     const pMsg = document.createElement("p");
     pMsg.setAttribute("style", "margin-left: 4px;");
     pMsg.setAttribute("id", "welcome");
     pMsg.textContent = `Bonjour ${currentUser.firstname} ${currentUser.lastname}`;
     welcome.appendChild(pMsg);

     // Créer boutton déconnexion
     const btnlogOff = document.createElement("input");
     btnlogOff.setAttribute("type", "button");
     btnlogOff.setAttribute("id", "disconnection");
     btnlogOff.setAttribute("value", "Déconnexion");
     btnlogOff.setAttribute("style", "margin-left: 34px; width: 100px; height: 34px; cursor: pointer;");
     welcome.appendChild(btnlogOff);

     // Créer tableau des données employés
    const myTable = document.createElement("table");
    myTable.setAttribute("style", "border-collapse: collapse; margin: 24px 0px 24px 12px;");
    userSession.appendChild(myTable);

    const tHead = myTable.createTHead();
    const tRow = tHead.insertRow();

    // Cellules titres
    const titleArray = ["Nom", "Prénom", "Date de naissance", "Email", "Salaire"];

    // Function pour créer les cellules titres
    function addCellTitle(row, text){
        const titleCell = document.createElement("th");
        titleCell.setAttribute("style", "color: #715B64; font-weight: bold; padding: 5px; background-color: #c1ae9f; border: 3px solid #89937c; text-align: center;");
        titleCell.textContent = text;
        row.appendChild(titleCell);
    }

    // Ajouter les titres aux cellules
    titleArray.forEach(title => {
        addCellTitle(tRow, title);
    });

    // Créer le tBody
    const tBody = myTable.createTBody();

    // Function pour créer les cellules de données
    function addCellData(row, text, element){
        const dataCell = row.insertCell();
        if(element !== currentUser){
            dataCell.setAttribute("style", "color: #715B64; padding: 5px; background-color: #c1ae9f; border: 3px solid #89937c;");
        }
        else{
            dataCell.setAttribute("style", "color: #c1ae9f; font-weight: bold; padding: 5px; background-color: #715B64; border: 3px solid #89937c;");
        }
        dataCell.textContent = text;
    }

    // Ajouter les données aux cellules
    employeeList.forEach(element => {
        const myRow = tBody.insertRow();
        addCellData(myRow, element.lastname, element);
        addCellData(myRow, element.firstname, element);
        addCellData(myRow, element.birthday, element);
        let eMail = `${element.firstname}.${element.lastname}@example.com`;
        eMail = eMail.normalize("NFD").replace(/[\u0300-\u036f]/g, '').toLowerCase();
        addCellData(myRow, eMail, element);
        addCellData(myRow, `${element.salary} €`, element);
    });

     //
     const logOff = document.querySelector("#disconnection");
     logOff.addEventListener('click', disconnect);
}

function connect(){
    const inputId = document.querySelector("#identifier").value;
    const inputPassword = document.querySelector("#password").value;
    if(checkId(employeeList, inputId) === true && checkPassword(employeeList, inputPassword) === true){

        // Cacher le formulaire de connexion
        document.querySelector("#identification").setAttribute("style", "display:none;");

        // Vider les inputs
        document.querySelector("#identifier").value = "";
        document.querySelector("#password").value = "";

        // Créer une session
        createSession();

    }
    else{
        // Afficher message erreur
        displayInvalid("");
    }
}

function disconnect(){

    // Afficher le formulaire de connexion
    document.querySelector("#identification").setAttribute("style", "display:block;");

    // Supprimer la session utilisateur
    document.querySelector("#user-session").remove();
}



//
fetch("./data.json").then(response => {
    return response.json();
})
.then((data)=>{
    employeeList = data;
    logIn.addEventListener('click', connect);
})
.catch(error => displayInvalid(error));
