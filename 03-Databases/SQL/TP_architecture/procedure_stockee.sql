USE db_architecte;

/*Afficher les projets d'un architecte - Pour un nom d'architecte en variable donner le nom des projets et la référence des projets dont il est responsable (vérifier sa fonction)*/

DELIMITER |
CREATE PROCEDURE RechercheProjets( IN nom_emp VARCHAR(50))
BEGIN
	SELECT projet_ref, fonctions.fonction_nom
    FROM projets 
    INNER JOIN employes 
    ON projets.emp_matricule = employes.emp_matricule 
    NATURAL JOIN fonctions
    WHERE employes.emp_nom = nom_emp;
END |
DELIMITER ;

SET @nom_employes := "Roussotte";

CALL RechercheProjets(@nom_employes);
CALL RechercheProjetsParArchitecte("Golay");

-- Créer une procédure stockée qui pour un nom de salarié renvoie
-- dans une variable le budget total des projets dont il est responsable,
-- et renvoie 0 si pas de projet en responsabilité

DELIMITER |
CREATE PROCEDURE RechercheBudgetTotal(IN nom_emp VARCHAR(50), OUT totalBudget DECIMAL(10,2), OUT nbProjets INT)
BEGIN
	SELECT fonctions.fonction_nom
	FROM fonctions
    NATURAL JOIN employes
    WHERE employes.emp_nom = nom_emp;
    
	SELECT IFNULL(SUM(projet_prix), 0) INTO totalBudget
    FROM projets
    INNER JOIN employes ON employes.emp_matricule = projets.emp_matricule
    WHERE employes.emp_nom = nom_emp;
    
    SELECT IFNULL(COUNT(projet_ref), 0) INTO nbProjets
    FROM projets
    INNER JOIN employes ON employes.emp_matricule = projets.emp_matricule
    WHERE employes.emp_nom = nom_emp;
    
END |
DELIMITER ;

-- DROP PROCEDURE RechercheBudgetTotal;
SET @nom := "Golay";
CALL RechercheBudgetTotal(@nom, @montant, @nb);

SELECT @montant AS "Somme des projets";
SELECT @nb AS "Nombre de projets";

-- Définir une variable qui sera le cumul des montants projet @cumu_projet_test
-- Définir une stored procédure qui en fonction du numéro de projet choisit ajoutera son montant au cumul_projet_test pour avoir le montant global

DELIMITER |
CREATE PROCEDURE AjouterBudgetProj(IN numero_projet INT, INOUT cumul_projet DECIMAL(10,2))
BEGIN
	SELECT (cumul_projet + projets.projet_prix) INTO cumul_projet
    FROM projets
    WHERE projet_ref = numero_projet;
END |
DELIMITER ;

-- SET @cumul_projet_test := 0;
CALL AjouterBudgetProj(4, @cumul_projet_test);

SELECT @cumul_projet_test AS "résultat intermédiaire";

CALL AjouterBudgetProj(2, @cumul_projet_test);

SELECT @cumul_projet_test AS "résultat final";

-- Variable pas initialisée affichera null
CALL AjouterBudgetProj(4, @cumul_projet_test_2);

SELECT @cumul_projet_test_2 AS "résultat intermédiaire";

CALL AjouterBudgetProj(2, @cumul_projet_test_2);

SELECT @cumul_projet_test_2 AS "résultat final";