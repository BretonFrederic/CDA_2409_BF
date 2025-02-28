const btnValidation = document.querySelector('#btn-validation');
const resultat = document.querySelector('#resultat').firstElementChild;
const btnVider = document.querySelector('#btn-vider');
const regex = /^[A-Z]{0,1}[a-zàâäéèêëïîôöùûüÿç]{1,20}[-]{0,1}[a-zàâäéèêëïîôöùûüÿç]{0,20}$/;

btnValidation.addEventListener('click', ()=>{
    let prenom = document.querySelector("#prenom").value;
    let age = document.querySelector("#age").value;
    let statusPersonne = "";
    let messageRetraite = "";
    if(prenom.match(regex) && age > 0){
        if(age >= 18){
            statusPersonne = "majeur";
        }
        else{
            statusPersonne = "mineur";
        }
        if(age < 64){
            let diff = 64 - age; 
            messageRetraite = "Il vous reste <span class='color-blue-bold'>" + diff + "</span> année(s) avant la retraite.";
        }else if(age > 64){
            let diff = age - 64; 
            messageRetraite = "Vous êtes à la retraite depuis <span class='color-blue-bold'>" + diff + "</span> année(s).";
        }else if(age = 64){
            messageRetraite = "Vous prenez votre retraite cette année !";
        }
        resultat.innerHTML = "Bonjour <span class='color-blue-bold'>" + prenom + "</span>, votre âge est : <span class='color-blue-bold'>" + age + "</span>." + 
        "<br><br>Vous êtes : <span class='color-blue-bold'>" + statusPersonne + "</span>." + 
        "<br><br>" + messageRetraite;

    }
    else{
        resultat.innerHTML = "Compléter/Corriger le formulaire.";
    }
});

btnVider.addEventListener('click', ()=>{
    document.querySelector("#prenom").value = "";
    document.querySelector("#age").value = "";
    resultat.innerHTML = "Compléter/Corriger le formulaire.";
});