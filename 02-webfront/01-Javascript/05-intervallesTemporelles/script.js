const btnAfficherDate = document.querySelector("#btn-afficher");
const btnCalculerIntervalle = document.querySelector("#btn-calculer");
let dateActuelle = "";

btnAfficherDate.addEventListener('click', function Afficher(){
    let dateDuJour = new Date().toISOString().split('T')[0];
    let timeFormat = new Intl.DateTimeFormat("fr-FR", {hour:"2-digit", minute:"2-digit", second:"2-digit"});

    let heureDuJour = timeFormat.format(Date.now());
    document.querySelector("#date").value = dateDuJour;
    document.querySelector("#time").value = heureDuJour;

    let dateFormat = new Intl.DateTimeFormat("fr-FR", {dateStyle:"short"});
    dateDuJour = dateFormat.format(Date.now());

    document.querySelector("#resultat-date").innerHTML = "Aujourd'hui nous sommes le <span class='color-blue-bold'>" + 
    dateDuJour + "</span>, l'heure courante est : <span class='color-blue-bold'>" + heureDuJour + "</span>.";

    document.querySelector("#resultat-date").setAttribute("style", "border-top:2px solid black;" +
                                                          "border-bottom:2px solid black;" +
                                                          "padding: 16px 0px;");

    document.querySelector("#selection-form").style.display="block";
    dateActuelle = new Date();
    console.log(dateActuelle);
});

btnCalculerIntervalle.addEventListener('click', function CalculerIntervalle(){
    let dateSelect = document.querySelector("#datetime").value;
    const dateInter = new Date(dateActuelle) - new Date(dateSelect);
    const absInter = Math.abs(dateInter);

    const jours = Math.floor(absInter/(1000*60*60*24));
    const heures = Math.floor((absInter%(1000*60*60*24))/(1000*60*60));
    const minutes = Math.floor((absInter%(1000*60*60))/(1000*60));

    if(dateInter < 0){
        document.querySelector("#resultat-intervalle").innerHTML = "Dans " + jours + 
        " jours, " + heures + " heures et " + minutes + " minutes, nous seront le <span class='color-blue-bold'>" + 
        new Date(dateSelect).toLocaleDateString() + 
        " à " + new Date(dateSelect).toLocaleTimeString("fr", {hour:"2-digit", minute:"2-digit"}) + "</span>.";
    }
    else if(dateInter > 0){
        document.querySelector("#resultat-intervalle").innerHTML = "il y a " + jours + 
        " jours, " + heures + " heures et " + minutes + " minutes, nous étions le <span class='color-blue-bold'>" + 
        new Date(dateSelect).toLocaleDateString() + 
        " à " + new Date(dateSelect).toLocaleTimeString("fr", {hour:"2-digit", minute:"2-digit"}) + "</span>.";
    }

});