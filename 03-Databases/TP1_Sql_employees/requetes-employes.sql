-- PREMIERE PARTIE
USE employes;
-- 1. Donner nom, job, numéro et salaire de tous les employés, puis seulement des employés du département 10
SELECT ename, job, empno, sal
FROM emp;

SELECT ename, job, empno, sal
FROM emp
WHERE deptno = 10;

-- 2. Donner nom, job et salaire des employés de type MANAGER dont le salaire est supérieur à 2800
SELECT ename, job, sal
FROM emp
WHERE job = 'manager' AND sal > 2800;

-- 3. Donner la liste des MANAGER n'appartenant pas au département 30
SELECT ename, job
FROM emp
WHERE job = 'manager' AND job <> 30;


-- 4. Liste des employés de salaire compris entre 1200 et 1400
SELECT ename, sal
FROM emp
-- WHERE sal >= 1200 AND sal <= 1400;
WHERE sal BETWEEN 1200 AND 1400;

-- 5. Liste des employés des départements 10 et 30 classés dans l'ordre alphabétique
SELECT ename, deptno
FROM emp
WHERE deptno IN (10, 30)
ORDER BY ename ASC;

-- 6. Liste des employés du département 30 classés dans l'ordre des salaires croissants
SELECT ename, deptno, sal
FROM emp
WHERE deptno = 30
ORDER BY sal ASC;

-- 7. Liste de tous les employés classés par emploi et salaires décroissants
SELECT ename, job, sal
FROM emp
ORDER BY job, sal DESC;


-- 8. Liste des différents emplois
/*SELECT DISTINCT(job)
FROM emp;*/
SELECT job, COUNT(empno)
FROM emp
GROUP BY job;

-- 9. Donner le nom du département où travaille ALLEN
SELECT dname
FROM emp
NATURAL JOIN dept
WHERE ename = 'Allen';

-- 10. Liste des employés avec nom du département, nom, job, salaire classés par noms de départements et par salaires décroissants.
SELECT dname, ename, job, sal
FROM emp
NATURAL JOIN dept
ORDER BY dname, sal DESC;
 
-- 11. Liste des employés vendeurs (SALESMAN) avec affichage de nom, salaire, commissions, salaire + commissions
SELECT ename, sal, comm, sal+comm AS salcomm
FROM emp
WHERE job = 'salesman';

-- 12. Liste des employés du département 20: nom, job, date d'embauche sous forme VEN 28 FEV 1997'
SET lc_time_names = 'fr_FR';
SELECT ename, job, UPPER(date_format(hiredate, "%a %d %b %Y"))
FROM emp
WHERE deptno = 20;

-- 13. Donner le salaire le plus élevé par département
SELECT MAX(sal), deptno
FROM emp
GROUP BY deptno;


-- 14. Donner département par département masse salariale, nombre d'employés, salaire moyen par type d'emploi.
SELECT SUM(sal + ifnull(comm,0)) AS masse_salariale, COUNT(ename) AS nbr_employes, round(AVG(sal), 2) AS salaire_moyen, deptno, job
FROM emp 
GROUP BY deptno, job order by deptno;


-- 15. Même question mais on se limite aux sous-ensembles d'au moins 2 employés
SELECT SUM(sal + ifnull(comm,0)) AS masse_salariale, COUNT(ename) AS nbr_employes, round(AVG(sal), 2) AS salaire_moyen, deptno, job
FROM emp 
GROUP BY deptno, job
HAVING COUNT(ename) >= 2
ORDER BY deptno;
 
-- 16. Liste des employés (Nom, département, salaire) de même emploi que JONES


-- 17. Liste des employés (nom, salaire) dont le salaire est supérieur à la moyenne globale des salaires


-- 18. Création d'une table PROJET avec comme colonnes numéro de projet (3 chiffres), nom de projet(5 caractères), budget. Entrez les valeurs suivantes:
-- 101, ALPHA, 96000
-- 102, BETA, 82000
-- 103, GAMMA, 15000

-- 19. Ajouter l'attribut numéro de projet à la table EMP et affecter tous les vendeurs du département 30 au projet 101, et les autres au projet 102


-- 20. Créer une vue comportant tous les employés avec nom, job, nom de département et nom de projet
-- 		OFP DI/M1S/C1/TP-07/01 Fichier : TP1_Sql_lmd_tp_enonces_vide (1).doc Page 4 sur 8


-- 21. A l'aide de la vue créée précédemment, lister tous les employés avec nom, job, nom de département 
-- 		et nom de projet triés sur nom de département et nom de projet


-- 22. Donner le nom du projet associé à chaque manager
