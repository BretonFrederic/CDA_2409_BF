<?php

// Exo 4.A
/* Fonction qui retourne un booléen, true si majeur, false si mineur */
function isMajor($num): bool
{
    if ($num >= 18) {
        return true;
    } else {
        return false;
    }
}

echo isMajor(12);
echo "\n";
echo isMajor(18);
echo "\n";
echo isMajor(42);
echo "\n";

// Exo 4.B
/* Fonction qui retourne nombre d'années restant avant la retraite */
function getRetired($age): string
{
    $AGE_RETRAITE = 60;
    if ($age < 0) {
        $message = "Vous n'êtes pas encore née.";
    } else if ($age < $AGE_RETRAITE) {
        $annee = $AGE_RETRAITE - $age;
        $message = "Il vous reste $annee ans avant la retraite.";
    } else if ($age == $AGE_RETRAITE) {
        $message = "Vous êtes à la retraite cette année.";
    } else if ($age > $AGE_RETRAITE) {
        $annee = $age - $AGE_RETRAITE;
        $message = "Vous êtes à la retraite depuis $annee ans.";
    }
    return $message;
}
echo getRetired(12);
echo "\n";
echo getRetired(60);
echo "\n";
echo getRetired(72);
echo "\n";
echo getRetired(-2);
echo "\n";

// Exo 4.C
function getMax($num1, $num2, $num3): float
{
    $array1 = [$num1, $num2, $num3];
    $temp = 0;
    for ($i = 0; $i < count($array1) - 1; $i++) {
        if ($array1[$i] == $array1[$i + 1]) {
            return 0;
        }
    }
    for ($i = 0; $i < count($array1) - 1; $i++) {
        for ($j = 0; $j < count($array1) - 1; $j++) {
            if ($array1[$i] < $array1[$i + 1]) {
                $temp = $array1[$i + 1];
                $array1[$i + 1] = $array1[$i];
                $array1[$i] = $temp;
                $temp = 0;
            }
        }
    }
    return round($array1[0], 3);
}

echo getMax(6.2, 7.5, 7.5);
echo "\n";

// Exo 4.D
function capitalCity($country): string
{
    switch ($country) {
        case "France":
            return "Paris";
            break;
        case "Allemagne":
            return "Berlin";
            break;
        case "Italie":
            return "Rome";
            break;
        case "Maroc":
            return "Rabat";
            break;
        case "Espagne":
            return "Madrid";
            break;
        case "Portugal":
            return "Lisbonne";
            break;
        case "Angleterre":
            return "Londres";
            break;
        default:
            return "Capitale inconnue";
    }
}

echo capitalCity("France");
