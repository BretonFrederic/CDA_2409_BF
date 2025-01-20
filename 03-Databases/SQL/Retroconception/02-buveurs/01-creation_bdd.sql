DROP DATABASE IF EXISTS buveurs;

CREATE DATABASE buveurs;

USE buveurs;

CREATE TABLE buveurs
(
	num_buv INT AUTO_INCREMENT,
    nom_buv VARCHAR(100) NOT NULL,
    prenom_buv VARCHAR(100) NOT NULL,
    ville_buv VARCHAR(200) NOT NULL,
    CONSTRAINT pk_buveurs PRIMARY KEY(num_buv)
);

CREATE TABLE commandes
(
	num_com INT AUTO_INCREMENT,
    date_com DATE NOT NULL,
    CONSTRAINT pk_commandes PRIMARY KEY(num_com),
    num_buv INT
);

CREATE TABLE lignes_de_commandes
(
	num_vin INT,
    num_com INT,
    quantite INT,
    CONSTRAINT pk_lignes_de_commandes PRIMARY KEY(num_vin, num_com)
);

CREATE TABLE vins
(
	num_vin INT AUTO_INCREMENT,
    cru VARCHAR(30) NOT NULL,
    millesime DATE NOT NULL,
    PRIMARY KEY(num_vin),
    num_vig INT
);

CREATE TABLE vignerons
(
	num_vigneron INT AUTO_INCREMENT,
    nom_vig VARCHAR(100) NOT NULL,
    prenom_vig VARCHAR(100) NOT NULL,
    ville_vig VARCHAR(200) NOT NULL,
    PRIMARY KEY(num_vigneron)
);

CREATE TABLE ressentis_vignerons_entre_eux
(
	num_vigneron_juge INT,
    num_vigneron_evaluer INT,
    critere_appreciation VARCHAR(50),
    PRIMARY KEY(num_vigneron_juge, num_vigneron_evaluer)
);

ALTER TABLE commandes ADD CONSTRAINT fk_commandes_num_buv FOREIGN KEY (num_buv) REFERENCES buveurs(num_buv);

ALTER TABLE lignes_de_commandes
	ADD CONSTRAINT fk_lignes_de_commandes_num_vin FOREIGN KEY (num_vin) REFERENCES vins(num_vin),
    ADD CONSTRAINT fk_lignes_de_commandes_num_com FOREIGN KEY (num_com) REFERENCES commandes(num_com);
    
ALTER TABLE vins ADD CONSTRAINT fk_vins_num_vigneron FOREIGN KEY(num_vig) REFERENCES vignerons(num_vigneron);

ALTER TABLE ressentis_vignerons_entre_eux
	ADD CONSTRAINT fk_ressenti_num_vigneron_juge FOREIGN KEY(num_vigneron_juge) REFERENCES vignerons(num_vigneron),
    ADD CONSTRAINT fk_ressenti_num_vigneron_evaluer FOREIGN KEY(num_vigneron_evaluer) REFERENCES vignerons(num_vigneron);