DROP DATABASE IF EXISTS type_check;

CREATE DATABASE type_check;

USE type_check;
/*
CREATE TABLE Personnes(
	id_per INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nom_per VARCHAR(255) NOT NULL,
    prenom_per VARCHAR (100) NOT NULL,
    numRue_per SMALLINT NOT NULL,
    cp_per INT NOT NULL,
    ville_per VARCHAR(150),
    CONSTRAINT CK_CP CHECK(cp_per BETWEEN 0 AND 95999)
);
*/
CREATE TABLE Vehicules(
	immatriculation CHAR(7) PRIMARY KEY,
    marque VARCHAR (50) NOT NULL,
    kilometrage FLOAT NOT NULL,
    datemisenservice DATE NOT NULL,
    id_per INT UNSIGNED NOT NULL,
    CONSTRAINT FK_personnes FOREIGN KEY (id_per) REFERENCES Personnes(id_per)
);