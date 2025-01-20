## TP_NoSQL 1 MongoDB
1. Donner nom, job, numéro et salaire de tous les employés, puis seulement des employés du département 10

   db.emp.find({deptno:10}, {ename:1, job:1, _id:1, sal:1, deptno:1})
   

2. Donner nom, job et salaire des employés de type MANAGER dont le salaire est supérieur à 2800

   db.emp.find({job:{$eq:"MANAGER"},sal:{$gt:2800}}, {ename:1, job:1, sal:1})
   

3. Donner la liste des MANAGER n'appartenant pas au département 30

   db.emp.find({deptno:{$ne:30}}, {job:"MANAGER"})
   

4. Liste des employés de salaire compris entre 1200 et 1400

   db.emp.find({sal:{$gte:1200}, sal:{$lte:1400}}, {ename:1, sal:1})
   

5. Liste des employés des départements 10 et 30 classés dans l'ordre alphabétique

   db.emp.find({deptno:{$eq:10}, deptno:{$eq:30}},{ename:1, deptno:1}).sort({ename:1})
   

6. Liste des employés du département 30 classés dans l'ordre des salaires croissants

   db.emp.find({deptno:{$eq:30}},{ename:1, deptno:1}).sort({sal:1})
   

7. Liste de tous les employés classés par emploi et salaires décroissants

   db.emp.find({},{ename:1, deptno:1}).sort({job: -1, sal: -1})
   

8. Liste des différents emplois

   db.emp.distinct("job")
   

9. Donner le nom du département où travaille ALLEN

   db.emp.find({ename:{$eq:"ALLEN"}}, {ename:1, deptno:1})
   

10. Liste des employés avec nom du département, nom, job, salaire classés par noms de départements etpar salaires décroissants.

    db.emp.find({}, {dname:1, ename:1, job:1, sal:1, deptno:1}).sort({dname:-1, sal:-1})
   

11. Liste des employés vendeurs (SALESMAN) avec affichage de nom, salaire, commissions, salaire + commissions

      db.emp.find({job:"SALESMAN"}, {ename:1, sal:1, comm:1, totalSaleAmount:{$sum:{$add:["$sal", "$comm"]}},job:1})
   

12. Donner le salaire le plus élevé par département

      db.emp.aggregate({$group:{_id:"$dname", salMax:{$max:"$sal"}}})
   

13. Donner département par département masse salariale, nombre d'employés, salaire moyen par type d'emploi.($count n'est pas utilisable avec $group)

      db.employes.aggregate({$group:{_id:"$dname", payroll:{$sum:"$sal"}, nbremp:{$sum:1}, avgsale:{$avg:"$sal"}}})
