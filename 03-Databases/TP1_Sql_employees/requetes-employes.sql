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
GROUP BY deptno, job 
ORDER BY deptno;


-- 15. Même question mais on se limite aux sous-ensembles d'au moins 2 employés
SELECT SUM(sal + ifnull(comm,0)) AS masse_salariale, COUNT(ename) AS nbr_employes, round(AVG(sal), 2) AS salaire_moyen, deptno, job
FROM emp 
GROUP BY deptno, job
HAVING COUNT(ename) >= 2
ORDER BY deptno;
 
-- 16. Liste des employés (Nom, département, salaire) de même emploi que JONES
SELECT ename, deptno, sal
FROM emp
WHERE job = (
SELECT job
FROM emp
WHERE ename = 'Jones'
);

-- 17. Liste des employés (nom, salaire) dont le salaire est supérieur à la moyenne globale des salaires
SELECT ename, sal, deptno
FROM emp
WHERE sal > (
SELECT AVG(sal)
FROM emp
);


-- 18. Création d'une table PROJET avec comme colonnes numéro de projet (3 chiffres), nom de projet(5 caractères), budget. Entrez les valeurs suivantes:
-- 101, ALPHA, 96000
-- 102, BETA, 82000
-- 103, GAMMA, 15000
CREATE TABLE projet (
num_proj SMALLINT AUTO_INCREMENT,
nom_proj CHAR(5) NOT NULL,
budjet_proj DECIMAL(8,2) NOT NULL, CONSTRAINT PK_projet PRIMARY KEY(num_proj)
);


 ALTER TABLE projet AUTO_INCREMENT = 101;

INSERT INTO projet 
(nom_proj, budjet_proj)
VALUES
('alpha',96000),
('beta',82000),
('gamma',15000);

ALTER TABLE projet RENAME COLUMN budjet_proj TO budget_proj;

-- 19. Ajouter l'attribut numéro de projet à la table EMP et affecter tous les vendeurs du département 30 au projet 101, et les autres au projet 102

ALTER TABLE EMP ADD num_proj SMALLINT;

UPDATE emp SET num_proj = 101
WHERE deptno = 30 AND job = 'salesman';

UPDATE emp SET num_proj = 102
WHERE   (deptno=30 and job<>'salesman') xor deptno<>30 ;

update emp set num_proj =102 where empno!=all(select empno where deptno = 30 AND job = 'salesman'); 


-- update emp set  num_proj=null; 
ALTER TABLE emp ADD CONSTRAINT fk_proj FOREIGN KEY (num_proj) REFERENCES projet(num_proj);

-- 20. Créer une vue comportant tous les employés avec nom, job, nom de département et nom de projet
CREATE VIEW projet_details AS
SELECT ename, job, dname, nom_proj
FROM emp
JOIN dept
  ON emp.deptno = dept.deptno
JOIN projet
  ON emp.num_proj = projet.num_proj;
  
SELECT * FROM projet_details;
-- DROP VIEW projet_details;

-- 21. A l'aide de la vue créée précédemment, lister tous les employés avec nom, job, nom de département 
-- 		et nom de projet triés sur nom de département et nom de projet
SELECT ename, job, dname, nom_proj
FROM projet_details
ORDER BY dname, nom_proj;

-- 22. Donner le nom du projet associé à chaque manager
SELECT ename, job, dname, nom_proj
FROM projet_details
WHERE job = 'manager';

-- Deuxième partie ------------------------------------------------------------------------------------------

-- 1. Afficher la liste des managers des départements 20 et 30
SELECT ename
FROM emp
WHERE job = (SELECT job WHERE job = 'manager' AND deptno IN(20, 30));

-- 2. Afficher la liste des employés qui ne sont pas manager et qui ont été embauchés en 81
SELECT ename, job, hiredate
FROM emp
WHERE ename = (SELECT ename WHERE job <> 'manager' AND date_format(hiredate, "%y") = '81');

-- 3. Afficher la liste des employés ayant une commission
SELECT ename, comm
FROM emp
WHERE comm <> 'NULL';

-- 4. Afficher la liste des noms, numéros de département, jobs et date d'embauche triés par Numero de 
-- Département et JOB les derniers embauches d'abord.
SELECT ename, deptno, job, hiredate
FROM emp
ORDER BY deptno, hiredate DESC;

