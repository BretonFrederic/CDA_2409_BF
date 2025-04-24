<?php
// Exo 6.A
/* Fonction qui retourne la date du jour au format d/m/Y */
function getToday()
{
    $dt = time();
    return date("d/m/Y", $dt);
}

echo getToday();
echo "\n";

// Exo 6.B
/* Fonction qui retourne une date au format Y-m-d */
function getTimeLeft($date): string
{
    $timeDate = strtotime($date);
    // $dateDuJour = date("m/d/Y", $timeDate);
    // if(checkdate())

    $diff = time() - $timeDate;
    if ($diff < 0) {
        $message = "Évènement passé";
    }
    return $message;
}

echo getTimeLeft("2019-09-29");
echo "\n";
