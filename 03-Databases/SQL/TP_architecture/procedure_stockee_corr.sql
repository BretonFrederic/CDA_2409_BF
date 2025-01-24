-- afficher les projets d'un architecte --- Pour un nom d'atchitecte en variable,  donner la reference des projets dont il est responsable (verifier sa fonction)
-- 
-- delimiter |
-- CREATE PROCEDURE RechercheProjets(IN nom_emp VARCHAR(50)) 
-- BEGIN
-- SELECT projet_ref,fonctions.fonction_nom
-- FROM projets
-- INNER JOIN employes ON projets.emp_matricule=employes.emp_matricule NATURAL JOIN fonctions
-- WHERE employes.emp_nom=nom_emp; 
-- END|
-- 
-- DELIMITER ;
-- 
-- SET @nom_employes:="roussotte";
-- 
-- CALL RechercheProjetsparArchitecte( @nom_employes);
-- CALL RechercheProjetsparArchitecte("Golay");
-- 
-- CALL RechercheProjets("Roussotte");

-- afficher_liste_projet_fonction



-- Créer une PROCEDURE stockée qui pour un nom de salarié renvoie
-- dans une variable le budget total des projets dont il est responsable, 
-- et renvoie 0 si pas de projet en responsabilité  

DELIMITER |
CREATE PROCEDURE budgetTotal(IN nom_emp VARCHAR(50), OUT totalBudget DECIMAL(10,2), OUT nbProjets INT)
BEGIN
SELECT fonctions.fonction_nom 
FROM fonctions
NATURAL JOIN employes
WHERE employes.emp_nom = nom_emp;

SELECT IFNULL(SUM(projet_prix),0) INTO totalBudget
FROM projets
INNER JOIN employes ON employes.emp_matricule = projets.emp_matricule
WHERE employes.emp_nom = nom_emp;

SELECT IFNULL(count(projet_ref),0) INTO nbProjets
FROM projets
INNER JOIN employes ON employes.emp_matricule = projets.emp_matricule
WHERE employes.emp_nom = nom_emp;

END|
DELIMITER ;

SET @nom := "Golay";

CALL budgetTotal(@nom, @montant, @nb);

SELECT @montant AS "Somme des projets";
SELECT @nb AS "Nombre de projets";

-- definir un variable qui sera le cumul des montants projets  @cumul_projet_test
-- definir une "stored procedure" qui en fonction du numero de projet choisi, ajoutera son montant au @cumul_projet_test pour avoir le montant global


DELIMITER |
CREATE PROCEDURE ajouterBudgetProj(IN numero_projet INT , INOUT cumul_projet DECIMAL(10,2) )
BEGIN
SELECT  (cumul_projet + projets.projet_prix) INTO cumul_projet FROM projets WHERE projet_ref= numero_projet; 

END|
DELIMITER ;



SELECT @cumul_projet3 AS  "depart";
 

CALL ajouterBudgetProj( 4, @cumul_projet3);

SELECT @cumul_projet3 AS  "resulat intérmediaire";

CALL ajouterBudgetProj( 2, @cumul_projet3);


SELECT @cumul_projet3 AS "resultat final";