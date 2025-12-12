<?php
// Exo 5.A
$names = ['Joe', 'Jack', 'Léa', 'Zoé', 'Néo'];
function firstItem($array)
{
    if (count($array) == 0) {
        return null;
    } else {
        return $array[0];
    }
}

echo firstItem($names);
echo "\n";

// Exo 5.B
function lastItem($array)
{
    return end($array);
}

echo lastItem($names);
echo "\n";

// Exo 5.C
function sortItems($array)
{
    $aLength = count($array);
    $newArray = [$aLength];
    rsort($array);
    $result = "[";
    for ($i = 0; $i < $aLength; $i++) {
        if ($i != 0) {
            $result .= ",";
        }
        $newArray[$i] = $array[$i];
        $result .= $newArray[$i];
    }
    $result .= "]";
    return $result;
}

echo sortItems($names);
echo "\n";

// Exo 5.D
function stringItems($array): string
{
    if (count($array) == 0) {
        return "Nothing to display";
    }
    $aLength = count($array);
    $newArray = [$aLength];
    sort($array);
    for ($i = 0; $i < $aLength; $i++) {
        $newArray[$i] = $array[$i];
    }
    $newString = join(", ", $newArray);
    return $newString;
}

echo stringItems($names);
echo "\n";
