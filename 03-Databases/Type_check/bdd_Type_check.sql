-- ENONCE 1 ---------------------------------------------------------------------------
DROP DATABASE IF EXISTS type_check01;

CREATE DATABASE type_check01;

USE type_check01;

CREATE TABLE Personnes(
	id_per INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nom_per VARCHAR(255) NOT NULL,
    prenom_per VARCHAR (100) NOT NULL,
    numRue_per SMALLINT NOT NULL,
    cp_per INT NOT NULL,
    ville_per VARCHAR(150),
    CONSTRAINT CK_CP CHECK(cp_per BETWEEN 0 AND 95999)
);

CREATE TABLE Vehicules(
	immatriculation CHAR(7) PRIMARY KEY,
    marque VARCHAR (50) NOT NULL,
    kilometrage FLOAT NOT NULL,
    datemisenservice DATE NOT NULL,
    id_per INT UNSIGNED NOT NULL,
    CONSTRAINT FK_personnes FOREIGN KEY (id_per) REFERENCES Personnes(id_per)
);

-- ENONCE 2 ---------------------------------------------------------------------------
DROP DATABASE IF EXISTS type_check02;

CREATE DATABASE type_check02;

USE type_check02;

CREATE TABLE Etudiants(
	id_etud INT AUTO_INCREMENT PRIMARY KEY,
    nom_etud VARCHAR(255) NOT NULL,
    prenom_etud VARCHAR (100) NOT NULL,
    datentree_etud DATE NOT NULL
);

CREATE TABLE Matieres(
	id_mat INT AUTO_INCREMENT PRIMARY KEY,
    lib_mat VARCHAR (50) NOT NULL UNIQUE,
    coef_mat INT NOT NULL
);

CREATE TABLE Controle(
	id_etud INT,
    id_mat INT,
    cont_moy DECIMAL(4, 2),
    CONSTRAINT FK_ETUD FOREIGN KEY (id_etud) REFERENCES Etudiants(id_etud),
    CONSTRAINT FK_MAT FOREIGN KEY (id_mat) REFERENCES Matieres(id_mat)
);