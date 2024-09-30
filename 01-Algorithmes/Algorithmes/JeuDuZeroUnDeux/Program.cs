using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System;

namespace JeuDuZeroUnDeux
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 6.2 : Jeu du “0 - 2”

        // A tour de rôle, l’ordinateur et le joueur choisissent un nombre qui ne peut prendre que 3 valeurs: 0, 1 ou 2.
        // Le choix du nombre par l’ordinateur sera simulé par génération d’un nombre aléatoire : N<-- RANDOM
        // Si la différence entre les nombres choisi vaut :

        // 2 : le joueur qui a proposé le plus grand nombre gagne un point.
        // 1 : le joueur qui a proposé le plus petit nombre gagne un point.
        // 0 : aucun point n’est marqué.

        // Le jeu se termine quand un des deux joueurs(l’ordinateur ou le joueur humain) totalise 10 points ou quand l’être humain introduit un nombre négatif qui indique sa volonté d’arrêter de jouer.
        // Dans les 2 cas, afficher les scores.

        /* FONCTIONS */

        // Fonction qui demande à l'utilisateur de saisir un nombre et renvoie un entier.
        static int DemanderNombreUtilisateur()
        {
            int nombre;
            while (true)

            {
                try
                {
                    //Demande à l'utilisateur d'entrer un nombre
                    Console.Write("Entrer un nombre : ");
                    nombre = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    return nombre;
                }
                catch
                {
                    System.Console.WriteLine("ERREUR : Vous devez entrer un nombre.");
                }
            }
        }

        // Fonction qui demande un nombre dans un intervalle donné et renvoie un entier.
        static int DemanderUnNombreDansIntervalle(int  min, int max)
        {
            int nombre = 0;
            do
            {
                nombre = DemanderNombreUtilisateur();
                if(nombre > max)
                {
                    Console.WriteLine("Vous devez saisir un nombre dans l'intervalle {0} à {1}.", min, max);
                }
            } while (nombre > max);
            return nombre; 
        }

        // Fonction qui génère un nombre aléatoire dans un intervalle donné.
        static int GenererNombreAleatoire(int min, int max)
        {
            int nombreAleatoire = 0;
            Random rand = new Random();
            if(min < max)
            {
                nombreAleatoire = rand.Next(min, max);
            }
            return nombreAleatoire;
        }

        // Fonction qui calcul les points et renvoie un tableau des points à chaque tour.
        static int[] CalculerPoints(int nombreJoueur, int nombreOrdinateur)
        {
            // scores[0] = joueur, scores[1] = ordinateur
            int[] scores = new int[2];

            if((Math.Abs(nombreOrdinateur - nombreJoueur) == 2))
            {
                if(nombreJoueur > nombreOrdinateur)
                {
                    scores[0] = 1;
                }
                else if(nombreJoueur < nombreOrdinateur)
                {
                    scores[1] = 1;
                }
            }
            if ((Math.Abs(nombreOrdinateur - nombreJoueur) == 1))
            {
                if (nombreJoueur < nombreOrdinateur)
                {
                    scores[0] = 1;
                }
                else if (nombreJoueur > nombreOrdinateur)
                {
                    scores[1] = 1;
                }
            }
            if ((Math.Abs(nombreOrdinateur - nombreJoueur) == 0))
            {
                scores[0] = 0;
                scores[1] = 0;
            }

            return scores;
        }

        static void Main(string[] args)
        {
            /* VARIABLES */
            const int nombreMin = 0;
            const int nombreMax = 2;
            int nombreOrdinateur = 0;
            int pointsOrdinateur = 0;
            int nombreJoueur = 0;
            int pointsJoueur = 0;
            bool partieTerminee = false;
            // scores[0] = joueur, scores[1] = ordinateur
            int[] scores = new int[2];

            /* TRAITEMENT */

            Console.WriteLine("L’ordinateur et le joueur choisissent un nombre qui ne peut prendre que 3 valeurs: 0, 1 ou 2.");
            Console.WriteLine("Le jeu se termine quand un des deux joueurs (l’ordinateur ou le joueur humain) totalise 10 points ou quand l’être humain introduit un nombre négatif qui indique sa volonté d’arrêter de jouer.");

            do
            {
                nombreJoueur = DemanderUnNombreDansIntervalle(nombreMin, nombreMax);
                if(nombreJoueur < 0)
                {
                    partieTerminee = true;
                }
                else
                {
                    nombreOrdinateur = GenererNombreAleatoire(nombreMin, nombreMax);
                    Console.WriteLine("Nombre joueur : {0}", nombreJoueur);
                    Console.WriteLine("Nombre ordinateur : {0}", nombreOrdinateur);
                    Console.WriteLine();
                    scores = CalculerPoints(nombreJoueur, nombreOrdinateur);
                    pointsJoueur += scores[0];
                    pointsOrdinateur += scores[1];
                    if (pointsJoueur == 10 || pointsOrdinateur == 10)
                    {
                        partieTerminee = true;
                    }
                }
            } while (!partieTerminee);

            /* AFFICHAGE */
            if (partieTerminee)
            {
                Console.WriteLine("Score joueur : {0}", pointsJoueur);
                Console.WriteLine("Score ordinateur : {0}", pointsOrdinateur);
            }
            
        }
    }
}
