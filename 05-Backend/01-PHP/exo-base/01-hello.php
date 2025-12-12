
<?php

/*Fonction affichage Hello world ! */
function helloWorld(): void
{
    echo "Hello World !";
}

/* Fonction qui retourne une string */
function hello(string $name): string
{
    return "Hello $name";
}

// Appel de la fonction helloWorld
helloWorld();

// Appel de la fonction hello
echo hello("Fred");
