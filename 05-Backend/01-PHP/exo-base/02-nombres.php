<?php

/* Fonction getSum() retourne la somme de 2 valeurs */
function getSum($num1, $num2): int
{
    return $num1 + $num2;
}

/* Fonction getSub() retourne la soustraction de 2 valeurs */
function getSub($num1, $num2): int
{
    return $num1 - $num2;
}

/* Fonction getMulti() retourne la multiplication de 2 valeurs */
function getMulti($num1, $num2): float
{
    return $num1 * $num2;
}

/* Fonction getDiv() retourne la multiplication de 2 valeurs */
function getDiv($num1, $num2)
{
    if ($num2 == 0) return 0;
    $div = $num1 / $num2;
    return round($div, 2);
}

echo getSum(5, 3);
echo "\n";
echo getSub(5, 3);
echo "\n";
echo getSub(3, 5);
echo "\n";
echo  getMulti(5.6, 3);
echo "\n";
echo  getMulti(5.6, -3.7);
echo "\n";
echo getDiv(20, 3);
echo "\n";
echo getDiv(20, 0);