-- 5. Afficher la liste des employés travaillant à DALLAS
SELECT ename, loc
FROM emp
JOIN dept ON emp.deptno = dept.deptno
WHERE loc = 'DALLAS';

-- 6. Afficher les noms et dates d'embauche des employés embauchés avant leur manager, avec le nom et
-- date d'embauche du manager.
SELECT emp_e.ename, emp_e.hiredate, emp_m.hiredate, emp_m.ename
FROM emp AS emp_e
JOIN emp AS emp_m ON emp_m.mgr = emp_e.empno
WHERE emp_e.hiredate < emp_m.hiredate;

-- 7. Lister les numéros des employés n'ayant pas de subordonné.
SELECT empno
FROM emp
WHERE mgr IS NULL;

-- 8. Afficher les noms et dates d'embauche des employés embauchés avant BLAKE.
SELECT ename, hiredate
FROM emp
WHERE hiredate < (SELECT hiredate
	FROM emp
	WHERE ename = 'Blake' 
);

-- 9. Afficher les employés embauchés le même jour que FORD.
SELECT ename
FROM emp
WHERE hiredate = (SELECT hiredate
	FROM emp
    WHERE ename = 'Ford'
)
AND ename <> 'Ford';

-- 10. Lister les employés ayant le même manager que CLARK.
SELECT ename
FROM emp
WHERE mgr = (SELECT mgr
	FROM emp
    WHERE ename = 'Clark'
)
AND ename <> 'Clark';

-- 11. Lister les employés ayant même job et même manager que TURNER.
SELECT ename, job, mgr
FROM emp
WHERE job = (SELECT job
	FROM emp
    WHERE ename = 'Turner'
)
AND ename <> 'Turner';

-- 12. Lister les employés du département RESEARCH embauchés le même jour que quelqu'un du 
-- département SALES.
SELECT ename, dname
FROM emp
JOIN dept
ON emp.deptno = dept.deptno
WHERE hiredate = (SELECT hiredate
    WHERE dname = 'sales'
    );

-- 13. Lister le nom des employés et également le nom du jour de la semaine correspondant à leur date
-- d'embauche.
SELECT ename, UPPER(date_format(hiredate, '%a')) AS day
FROM emp;

-- 14. Donner, pour chaque employé, le nombre de mois qui s'est écoulé entre leur date d'embauche et la
-- date actuelle.
SELECT ename, DATE_FORMAT(NOW(), '%Y-%m-%d') AS today, hiredate, TIMESTAMPDIFF(month, hiredate, DATE_FORMAT(NOW(),'%Y-%m-%d')) AS months_diff
FROM emp;

-- 15. Afficher la liste des employés ayant un M et un A dans leur nom.
SELECT ename AS contain_M_A
FROM emp
WHERE ename LIKE '%M%'AND ename LIKE '%A%';

-- 16. Afficher la liste des employés ayant deux 'A' dans leur nom.
SELECT ename AS contain_2_A
FROM emp
WHERE ename LIKE '%A%A%';

-- 17. Afficher les employés embauchés avant tous les employés du département 10.
SELECT ename, hiredate
FROM emp
WHERE hiredate < ANY (
	SELECT hiredate
    FROM emp
    WHERE deptno = 10
    );

-- 18. Sélectionner le métier où le salaire moyen est le plus faible.
SELECT ROUND(AVG(sal)) AS avg_sal
FROM emp
GROUP BY job
ORDER BY avg_sal ASC
LIMIT 1;

-- 19. Sélectionner le département ayant le plus d'employés.
SELECT dname, COUNT(empno) AS nbr_emp
FROM dept
JOIN emp
ON dept.deptno = emp.deptno
GROUP BY dname
ORDER BY nbr_emp DESC
LIMIT 1;

-- 20. Donner la répartition en pourcentage du nombre d'employés par département selon le modèle ci-dessous
-- Département Répartition en % 
----------- ---------------- 
-- 10 21.43 
-- 20 35.71 
-- 30 42.86
SELECT deptno, CONCAT(ROUND(COUNT(empno)/(SELECT COUNT(*) FROM emp)*100, 2), ' %') AS emp_perc
FROM emp
GROUP BY deptno;
