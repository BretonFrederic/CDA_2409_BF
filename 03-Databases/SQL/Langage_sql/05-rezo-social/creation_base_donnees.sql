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
    nom_utilisateur VARCHAR(32) NOT NULL UNIQUE,
    email VARCHAR(128) UNIQUE NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE publication
(
	pub_id INT AUTO_INCREMENT,
    pub_date DATETIME NOT NULL,
    pub_titre VARCHAR(255) NOT NULL,
    pub_contenu TEXT NOT NULL,
    id INT,
    PRIMARY KEY(pub_id),
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

/* AJOUTER LES CLES ETRANGERES EN DEHORS DES TABLES PERMET DE CREER LES TABLES SANS RESPECT UN ORDRE DE CREATION */

/* Modifier la table publication et y ajouter une clé étrangère */
/* ALTER TABLE publication ADD FOREIGN KEY (id) REFERENCES utilisateur(id); */

/* Modifier la table aimer ajouter et retirer clé étrangère */
/* ALTER TABLE aimer ADD CONSTRAINT fk_aimer_utilisateur FOREIGN KEY(id) REFERENCES utilisateur(id); */
/* ALTER TABLE aimer ADD CONSTRAINT fk_aimer_publication FOREIGN KEY(pub_id) REFERENCES publication(pub_id); */

/* ALTER TABLE aimer DROP CONSTRAINT fk_aimer_utilisateur; */