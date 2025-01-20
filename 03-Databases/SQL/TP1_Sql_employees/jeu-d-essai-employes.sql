-- UTILISATION DE LA BASE DE DONNEES
USE employes;

-- INSERER VALEURS
INSERT INTO dept
(deptno, dname, loc)
VALUES
(10, 'accounting', 'NEW YORK'),
(20, 'research', 'DALLAS'),
(30, 'sales', 'CHICAGO'),
(40, 'operations', 'BOSTON');

INSERT INTO emp
(empno, ename, job, mgr, hiredate, sal, comm, deptno)
VALUES
(7369 ,'Smith' , 'clerk',7902 , '1980-12-17', 800, NULL, 20),
(7499 ,'Allen' , 'salesman',7698 , '1981-02-20', 1600, 300, 30),
(7521 ,'Ward' , 'salesman',7698 , '1981-02-22', 1250, 500, 30),
(7566 ,'Jones' , 'manager',7839 , '1981-04-02', 2975, NULL, 20),
(7654 ,'Martin' , 'salesman',7698 , '1981-11-28', 1250, 1400, 30),
(7698 ,'Blake' , 'manager',7839 , '1981-05-01', 2850, NULL, 30),
(7782 ,'Clark' , 'manager',7839 , '1981-06-09', 2450, NULL, 10),
(7788 ,'Scott' , 'analyst',7566 , '1982-12-09', 3000, NULL, 20),
(7839 ,'King' , 'president', NULL, '1981-11-17', 5000, NULL, 10),
(7844 ,'Turner' , 'salesman', 7698, '1981-09-08', 1500, 0, 30),
(7876 ,'Adams' , 'clerk', 7788, '1983-01-12', 1100, NULL, 20),
(7900 ,'James' , 'clerk', 7698, '1981-12-03', 950, NULL, 30),
(7902 ,'Ford' , 'analyst', 7566, '1981-12-03', 3000, NULL, 20),
(7934 ,'Miller' , 'clerk', 7782, '1982-01-23', 1300, NULL, 10);