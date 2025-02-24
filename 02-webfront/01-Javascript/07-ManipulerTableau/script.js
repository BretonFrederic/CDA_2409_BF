const people = ['Mike Dev', 'John Makenzie', 'Léa grande'];
//let listeInscrits;

// Recuperer le tbody
let tableauBody = document.querySelector("#tableau-body");

// Afficher la liste des personnes de people
let ul = document.querySelector('#listePersonnes');
people.forEach(element => {
    let li = document.createElement('li');
    li.append(element);
    ul.appendChild(li);

    // Recupere le nom puis le prenom et generer email
    const maPersonne = element.split(" ");
    let prenom = maPersonne[0];
    let nom = maPersonne[1];
    let email = prenom+"."+nom+"@example.com";
    const inscrit = [nom, prenom, email];
    //listeInscrits.append(inscrit);

    // Creer et afficher ligne du tableau avec valeurs des colonnes
    let tr = document.createElement('tr');
    tableauBody.appendChild(tr);

    inscrit.forEach(colonne => {
        let td = document.createElement('td');
        td.append(colonne);
        tr.appendChild(td);
    });
});