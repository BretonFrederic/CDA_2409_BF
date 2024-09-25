using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiviseursUnNombre
{
    internal class Program
    {
        /* CONSIGNE */

        //Exercice 3a.4 : Recherche des diviseurs d’un nombre.
        //Lire un nombre entier et afficher tous ses diviseurs autres que 1 et lui-même.

        /* FONCTIONS */

        // Fonction qui demande un nombre à l'utilisateur
        static int DemanderNombreUtilisateur(string message)
        {
            int nombre;
            while (true)
            {
                try
                {
                    Console.Write(message);
                    nombre = int.Parse(Console.ReadLine());
                    return nombre;
                }
                catch
                {
                    Console.WriteLine("ERREUR : Donnée invalide.");
                }
            }
        }

        // Fonction qui demande un nombre positif à l'utilisateur
        static int DemanderNombrePositif(string message)
        {
            int nombre = -1;
            nombre = DemanderNombreUtilisateur(message);
            if (nombre > 0)
            {
                return nombre;
            }
            else
                return DemanderNombrePositif(message);
        }

        //Fonction création liste diviseurs
        static List<int> DefinirDiviseurs(int nombre)
        {
            List<int> diviseurs = new List<int>();
            //Sélection des diviseurs du nombre utilisateur et ajout dans la liste
            for (int i = 2; i < nombre; i++)
            {
                if (nombre % i == 0)
                {
                    diviseurs.Add(i);
                }
            }
            return diviseurs;
        }

        // Fonction qui affiche une liste de nombres
        static void AfficherListeNombres(List<int> nombres)
        {
            for (int i = 0; i < nombres.Count; i++)
            {
                System.Console.Write(nombres[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            /* VARIABLES */

            int nombreUtilisateur;
            List<int> diviseurs;
            string messageInstruction;

            /* TRAITEMENT */

            // Initialisation
            nombreUtilisateur = 0;
            diviseurs = new List<int>();
            messageInstruction = "Entrer un nombre positif non nul : ";

            // Demander de saisir un nombre positif non nul
            nombreUtilisateur = DemanderNombrePositif(messageInstruction);

            // Définir la liste des diviseurs
            diviseurs = DefinirDiviseurs(nombreUtilisateur);


            /* AFFICHAGE */

            //Afficher la liste des diviseurs
            AfficherListeNombres(diviseurs);
        }
    }
}
