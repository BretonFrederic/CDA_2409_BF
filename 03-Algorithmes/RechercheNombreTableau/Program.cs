using System;

namespace RechercheNombreTableau
{
    class program
    {
        /* CONSIGNE */

        // Exercice 5.1 : Rechercher un nombre dans un tableau

        // Soit un tableau de nombres entier triés par ordre croissant.
        // Exemple: [8, 16, 32, 64, 128, 256, 512]
        // Chercher si un nombre donné N figure parmi les éléments.
        // Si oui, afficher la valeur de l’indice correspondant. Sinon, afficher « Nombre non trouvé ».

        /* FONCTIONS */

        // Fonction qui demande à l'utilisateur de saisir un nombre
        static int DemanderNombreUtilisateur()
        {
            int nombre;
            while (true)

            {
                try
                {
                    //Demande à l'utilisateur d'entrer un nombre
                    Console.Write("Entrer le nombre N : ");
                    nombre = int.Parse(Console.ReadLine());
                    return nombre;
                }
                catch
                {
                    System.Console.WriteLine("ERREUR : Vous devez entrer un nombre.");
                }
            }
        }

        static void Main(string[] ars)
        {
            /* VARIABLES */
            int[] tableau;
            int nombreN;
            int valeurIndice;

            /* TRAITEMENT */
            tableau = new int[] {128, 16, 256, 64, 8, 32, 512 };
            nombreN = 0;
            valeurIndice = -1;

            Console.Write("Tableau de nombres entier non triés : ");
            foreach(int element in tableau)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            
            // Trier le tableau des nombres entier
            Array.Sort(tableau);

            // Demander un nombre à l'utilisateur
            nombreN = DemanderNombreUtilisateur();

            Console.Write("Tableau de nombres entier triés : ");
            foreach (int element in tableau)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            // Recherche si le nombre utilisateur est dans le tableau est initialise valeurIndice avec l'index du nombre correspondant dans le tableau
            for (int position = 0; position < tableau.Length-1; position++)
            {
                if (nombreN.Equals(tableau[position]))
                {
                    valeurIndice = position;
                }
            }

            /*  AFFICHAGE */

            if(valeurIndice >= 0)
            {
                Console.WriteLine("La valeur de l'indice du nombre " + tableau[valeurIndice] + " dans le tableau est : " + valeurIndice);
            }
            else
            {
                Console.WriteLine("Nombre non trouvé.");
            }
        }
    }
}
