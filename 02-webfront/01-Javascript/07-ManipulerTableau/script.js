const people = ['Mike Dev', 'John Makenzie', 'Léa grande'];
let listePersonnes = people;

// Recuperer le tbody
let tableauBody = document.querySelector("#tableau-body");

// Afficher une liste désordonnée des personnes de listePersonnes
let ul = document.querySelector('#listePersonnes');
listePersonnes.forEach(element => {
    let li = document.createElement('li');
    li.append(element);
    ul.appendChild(li);

    // Recupere le nom puis le prenom et generer email
    const maPersonne = element.split(" ");
    let prenom = maPersonne[0];
    let nom = maPersonne[1];
    let email = prenom+"."+nom+"@example.com";
    let supprimer = "X";
    const inscrit = [nom, prenom, email, supprimer];

    // Creer et afficher ligne du tableau avec valeurs des colonnes
    let tr = document.createElement('tr');
    tableauBody.appendChild(tr);

    inscrit.forEach(colonne => {
        let td = document.createElement('td');
        td.append(colonne);
        tr.appendChild(td);
        if(colonne === "X"){
            td.style.textAlign="center";
            td.style.fontWeight="bold";

            td.addEventListener('click', function supprimer(){
                tableauBody.deleteRow(tr.rowIndex-1);
            });
        }
        else{
            td.style.textAlign="left";
        }
    });
});