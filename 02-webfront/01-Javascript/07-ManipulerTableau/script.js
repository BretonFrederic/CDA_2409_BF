const people = ['Mike Dev', 'John Makenzie', 'Léa grande'];

let ul = document.querySelector('#listePersonnes');
people.forEach(element => {
    let li = document.createElement('li');
    li.append(element);
    ul.appendChild(li);
});

// Recupere le nom puis le prenom et generer email


const maPersonne = people[0].split(" ");
let prenom = maPersonne[0];
let nom = maPersonne[1];
let email = prenom+"."+nom+"@example.com";


// Afficher dans le tableau
let ligneTableau = document.querySelector("#ligne-tableau");
let td1 = document.createElement('td');
td1.append(nom);
ligneTableau.appendChild(td1);
let td2 = document.createElement('td');
td2.append(prenom);
ligneTableau.appendChild(td2);
let td3 = document.createElement('td');
td3.append(email);
ligneTableau.appendChild(td3);