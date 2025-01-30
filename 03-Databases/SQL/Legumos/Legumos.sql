/* CREATION BASER DE DONNEE */

DROP DATABASE IF EXISTS legumos;

CREATE DATABASE legumos;

USE legumos;

/* CREATION DES TABLES */

CREATE TABLE Vegetables
(
	Id INT(11) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Variety VARCHAR(50) NOT NULL,
    PrimaryColor VARCHAR(20) NOT NULL,
    LifeTime INT(11) UNSIGNED NOT NULL,
    Fresh INT(1) DEFAULT(0) NOT NULL
);

CREATE TABLE Sales
(
	SaleId INT(11) PRIMARY KEY AUTO_INCREMENT,
    SaleDate DATE NOT NULL,
    SaleWeight INT(11) UNSIGNED NOT NULL,
    SaleUnitPrice DECIMAL(5,2) UNSIGNED NOT NULL,
    SaleActive INT(1) NOT NULL,
    Id INT(11),
    CONSTRAINT fk_Id FOREIGN KEY (Id) REFERENCES Vegetables(Id)
);


/* JEU D'ESSAI */

INSERT INTO Vegetables (Id, Name, Variety, PrimaryColor, LifeTime, Fresh)
VALUES
(1, 'apple',        'golden',   'green', 90, 0),
(2, 'banana',      'cavendish', 'yellow',10, 0),
(3, 'blueberries', 'bluecrop',  'green',  8, 1),
(4, 'cabbage',     'broccoli',    'green', 60, 0),
(5, 'carrot',     'de Colmar',     'orange', 60, 0),
(6, 'cherry',     'morceau',     'darkred', 20, 0),
(7, 'coconut',    'palmyre',    'brown',  30, 0),
(8, 'grape',      'aladin',    'green',  10, 1),
(9, 'kiwi',      'hayward',     'green',  40, 1),
(10, 'lemon',    'eureka',     'green',  30, 0),
(11, 'onion',    'Stuttgart',     'white',  90, 0);

ALTER TABLE Vegetables ADD COLUMN Price DECIMAL(5,2) UNSIGNED NOT NULL;

UPDATE Vegetables SET Price=2.5 WHERE Id=1;
UPDATE Vegetables SET Price=3.99 WHERE Id=2;
UPDATE Vegetables SET Price=2.99 WHERE Id=3;
UPDATE Vegetables SET Price=1.49 WHERE Id=4;
UPDATE Vegetables SET Price=1.59 WHERE Id=5;
UPDATE Vegetables SET Price=1.99 WHERE Id=6;
UPDATE Vegetables SET Price=3.95 WHERE Id=7;
UPDATE Vegetables SET Price=1.95 WHERE Id=8;
UPDATE Vegetables SET Price=2.45 WHERE Id=9;
UPDATE Vegetables SET Price=3.15 WHERE Id=10;
UPDATE Vegetables SET Price=1.25 WHERE Id=11;

INSERT INTO Sales (SaleDate, SaleWeight, SaleUnitPrice, SaleActive, Id)
VALUES
('2025-01-05', 2000, 2.1, 1, 1),
('2025-01-12', 500, 2.1, 1, 1),
('2025-01-15', 1500, 3.99, 1, 2),
('2025-01-19', 3000, 1.59, 1, 5),
('2025-01-23', 1000, 1.25, 1, 11);

/* REQUETES SQL */

-- 1 Sélectionner toutes les informations des légumes triés par nom du légume (ordre alphabétique).
SELECT Id, Name, Variety, PrimaryColor, LifeTime, Fresh, Price
FROM Vegetables
ORDER BY Name ASC;

-- 2 Sélectionner les nom et le prix des légumes. Pour chaque variété de légume, afficher le nombre de 
-- vente ainsi que le poids total vendu. Les légumes sont triés par nombre de ventes.
SELECT Name, CONCAT(ROUND(Price, 2), ' €') AS Prix_unitaire, COUNT(SaleId) AS Nombre_vente, CONCAT(ROUND(SUM(SaleWeight/1000), 2), ' Kg') AS Poids_total, CONCAT(ROUND(SUM(SaleUnitPrice*SaleWeight/1000), 2), ' €') AS Prix_total
FROM Vegetables
LEFT JOIN Sales
ON Vegetables.Id = Sales.Id
GROUP BY Vegetables.Id
ORDER BY Nombre_vente DESC;

-- 3 Sélectionner le nom, la variété, la couleur, le prix au kilo des légumes
-- a. dont le nom contient la chaine "on"
-- ou
-- b. dont la couleur principale est verte.
-- AFFICHER UNIQUEMENT LES LEGUMES CORRESPONDANT A AU MOINS L'UNE DES 2 CONDITIONS.
SELECT Name, Variety, PrimaryColor, Price
FROM Vegetables
WHERE Name LIKE '%on%' OR PrimaryColor='green';

-- 4 Sélectionner les légumes avec pour chaque légume :
-- a. Son nom.
-- b. Sa variété.
-- c. La somme totale des ventes pour la variété de ce légume.
-- d. Le poids moyen d'une vente.
-- e. Le poids et le prix de la vente la plus élevée.
SELECT Name, Variety, CONCAT(ROUND(SUM(SaleUnitPrice*SaleWeight/1000), 2), ' €') AS Prix_total, CONCAT(ROUND(AVG(SaleWeight/1000), 2),' Kg') AS Poids_moyen_vente, CONCAT(ROUND(MAX(SaleWeight/1000), 2) ,' Kg') AS Poids_plus_elevee, CONCAT(ROUND(MAX(SaleUnitPrice*SaleWeight/1000), 2), ' €') AS Prix_plus_elevee
FROM Vegetables
LEFT JOIN Sales
ON Vegetables.Id = Sales.Id
GROUP BY Vegetables.Id
ORDER BY Prix_total DESC;