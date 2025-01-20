/* CREER UN UTILISATEUR */
CREATE USER 'toto'@'localhost' IDENTIFIED BY 'password';

/* Accorder TOUS les PRIVILEGES à Toto sur la base de données rezo_social */
GRANT ALL PRIVILEGES ON rezo_social.* TO 'toto'@'localhost';

/* RECHARGER LES PRIVILEGES au niveau du serveur */
FLUSH PRIVILEGES;