/* Supprimer base de données si elle existe */
DROP DATABASE IF EXISTS rezo_social;

/* Création base de données */
CREATE DATABASE IF NOT EXISTS rezo_social;

/* Sélectionner la database */
USE rezo_social;

/* Création des tables */
CREATE TABLE utilisateur
(
	id INT,
    nom_utilisateur VARCHAR(32) NOT NULL,
    email VARCHAR(128) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE publication
(
	pub_id INT AUTO_INCREMENT,
    pub_date DATETIME NOT NULL,
    pub_titre VARCHAR(255) NOT NULL,
    pub_contenu TEXT NOT NULL,
    PRIMARY KEY(pub_id),
    id INT,
    FOREIGN KEY(id) REFERENCES utilisateur(id)
);

CREATE TABLE aimer
(
	id INT,
    pub_id INT,
    PRIMARY KEY(id, pub_id),
    FOREIGN KEY(id) REFERENCES utilisateur(id),
    FOREIGN KEY(pub_id) REFERENCES publication(pub_id)
);