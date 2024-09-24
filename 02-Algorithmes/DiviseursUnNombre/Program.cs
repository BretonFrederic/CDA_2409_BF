using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiviseursUnNombre
{
    internal class Program
    {
        /*
         Exercice 3a.4 : Recherche des diviseurs d’un nombre.
         Lire un nombre entier et afficher tous ses diviseurs autres que 1 et lui-même.
        */

        // Fonction qui demande un nombre à l'utilisateur
        static int DemanderNombreUtilisateur()
        {
            int nombre;
            while (true)
            {
                try
                {
                    Console.Write("Entrer un nombre : ");
                    nombre = int.Parse(Console.ReadLine());
                    return nombre;
                }
                catch
                {
                    Console.WriteLine("ERREUR : Donnée invalide.");
                }
            }
        }

        //Fonction creation liste diviseurs
        static List<int> DefinirDiviseurs(int nombre) 
        {
            List<int> diviseurs = new List<int>();
            //Sélection des diviseurs du nombre utilisateur et ajout dans la liste
            for (int i = 2; i < nombre; i++)
            {
                if (i%2 == 0)
                {
                    diviseurs.Add(i);
                }
            }
            return diviseurs;
        }

        static void Main(string[] args)
        {
            /* VARIABLES */
            int nombreUtilisateur;
            List<int> diviseurs;

            /* TRAITEMENT */
            diviseurs = new List<int>();
            nombreUtilisateur = DemanderNombreUtilisateur();
            diviseurs = DefinirDiviseurs(nombreUtilisateur);
            

            /* AFFICHAGE */
        }
    }
}