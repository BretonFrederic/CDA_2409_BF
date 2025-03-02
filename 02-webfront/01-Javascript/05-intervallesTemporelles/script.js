const btnAfficherDate = document.querySelector("#btn-afficher");

btnAfficherDate.addEventListener('click', function(){
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
});