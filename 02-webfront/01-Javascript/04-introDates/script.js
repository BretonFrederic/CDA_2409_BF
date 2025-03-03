let resultat = document.querySelector("#resultat");
let btnCalculer = document.querySelector("#btn-calculer");
let container = document.querySelector(".container");
const d1 = new Date();
let astroResult = "";
let textAstro = false;
let signeAstroUtilisateur = "";

btnCalculer.addEventListener('click', ()=>{
    // Recupere la date choisie par l'utilisateur
    const dateUtilisateur = document.querySelector("#date").value;

    if(dateUtilisateur != ""){
        // Changer la chaine de caracteres dateUtilisateur au format Date()
        const d2 = new Date(dateUtilisateur);

        // Calculer la difference entre la dateActuelle et la dateAnniversaire
        const dateDiff = d1 - d2;
        if(dateDiff < 0){
            // Supprimer si créé balise p message signe astrologique
            if(textAstro == true){
                document.querySelector("#astro-result").remove();
                textAstro = false;
            }
            resultat.innerHTML = "Erreur la date renseignée doit être dans le passé.";
        }
        else{
            // Calculer nombre d'années écoulées
            // Millisecondes/1000 -> secondes | secondes/60 -> minutes | minutes/60 -> heures | heures/24 -> jours | jours/365,25 -> années
            const anneeDiff = dateDiff/1000/60/60/24/365.25;

            // Math.floor arrondir années complètes (-5.1 -> -6 / 10.60 -> 10)
            resultat.innerHTML = "Vous êtes né le : <span class='color-blue-bold'>" + d2.toLocaleDateString("fr") + "</span> à <span class='color-blue-bold'>" + d2.toLocaleTimeString() +
            ".</span><br><br>Il s'est écoulé " + Math.floor(anneeDiff) + " année(s) depuis votre naissance";

            // Selectionner le signe astrologique

            //-------Capricorne----------------
            if((d2.getMonth()==11 && d2.getDate() >= 22) || (d2.getMonth()==0 && d2.getDate() <= 19)){
                signeAstroUtilisateur = "Capricorne";
            }

            //-------Verseau----------------
            if((d2.getMonth()==0 && d2.getDate() >=20) || (d2.getMonth()==1 && d2.getDate() <=18)){
                    signeAstroUtilisateur = "Verseau";
            }
            
            //-------Poissons----------------
            if((d2.getMonth()==1 && d2.getDate() >= 19) || (d2.getMonth()==2 && d2.getDate() <= 20)){
                signeAstroUtilisateur = "Poissons";
            }

            //-------Bélier----------------
            if((d2.getMonth()==2 && d2.getDate() >= 21) || (d2.getMonth()==3 && d2.getDate() <= 19)){
                signeAstroUtilisateur = "Bélier";
            }

            //-------Taureau----------------
            if((d2.getMonth()==3 && d2.getDate() >= 20) || (d2.getMonth()==4 && d2.getDate() <= 20)){
                signeAstroUtilisateur = "Taureau";
            }

            //-------Gémeaux----------------
            if((d2.getMonth()==4 && d2.getDate() >= 21) || (d2.getMonth()==5 && d2.getDate() <= 20)){
                signeAstroUtilisateur = "Gémeaux";
            }

            //-------Cancer----------------
            if((d2.getMonth()==5 && d2.getDate() >= 21) || (d2.getMonth()==6 && d2.getDate() <= 22)){
                signeAstroUtilisateur = "Cancer";
            }

            //-------Lion----------------
            if((d2.getMonth()==6 && d2.getDate() >= 23) || (d2.getMonth()==7 && d2.getDate() <= 22)){
                signeAstroUtilisateur = "Lion";
            }

            //-------Vierge----------------
            if((d2.getMonth()==7 && d2.getDate() >= 23) || (d2.getMonth()==8 && d2.getDate() <= 22)){
                signeAstroUtilisateur = "Vierge";
            }

            //-------Balance----------------
            if((d2.getMonth()==8 && d2.getDate() >= 23) || (d2.getMonth()==9 && d2.getDate() <= 22)){
                signeAstroUtilisateur = "Balance";
            }

            //-------Scorpion----------------
            if((d2.getMonth()==9 && d2.getDate() >= 23) || (d2.getMonth()==10 && d2.getDate() <= 21)){
                signeAstroUtilisateur = "Scorpion";
            }

            //-------Sagittaire----------------
            if((d2.getMonth()==10 && d2.getDate() >= 22) || (d2.getMonth()==11 && d2.getDate() <= 21)){
                signeAstroUtilisateur = "Sagittaire";
            }

            // Ajouter une balise p pour afficher le signe astrologique
            if(textAstro === false){
                astroResult = document.createElement('p');
                astroResult.setAttribute("id", "astro-result");
                container.appendChild(astroResult); 
                astroResult.style.borderTop='2px solid black';
                astroResult.style.paddingTop='20px';
            }
            document.querySelector("#astro-result").innerHTML = "Votre signe astrologique : <span class='color-blue-bold'>" + signeAstroUtilisateur + " </span>.";
            textAstro = true;

            // Style quand affichage résultat
            resultat.style.borderTop='2px solid black';
            resultat.style.paddingTop='20px';
            resultat.style.paddingBottom='20px';
        }
    }
    else{
        // Supprimer si créé balise p message signe astrologique
        if(textAstro == true){
            document.querySelector("#astro-result").remove();
            textAstro = false;
        }
        resultat.textContent = "Sélectionner une date dans le passé.";
    }
});