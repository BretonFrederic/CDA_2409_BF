let resultat = document.querySelector("#resultat");
let btnValider = document.querySelector("#btn-valider");
const d1 = new Date();

btnValider.addEventListener('click', function(){
    // Recupere la date choisie par l'utilisateur
    const dateUtilisateur = document.querySelector("#date").value;

    if(dateUtilisateur != ""){
        // Changer la chaine de caracteres dateUtilisateur au format Date()
        const d2 = new Date(dateUtilisateur);

        // Calculer la difference entre la dateActuelle et la dateAnniversaire
        const dateDiff = d1.getTime() - d2.getTime();
        if(dateDiff < 0){
            console.log("Erreur la date renseignée doit être dans le passé.");
        }
        else{
            // Calculer nombre d'années écoulées
            // Millisecondes/1000 -> secondes | secondes/60 -> minutes | minutes/60 -> heures | heures/24 -> jours | jours/365,25 -> années
            const anneeDiff = ((((dateDiff/1000)/60)/60)/24)/365.25;

            console.log("Vous êtes né le : " + d2.toLocaleDateString("fr") + " à " + d2.toLocaleTimeString());

            // Math.floor arrondir années complètes (-5.1 -> -6 / 10.60 -> 10)
            console.log("Il s'est écoulé " + Math.floor(anneeDiff) + " depuis votre naissance");
        }
    }
    else{
        console.log("Selectionner une date dans le passé.");
    }
});