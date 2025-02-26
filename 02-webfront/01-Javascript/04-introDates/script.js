const inputDate = document.querySelector("#date").value;
const dateAnniversaire = inputDate;
let resultat = document.querySelector("#resultat");
let btnValider = document.querySelector("#btn-valider");
const dateActuelle = new Date();

// document.write("Vous êtes néé le : ");
// document.write(dateActuelle.getDate());

btnValider.addEventListener('click', function(){
    console.log(dateAnniversaire);
    console.log(dateActuelle.getTime());
});