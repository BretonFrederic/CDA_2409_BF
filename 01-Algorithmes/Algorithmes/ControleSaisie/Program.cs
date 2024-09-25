using System;

namespace ControleSaisie
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES */

            string prenomUtilisateur = " ";

            /* DEBUT PROGRAMME */

            //Boucle tant que prénom ne contient pas au moins 2 caractères
            while (prenomUtilisateur.Length < 2)
            {
                try
                {
                    System.Console.Write("Entrer votre pénom (2 lettres minimum): ");
                    prenomUtilisateur = Console.ReadLine();

                    //Vérification pas d'alphanumérique dans le prénom
                    if (prenomUtilisateur.Any(char.IsDigit))
                    {
                        System.Console.WriteLine("Attention, le prénom ne doit pas contenir de chiffres");
                        prenomUtilisateur = " ";
                    }
                }
                catch
                {
                    System.Console.WriteLine("ERREUR : prénom invalide.");
                }

            }

            //Quand le prénom convient on affiche le message suivi du prénom
            Console.WriteLine("Bonjour " + prenomUtilisateur);

            /* FIN PROGRAMME */
        }
    }
}

