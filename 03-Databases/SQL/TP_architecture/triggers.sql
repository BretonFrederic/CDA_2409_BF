USE db_architecte;

-- Création de la table Erreur
CREATE TABLE Erreur
(id TINYINT UNSIGNED AUTO_INCREMENT PRIMARY KEY, erreur VARCHAR(255) UNIQUE);

-- Insertion de l'erreur qui nous intéresse
INSERT INTO Erreur (erreur)
VALUES
('Erreur : la date de fin prévue doit être > Date actuelle');

-- Création du trigger conditions erreur sur projet_date_fin_prevue
DELIMITER |
CREATE TRIGGER before_insert_projet BEFORE INSERT
ON projets FOR EACH ROW
BEGIN
	IF NEW.projet_date_fin_prevue  IS NOT NULL
    AND NEW.projet_date_fin_prevue <= NOW()
		THEN
			INSERT INTO Erreur (erreur)
            VALUES
            ('Erreur : la date de fin prévue doit être > Date actuelle');
	END IF;
END |
DELIMITER ;

-- DROP TRIGGER before_insert_projet;

-- Insertion du nouveau projet avec date invalide
INSERT INTO projets(   projet_ref, projet_date_depot, projet_date_fin_prevue, projet_date_fin_effective,projet_superficie_totale, projet_superficie_batie,
    projet_prix, client_ref, emp_matricule, adresse_id, type_travaux_id, type_projet_id )
    VALUES
    ('6', '2024-11-02', '2025-01-12', '2025-02-27', '400', '150', '8580.88', '4', '1', '1', '1', '1');
    
-- DELETE FROM projets WHERE projet_ref = '6';