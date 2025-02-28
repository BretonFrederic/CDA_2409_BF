const btnAfficher = document.querySelector("#btn-afficher");
const container = document.querySelector(".container");
const resultatDate = document.querySelector("#resultat-date");

btnAfficher.addEventListener('click', function(){
    // Recuperer les inputs date et heure
    const dateActuelle = document.querySelector("#date").value;
    const timeActuelle = document.querySelector("#time").value;

    if(dateActuelle != "" && timeActuelle != ""){
        resultatDate.innerHTML = "Aujourd'hui nous sommes le <span class='color-blue-bold'>" + 
        new Date(dateActuelle).toLocaleDateString('fr') + 
        "</span>, l'heure courante est : <span class='color-blue-bold'>" + 
        timeActuelle + "</span>";
    }
    else{
        resultatDate.textContent = "Compléter la date et l'heure."
    }

    
});