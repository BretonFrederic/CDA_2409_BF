using System;

namespace ControleSaisieLimite
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES */

            int nombreEssais = 0;
            string motDePasseValide = "formation";
            string motDePasseUtilisateur = " ";

            /* CONSTANTES */

            const int essaisMax = 3;

            /* DEBUT PROGRAMME */

            //Tant que nombre Max d'essais n'est pas atteint l'utilisateur peut entrer mot de passe
            while (nombreEssais < essaisMax)
            {
                try
                {
                    System.Console.Write("veuillez entrer votre mot de passe : ");
                    motDePasseUtilisateur = Console.ReadLine();
                }
                catch
                {
                    System.Console.WriteLine("ERREUR : Mot de passe invalide.");
                }
                //incrémentation nombre d'essais
                nombreEssais += 1;

                //Si mot de passe valide utilisateur connecté fin du programme
                if (motDePasseUtilisateur.Equals(motDePasseValide))
                {
                    Console.WriteLine("Vous êtes connecté.");
                    break;
                }
            }

            //L'utilisateur a atteint nombre Max d'essai compte bloqué fin du programme
            if (!motDePasseUtilisateur.Equals(motDePasseValide))
            {
                System.Console.WriteLine("Votre compte est bloqué.");
            }

            /* FIN PROGRAMME */
        }
    }
}


