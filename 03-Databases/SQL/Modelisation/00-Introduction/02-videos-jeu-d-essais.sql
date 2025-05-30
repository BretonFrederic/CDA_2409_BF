/* 
INSERER LE JEU D'ESSAI DANS LA TABLE FILMS 
Sous langage : DML / LMD
Data Manipulation Langage
Langage de manipulation des données
Principales instructions :
INSERT : Ajouter des nouvelles données dans une table
UPDATE : Mettre à jour des données existantes dans une table
DELETE : Supprimer des données existantes dans une table
TRUNCATE : VIDER une table
*/

-- Sélectionner la base de données
USE videos;

-- DELETE FROM realisateur; -- supprimer toutes les données de la table realisateur
/*
TRUNCATE TABLE film_acteur; -- vider la table film_acteur et réinitialise l'auto_increment
TRUNCATE TABLE film; -- vider la table film et réinitialise l'auto_increment
TRUNCATE TABLE acteur; -- vider la table acteur et réinitialise l'auto_increment
TRUNCATE TABLE realisateur; -- vider la table realisateur et réinitialise l'auto_increment
*/
/* Insertion des données dans la table "realisateur" */

INSERT INTO realisateur
VALUES
(NULL, "Besson", "Luc"),
(NULL, "Spielberg", "Steven"),
(NULL, "Carpenter", "John");

INSERT INTO acteur
(acteur_nom, acteur_prenom)
VALUES
("Réno", "Jean"),
("Gibson", "Mel"),
("Watson", "Emma"),
("Green", "Eva"),
("Holland", "Tom");

INSERT INTO film
(film_titre, film_duree)
VALUES
("Léon", "103"),
("L'Arme fatale", "117"),
("Harry Potter : Retour à Poudlard", "102"),
("300 : La Naissance d'un Empire", "102"),
("Spider-Man: No Way Home", "150");