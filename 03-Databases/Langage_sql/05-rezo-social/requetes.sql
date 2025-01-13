USE rezo_scial;

/* SELECTIONNER TOUTES LES VALEURS */
/*
SELECT * FROM utilisateur;
SELECT * FROM publication;
SELECT * FROM aimer;
*/

-- 1 Sélectionner tous les utilisateurs (nom d'utilisateur + email).
SELECT nom_utilisateur, email
FROM utilisateur;

-- 2 Sélectionner toutes les publications (titre, date, contenu, id utilisateur) triées par date de la plus récente à la plus ancienne.
SELECT pub_titre, pub_date, pub_contenu, id
FROM publication
ORDER BY pub_date DESC;

-- 3 Sélectionner les publications (pub_id, date, titre) de l'utilisateur N°2.
SELECT pub_id, pub_date, pub_titre, id
FROM publication
WHERE id = '2';

-- 4 Sélectionner les publications (pub_id, titre, contenu) dont le titre contient la lettre "a". Le résultat est trié par le titre et par ordre décroissant.
SELECT pub_id, pub_titre, pub_contenu
FROM publication
WHERE pub_titre LIKE "%a%" ORDER BY pub_titre DESC;

-- 5 Sélectionner les utilisateurs (id, nom, email) dont l'adresse email se termine par "com".
SELECT id, nom_utilisateur, email
FROM utilisateur
WHERE email LIKE "%com";

-- 6 Sélectionner les publications triées par titre (ordre alphabétique) avec le nom d'utilisateur de l'auteur (nécessite une jointure).
SELECT pub_id, pub_date, pub_titre, pub_contenu, nom_utilisateur
FROM publication
INNER JOIN utilisateur ON publication.id = utilisateur.id ORDER BY pub_titre;