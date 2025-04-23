<?php

/* Fonction qui retourne un booléen, true si majeur, false si mineur */
function isMajor($num): bool
{
    if ($num >= 18) {
        return true;
    } else {
        return false;
    }
}

/* Fonction qui retourne nombre d'années restant avant la retraite */
function getRetired($age): string
{
    $AGE_RETRAITE = 60;
    return " test ";
}

echo isMajor(12);
echo "\n";
echo isMajor(18);
echo "\n";
echo isMajor(42);
