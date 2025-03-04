const btnAfficherDate = document.querySelector("#btn-afficher");
const btnCalculerIntervalle = document.querySelector("#btn-calculer");

// Fonction qui recupere et affiche la date du jour et l'heure
function Afficher(){
    let dateDuJour = new Date().toISOString().split('T')[0];

    let timeFormat = new Intl.DateTimeFormat("fr-FR", {hour:"2-digit", minute:"2-digit", second:"2-digit"});
    let heureDuJour = timeFormat.format(new Date());

    document.querySelector("#date").value = dateDuJour;
    document.querySelector("#time").value = heureDuJour;

    dateDuJour = new Date().toLocaleDateString("fr-FR",{year:'numeric', month:'long', day:'numeric'});

    document.querySelector("#resultat-date").innerHTML = "Aujourd'hui nous sommes le <span class='color-blue-bold'>" + 
    dateDuJour + "</span>, l'heure courante est : <span class='color-blue-bold'>" + heureDuJour + "</span>.";

    document.querySelector("#resultat-date").setAttribute("style", "border-top:2px solid black;" +
                                                          "border-bottom:2px solid black;" +
                                                          "padding: 16px 0px;");

    document.querySelector("#selection-form").style.display="block";
}

// Affiche toutes les secondes la date et l'heure
btnAfficherDate.addEventListener('click', ()=>{setInterval(Afficher, 1000)});

// Fonction qui calcul et affiche l'intervalle entre 2 dates
function CalculerIntervalle(){
    let dateSelect = document.querySelector("#datetime").value;
    const dateInter = new Date() - new Date(dateSelect);
    const absInter = Math.abs(dateInter);

    const jours = Math.floor(absInter/(1000*60*60*24));
    const heures = Math.floor((absInter%(1000*60*60*24))/(1000*60*60));
    const minutes = Math.floor((absInter%(1000*60*60))/(1000*60));

    if(dateInter < 0){
        document.querySelector("#resultat-intervalle").innerHTML = "Dans " + jours + 
        " jours, " + heures + " heures et " + minutes + " minutes, nous seront le <span class='color-blue-bold'>" + 
        new Date(dateSelect).toLocaleDateString("fr-FR",{year:'numeric', month:'long', day:'numeric'}) + 
        " à " + new Date(dateSelect).toLocaleTimeString("fr", {hour:"2-digit", minute:"2-digit"}) + "</span>.";
    }
    else if(dateInter > 0){
        document.querySelector("#resultat-intervalle").innerHTML = "il y a " + jours + 
        " jours, " + heures + " heures et " + minutes + " minutes, nous étions le <span class='color-blue-bold'>" + 
        new Date(dateSelect).toLocaleDateString("fr-FR", {year:'numeric', month:'long', day:'numeric'}) + 
        " à " + new Date(dateSelect).toLocaleTimeString("fr-FR", {hour:"2-digit", minute:"2-digit"}) + "</span>.";
    }

}

btnCalculerIntervalle.addEventListener('click', CalculerIntervalle);

