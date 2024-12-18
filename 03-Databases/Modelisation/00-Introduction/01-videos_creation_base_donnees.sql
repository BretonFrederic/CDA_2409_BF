/* commentaire */
-- commentaire

/*
Création de la base de données
Sous langage : DDL / LDD
Data Definition Language
Langage de définition des données
Principales instructions :
CREATE = Créer une structure (DATABASE, TABLE, VIEW, PROCEDURE, TRIGGER, FUNCTION)
ALTER = Modifier une structure existante
DROP = Supprimer une structure existante
*/

/* SUPPRIMER LA BASE DE DONNEES SI ELLE EXISTE */

DROP DATABASE IF EXISTS videos;

/* CREER UNE BASE DE DONNEES NOMMEE "videos" */
-- CREATE DATABASE videos;
CREATE DATABASE IF NOT EXISTS videos;

/* SELECTIONNER/UTILISER LA BASE DE DONNEE CREEE */
USE videos;

-- Les requêtes qui suivent utiliseront
-- la base de données sélectionné ci-dessus

/* CREER UNE TABLE NOMMEE "realisateur" (type/longueur en premier puis ordre indifférent pour autres options)*/
CREATE TABLE realisateur
(
	realisateur_id INT AUTO_INCREMENT PRIMARY KEY,
    realisateur_nom VARCHAR(100) NOT NULL,
    realisateur_prenom VARCHAR(100) NOT NULL
);

/* CREER UNE TABLE NOMEE "acteur" FORMALISER CLEF PRIMAIRE*/
CREATE TABLE acteur
(
	acteur_id INT AUTO_INCREMENT,
    acteur_nom VARCHAR(100) NOT NULL,
    acteur_prenom VARCHAR(100) NOT NULL,
    PRIMARY KEY (acteur_id)
);

/* CREER UNE TABLE NOMMEE "film" */
CREATE TABLE IF NOT EXISTS film
(
	film_id INT AUTO_INCREMENT,
    film_titre VARCHAR(255) NOT NULL,
    film_duree SMALLINT NOT NULL,
    realisateur_id INT,
    PRIMARY KEY (film_id),
    FOREIGN KEY (realisateur_id) REFERENCES realisateur(realisateur_id)
);

/* CREER UNE TABLE NOMMEE "film_acteur" */
CREATE TABLE film_acteur
(
	film_id INT,
    acteur_id INT,
    PRIMARY KEY(film_id, acteur_id),
    FOREIGN KEY(film_id) REFERENCES film(film_id),
    FOREIGN KEY(acteur_id) REFERENCES acteur(acteur_id)
);