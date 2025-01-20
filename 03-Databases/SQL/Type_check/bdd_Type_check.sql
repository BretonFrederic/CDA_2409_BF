-- ENONCE 1 ---------------------------------------------------------------------------

-- Personne {idPersonne, nom, prenom, numRue, rue, cp, ville}
-- Vehicule {immatriculation, marque, kilométrage, dateMiseEnService, #idPersonne}

-- ➢ Tous les attributs sont obligatoires
-- ➢ Code postal < 96000

DROP DATABASE IF EXISTS type_check01;

CREATE DATABASE type_check01;

USE type_check01;

CREATE TABLE Personnes
(
	id_per INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nom_per VARCHAR(255) NOT NULL,
    prenom_per VARCHAR (100) NOT NULL,
    numRue_per SMALLINT NOT NULL,
    cp_per INT NOT NULL,
    ville_per VARCHAR(150),
    CONSTRAINT CK_CP CHECK(cp_per BETWEEN 0 AND 95999)
);

CREATE TABLE Vehicules
(
	immatriculation CHAR(7) PRIMARY KEY,
    marque VARCHAR (50) NOT NULL,
    kilometrage FLOAT NOT NULL,
    datemisenservice DATE NOT NULL,
    id_per INT UNSIGNED NOT NULL,
    CONSTRAINT FK_personnes FOREIGN KEY (id_per) REFERENCES Personnes(id_per)
);

-- ENONCE 2 ---------------------------------------------------------------------------

-- Etudiant {idEtudiant, nom, prenom, dateEntree} 
-- Matiere {idMatiere, libMatiere, coefficient} 
-- Contrôle {idEtudiant, idMatiere, moyenne}

-- ➢ Pas de contraintes spécifiques
-- ➢ Le libellé de matière doit être unique

DROP DATABASE IF EXISTS type_check02;

CREATE DATABASE type_check02;

USE type_check02;

CREATE TABLE Etudiants01
(
	id_etud INT AUTO_INCREMENT PRIMARY KEY,
    nom_etud VARCHAR(255) NOT NULL,
    prenom_etud VARCHAR (100) NOT NULL,
    datentree_etud DATE NOT NULL
);

CREATE TABLE Matieres01
(
	id_mat INT AUTO_INCREMENT PRIMARY KEY,
    lib_mat VARCHAR (50) NOT NULL UNIQUE,
    coef_mat INT NOT NULL
);

CREATE TABLE Controle01
(
	id_etud INT,
    id_mat INT,
    cont_moy DECIMAL(4, 2),
    CONSTRAINT FK_ETUD FOREIGN KEY (id_etud) REFERENCES Etudiants01(id_etud),
    CONSTRAINT FK_MAT FOREIGN KEY (id_mat) REFERENCES Matieres01(id_mat)
);

-- ENONCE 3 ---------------------------------------------------------------------------

-- Etudiant {idEtudiant, nom, prenom, dateEentree} 
-- Matiere {idMatiere, libMatiere, coefficient} 
-- Contrôle {idEtudiant, idMatiere, date, moyenne}

-- ➢ Tous les attributs sont obligatoires
-- ➢ Moyenne < 20
-- ➢ Coefficient : Entier < 10
-- ➢ Date d'entrée par défaut = date du jour

DROP DATABASE IF EXISTS type_check03;

CREATE DATABASE type_check03;

USE type_check03;

CREATE TABLE Etudiants03
(
	id_etud INT AUTO_INCREMENT PRIMARY KEY,
    nom_etud VARCHAR(255) NOT NULL,
    prenom_etud VARCHAR (100) NOT NULL,
    datentree_etud DATETIME DEFAULT CURRENT_TIMESTAMP()
);

CREATE TABLE Matieres03
(
	id_mat INT AUTO_INCREMENT PRIMARY KEY,
    lib_mat VARCHAR (50) NOT NULL UNIQUE,
    coef_mat INT NOT NULL,
    CONSTRAINT CK_COEF CHECK(coef_mat <= 10)
);

CREATE TABLE Controle03
(
	id_etud INT,
    id_mat INT,
    cont_moy DECIMAL(4, 2) NOT NULL,
    CONSTRAINT FK_ETUD FOREIGN KEY (id_etud) REFERENCES Etudiants03(id_etud),
    CONSTRAINT FK_MAT FOREIGN KEY (id_mat) REFERENCES Matieres03(id_mat),
    CONSTRAINT CK_MOY CHECK(cont_moy <= 20)
);

-- ENONCE 4 ---------------------------------------------------------------------------

-- Livre {ISBN, titre}
-- Exemplaire {ISBN, numExemplaire, etat, ISBN}

-- ➢ Tous les attributs sont obligatoires
-- ➢ Etat = D : Disponible, E : Emprunté, P : Perdu – La valeur par défaut est D

CREATE TABLE Livres();