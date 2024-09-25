using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace JeuFourchette
{
    class Program
    {
        /* CONSIGNE */

        // Exercice 3a.6 : Jeu de la fourchette

        // L’ordinateur « choisit » aléatoirement un nombre mystère(entier compris entre 0 et 100).
        // Le joueur essaie de le deviner.
        // Lors de chaque essai, l’ordinateur affiche la « fourchette » dans laquelle se trouve le nombre qu’il a choisi.
        // Le choix du nombre mystère sera simulé par génération d’un nombre aléatoire : N<-- RANDOM(0,100).
        // Lorsque l’utilisateur a trouvé le nombre mystère, le programme affiche :
        // Bravo vous avez trouvé en X essais.

        /* FONCTIONS */

        // Fonction qui génère et renvoie un nombre aléatoire dans l'intervalle de 2 nombres
        static int GenererNombreAleatoire(int min, int max)
        {
            int nombreMystere = 0;
            Random aleatoire = new Random();
            nombreMystere = aleatoire.Next(0, 101);
            return nombreMystere;
        }

        // Fonction qui demande et renvoie un nombre à l'utilisateur
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

        // Fonction qui demande et renvoie un nombre dans intervalle de 2 nombres
        static int DemanderNombreDansIntervalle(int min, int max, string message)
        {
            message += "entre " + min + " et " + max + " : ";
            int nombre = 0;
            nombre = DemanderNombreUtilisateur(message);
            if (nombre < min || nombre > max)
            {
                Console.WriteLine("Le nombre est hors limite.");
                return DemanderNombreDansIntervalle(min, max, message);
            }
            else
            {
                return nombre;
            }
        }

        // Fonction qui valide ou pas la correspondance de deux nombres entiers et renvoie une boolean
        static bool ValiderNombre(int nombreUtilisateur, int nombreValide)
        {
            if (nombreUtilisateur.Equals(nombreValide))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            /* VARIABLES */
            int nombreMystere;
            int nombreJoueur;
            int nombreEssais;
            string instructions;
            bool victoire;
            int min;
            int max;

            /* TRAITEMENT */

            //Initialisation
            nombreMystere = 0;
            nombreJoueur = 0;
            nombreEssais = 0;
            instructions = "Saisir un nombre entier ";
            victoire = false;
            min = 0;
            max = 100;

            // Générer nombre mystère
            nombreMystere = GenererNombreAleatoire(min, max);

            // Rejoueur tant que le nombre n'a pas était trouvé
            while (!victoire)
            {
                // Redéfinir l'intervalle min max en fonction du nombre du joueur
                if (nombreEssais > 0)
                {
                    if (nombreJoueur < nombreMystere)
                    {
                        min = nombreJoueur;
                    }
                    else if (nombreJoueur > nombreMystere)
                    {
                        max = nombreJoueur;
                    }
                }

                // Demander nombre du joueur
                nombreJoueur = DemanderNombreDansIntervalle(min, max, instructions);

                // Compteur d'essais
                nombreEssais++;

                // Définir si le joueur a gagné
                victoire = ValiderNombre(nombreJoueur, nombreMystere);
            }


            /* AFFICHAGE */

            // Afficher message de victoire
            if (victoire)
            {
                Console.WriteLine("Bravo ! Vous avez trouvé le nombre mystère en " + nombreEssais + " essai(s).");
            }
        }
    }
}

