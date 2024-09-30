using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;

namespace CalculNombrePersonnes
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 6.3 : Calcul du nombre de personnes

        // Exercice 6.3.1 : Calculer le nombre de jeunes

        // Il s’agit de dénombrer toutes les personnes d’âge strictement inférieur à 20 ans parmi un échantillon de 20 personnes.
        // L’utilisateur est invité à saisir les 20 valeurs.
        // Décrivez l’algorithme qui affiche le nombre de jeunes et codez la solution.

        // Exercice 6.3.2 : Afficher le nombre de personnes de chaque catégorie

        // Compléter l’algorithme précédent pour répondre à la demande suivante:
        // Si toutes les personnes ont moins de 20 ans, affichez « TOUTES LES PERSONNES ONT MOINS DE 20 ANS ».
        // Si aucune personne n’a moins de 20 ans, affichez « TOUTES LES PERSONNES ONT PLUS DE 20 ANS ».
        // Sinon, affichez le nombre de personnes pour chaque catégorie(« - de 20, + de 20, = à 20).

        // Jeux d’essai:

        //  Aucun jeune
        //         47 35 68 76 34 30 31 46 57 68 75 46 53 36 31 46 69 59 30 20
        // Pas de non-jeunes
        //         15 5 5 6 4 2 11 12 7 8 7 3 13 16 11 18 8 9 19 3
        // Des jeunes et des non-jeunes
        //         45 35 65 77 38 20 20 30 30 30 20 20 30 20 30 20 20 8 15 23

        /* FONCTIONS */

        // Fonction qui demande à l'utilisateur un nombre entier positif et renvoie un entier
        static int DemanderNombrePositif()
        {
            int nombre = 0;
            try
            {
                Console.Write("Saisir un âge : ");
                nombre = int.Parse(Console.ReadLine());
                if(nombre < 1)
                {
                    DemanderNombrePositif();
                }
            }
            catch
            {
                Console.WriteLine("ERREUR : Vous devez entrer un nombre positif.");
            }
            return nombre;
        }

        // 
        static void Main(string[] args)
        {
            /* VARIABLES */
            int[] echantillon = new int[20];
            int nombreDeJeunes = 0;
            int nombreDeNonJeunes = 0;
            int nombresDeJeunesVingtAns = 0;

            /* TRAITEMENT */

            Console.WriteLine("Vous devez saisir l'âge de 20 personnes.");
            for(int i = 0; i < echantillon.Length; i++)
            {
                echantillon[i] = DemanderNombrePositif();
            }
            foreach (int age in echantillon)
            {
                if (age < 20)
                {
                    nombreDeJeunes++;
                }
                else if(age > 20)
                {
                    nombreDeNonJeunes++;
                }
                else
                {
                    nombresDeJeunesVingtAns++;
                }
                Console.WriteLine();
            }

            /* AFFICHAGE */
            if (nombreDeJeunes == 20)
            {
                Console.WriteLine("Toutes les personnes ont moins de 20 ans");
            }
            if (nombreDeNonJeunes == 20)
            {
                Console.WriteLine("Toutes les personnes ont plus de 20 ans");
            }
            else
            {
                Console.WriteLine(" - de 20 ans dans l'échantillon : {0}", nombreDeJeunes);
                Console.WriteLine(" + de 20 ans dans l'échantillon : {0}", nombreDeNonJeunes);
                Console.WriteLine(" Jeunes de 20 ans dans l'échantillon : {0}", nombresDeJeunesVingtAns);
            }
        }
    }
}
