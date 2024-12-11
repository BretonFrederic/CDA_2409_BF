/* commentaire */
-- commentaire

/* SUPPRIMER LA BASE DE DONNEES SI ELLE EXISTE */

DROP DATABASE IF EXISTS videos;
CREATE DATABASE IF NOT EXISTS videos;

/* UTILISER LA BASE DE DONNEE CREEE */
USE videos;

-- Les requêtes qui suivent utiliseront
-- la base de données sélectionné ci-dessus

/* CREER UNE TABLE NOMMEE "film" */
CREATE TABLE IF NOT EXISTS film
(
	film_id INT AUTO_INCREMENT PRIMARY KEY,
    film_titre VARCHAR(255) NOT NULL,
    film_duree SMALLINT NOT NULL
);

/* INSERER LE JEU D'ESSAI DANS LA TABLE FILMS */
INSERT INTO film
VALUES
(NULL, 'Léon', 120),
(NULL, 'E.T', 90),
(NULL, 'ça', 103);

INSERT INTO film
(film_titre, film_duree)
VALUES
('Valérian', 130),
('Troie', 163),
('Gladiator 2', 117);

INSERT INTO film
(film_duree,film_titre)
VALUES
(136, 'Matrix');

/* AFFICHER LES DONNEES DE LA TABLE */
SELECT *
FROM film;