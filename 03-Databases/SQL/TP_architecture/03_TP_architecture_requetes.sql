USE db_architecte;

/* 1. Sélectionner l'identifiant, le nom de tous les clients dont le numéro de téléphone commence par '04' */
SELECT client_ref, client_nom
FROM clients
WHERE client_telephone LIKE '04%';

/* 2. Sélectionner l'identifiant, le nom et le type de tous les clients qui sont des particuliers */
SELECT client_ref, client_nom, type_clients.type_client_libelle
FROM clients
JOIN type_clients 
ON clients.type_client_id = type_clients.type_client_id
WHERE type_clients.type_client_libelle = 'Particulier';

/* 3. Sélectionner l'identifiant, le nom et le type de tous les clients qui ne sont pas des particuliers */
SELECT client_ref, client_nom, type_clients.type_client_libelle
FROM clients
JOIN type_clients 
ON clients.type_client_id = type_clients.type_client_id
WHERE type_clients.type_client_libelle <> 'Particulier';

/* 4. Sélectionner les projets qui ont été livrés en retard */
SELECT projet_ref
FROM projets
WHERE projet_date_fin_prevue < projet_date_fin_effective;

/* 5. Sélectionner la date de dépôt, la date de fin prévue, les superficies, le prix de tous les projets 
    avec le nom du client et le nom de l'architecte associés au projet */
SELECT projet_date_depot, projet_date_fin_prevue, projet_superficie_totale,projet_superficie_batie , projet_prix, client_nom, emp_nom
FROM projets
JOIN clients
ON projets.client_ref = clients.client_ref
JOIN employes
ON projets.emp_matricule = employes.emp_matricule
WHERE fonction_id = (SELECT fonction_id FROM fonctions WHERE fonction_nom = 'Architecte');
    
/* 6. Sélectionner tous les projets (dates, superficies, prix) avec le nombre d'intervenants autres que le client et l'architecte */
SELECT participer.projet_ref, projet_date_depot, projet_date_fin_prevue, projet_date_fin_effective, projet_superficie_totale, projet_superficie_batie, projet_prix, COUNT(participer.emp_matricule) AS nbremp
FROM projets
JOIN participer
ON projets.projet_ref = participer.projet_ref
GROUP BY participer.projet_ref
ORDER BY participer.projet_ref DESC;

/* 7. Sélectionner les types de projets avec, pour chacun d'entre eux, le nombre de projets associés et le prix moyen pratiqué */
SELECT type_projet_libelle, COUNT(projet_ref), ROUND(AVG(projet_prix), 2)
FROM type_projets
JOIN projets
ON type_projets.type_projet_id = projets.type_projet_id
GROUP BY type_projet_libelle;

/* 8. Sélectionner les types de travaux avec, pour chacun d'entre eux, la superficie du projet la plus grande */
SELECT type_travaux_libelle, MAX(projet_superficie_totale)
FROM type_travaux
JOIN projets
ON type_travaux.type_travaux_id = projets.type_travaux_id
GROUP BY type_travaux_libelle;

/* 9. Sélectionner l'ensembles des projets (dates, prix) avec les informations du client (nom, telephone, adresse), le type de travaux et le type de projet. */
SELECT projet_date_depot, projet_date_fin_prevue, projet_date_fin_effective, projet_prix, client_nom, client_telephone, CONCAT(adresse_voie,' ',adresse_num_voie,' ',adresse_ville,' ',adresse_code_postal) AS adresse, type_travaux_libelle, type_projet_libelle
FROM projets
JOIN clients
ON projets.client_ref = clients.client_ref
JOIN adresses
ON clients.adresse_id = adresses.adresse_id
JOIN type_travaux
ON projets.type_travaux_id = type_travaux.type_travaux_id
JOIN type_projets
ON projets.type_projet_id = type_projets.type_projet_id;

/* 10. Sélectionner les projets dont l'adresse est identique au client associé */
SELECT projet_ref, client_nom
FROM projets
JOIN clients
ON projets.client_ref = clients.client_ref
JOIN adresses
ON clients.adresse_id = adresses.adresse_id 
WHERE projets.adresse_id = clients.adresse_id ;