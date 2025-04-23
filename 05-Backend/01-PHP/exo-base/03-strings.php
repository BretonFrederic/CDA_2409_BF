<?php

/* Fonction qui retourne le nom de l'inventeur de la formule "E = MC²" */
function getMC2()
{
    return "Albert Einstein";
}

/* Fonction qui retourne la concaténation de 2 valeurs */
function getUserName($prenom, $nom): string
{
    return $prenom . " " . $nom;
}

/* Fonction qui retourne le prénom en minuscule et le nom en majuscule séparé par un espace */
function getFullName($prenom, $nom): string
{
    return strtolower($prenom) . " " . strtoupper($nom);
}

/* Fonction retourne un message de bienvenue à un utilisateur et lui pose une question */
function askUser($prenom, $nom): string
{
    return "Bonjour " . getFullName($prenom, $nom) . ". Connaissez-vous " . getMC2() . " ?";
}

echo getMC2();
echo "\n";
echo getUserName("Fred", "Breton");
echo "\n";
echo getFullName("Fred", "Breton");
echo "\n";
echo askUser("Fred", "Breton");
