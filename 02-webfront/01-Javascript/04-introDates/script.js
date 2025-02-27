let resultat = document.querySelector("#resultat");
let btnCalculer = document.querySelector("#btn-calculer");
let container = document.querySelector(".container");
const d1 = new Date();

btnCalculer.addEventListener('click', function(){
    // Recupere la date choisie par l'utilisateur
    const dateUtilisateur = document.querySelector("#date").value;

    if(dateUtilisateur != ""){
        // Changer la chaine de caracteres dateUtilisateur au format Date()
        const d2 = new Date(dateUtilisateur);

        // Calculer la difference entre la dateActuelle et la dateAnniversaire
        const dateDiff = (d1.getTime() - d2.getTime());
        if(dateDiff < 0){
            resultat.innerHTML = "Erreur la date renseignée doit être dans le passé.";
            console.log("Erreur la date renseignée doit être dans le passé.");
        }
        else{
            // Calculer nombre d'années écoulées
            // Millisecondes/1000 -> secondes | secondes/60 -> minutes | minutes/60 -> heures | heures/24 -> jours | jours/365,25 -> années
            const anneeDiff = ((((dateDiff/1000)/60)/60)/24)/365.25;


            resultat.innerHTML = "Vous êtes né le : <span class='color-blue-bold'>" + d2.toLocaleDateString("fr") + "</span> à <span class='color-blue-bold'>" + d2.toLocaleTimeString() +
            ".</span><br><br>Il s'est écoulé " + Math.floor(anneeDiff) + " année(s) depuis votre naissance";
            console.log("Vous êtes né le : " + d2.toLocaleDateString("fr") + " à " + d2.toLocaleTimeString());

            // Math.floor arrondir années complètes (-5.1 -> -6 / 10.60 -> 10)
            console.log("Il s'est écoulé " + Math.floor(anneeDiff) + " depuis votre naissance");

            // Selectionner le signe astrologique
            //-------Capricorne----------------
            if(d2.getMonth()==0){
                if(d2.getDate() <= 19){
                    console.log("Capricorne");
                }
            //-------Verseau----------------
                else if(d2.getDate() >=20){
                    console.log("Verseau");
                }
            }
            else if(d2.getMonth()==1){
                if(d2.getDate() <= 18){
                    console.log("Verseau");
                }
            //-------Poissons----------------
                else if(d2.getDate() >= 19){
                    console.log("Poissons");
                }
            }
            else if(d2.getMonth()==2){
                if(d2.getDate() <= 20){
                    console.log("Poissons");
                }
            //-------Bélier----------------
                else if(d2.getDate() >= 21){
                    console.log("Bélier");
                }
            }

            // Ajouter une balise p pour afficher le signe astrologique
            let astroResult = document.createElement('p');
            astroResult.append("Votre signe astro...");
            container.appendChild(astroResult);

            // Style quand affichage résultat
            resultat.style.borderTop='2px solid black';
            resultat.style.paddingTop='20px';
            resultat.style.borderBottom='2px solid black';
            resultat.style.paddingBottom='20px';
        }
    }
    else{
        console.log("Selectionner une date dans le passé.");
    }
});