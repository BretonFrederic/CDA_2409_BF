let inputPrenom = document.querySelector('#prenom');
let inputAge = document.querySelector('#age');
let btnValidation = document.querySelector('#btn-validation');
let resultat = document.querySelector('#resultat').firstElementChild;
let btnVider = document.querySelector('#btn-vider');

btnValidation.addEventListener('click', function(){
    let statusPersonne = "";
    let messageRetraite = "";
    if(prenom.value != "" && inputAge.value > 0){
        if(inputAge.value >= 18){
            statusPersonne = "majeur";
        }
        else{
            statusPersonne = "mineur";
        }
        if(inputAge.value < 64){
            let diff = 64 - inputAge.value; 
            messageRetraite = "Il vous reste <span class='color-blue-bold'>" + diff + "</span> année(s) avant la retraite.";
        }else if(inputAge.value > 64){
            let diff = inputAge.value - 64; 
            messageRetraite = "Vous êtes à la retraite depuis <span class='color-blue-bold'>" + diff + "</span> année(s).";
        }else if(inputAge.value = 64){
            messageRetraite = "Vous prenez votre retraite cette année !";
        }
        resultat.innerHTML = "Bonjour <span class='color-blue-bold'>" + prenom.value + "</span>, votre âge est : <span class='color-blue-bold'>" + inputAge.value + "</span>." + 
        "<br><br>Vous êtes : <span class='color-blue-bold'>" + statusPersonne + "</span>." + 
        "<br><br>" + messageRetraite;

    }
    else{
        resultat.innerHTML = "Compléter/Corriger le formulaire.";
    }
})