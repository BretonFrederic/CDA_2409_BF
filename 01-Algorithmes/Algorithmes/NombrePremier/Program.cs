using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiviseursUnNombre
{
    internal class Program
    {
        /* CONSIGNE */

        //Exercice 3a.5 : Nombre premier

        //Lire un nombre N et déterminer s’il est un nombre premier.
        //Un nombre premier n’est divisible que par 1 et par lui-même.

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

        // Fonction qui détermine si un nombre est premier ou pas
        static bool DefinirNombrePremier(int nombre)
        {
            List<int> diviseurs = new List<int>();
            var nombrePremier = false;
            // Sélection des diviseurs du nombre utilisateur et ajout dans la liste
            for (int i = 2; i < nombre; i++)
            {
                if (nombre % i == 0)
                {
                    diviseurs.Add(i);
                }

                // Validation nombre premier car pas de diviseurs autres que 1 et lui même
                if (diviseurs.Count() == 0)
                {
                    nombrePremier = true;
                }
            }
            return nombrePremier;
        }

        // Fonction qui affiche si un nombre est premier ou pas
        static void AfficherListeNombres(bool isPrime)
        {
            string message = "Le nombre saisi ";
            if (isPrime)
            {
                message += "est un nombre premier.";
            }
            else if (!isPrime)
            {
                message += "n'est pas un nombre premier.";
            }
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            /* VARIABLES */

            int nombreUtilisateur;
            bool estNombrePremier;
            string messageInstruction;

            /* TRAITEMENT */

            // Initialisation
            nombreUtilisateur = 0;
            estNombrePremier = false;
            messageInstruction = "Entrer un nombre positif non nul : ";

            // Demander de saisir un nombre positif non nul
            nombreUtilisateur = DemanderNombrePositif(messageInstruction);

            // Définir la liste des diviseurs
            estNombrePremier = DefinirNombrePremier(nombreUtilisateur);


            /* AFFICHAGE */

            //Afficher la liste des diviseurs
            AfficherListeNombres(estNombrePremier);
        }
    }
}

