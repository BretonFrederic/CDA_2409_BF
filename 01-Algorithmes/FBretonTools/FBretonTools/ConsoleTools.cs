using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace FBretonTools
{
    public class ConsoleTools
    {
        public static int DemanderNombreEntier(string _question)
        {
            string saisieUtilisateur;

            int valeurRetour;

            bool saisieOk;

            do
            {
                Console.WriteLine(_question);

                saisieUtilisateur = Console.ReadLine() ?? "";

                saisieOk = int.TryParse(saisieUtilisateur, out valeurRetour);

                if (!saisieOk)
                {
                    Console.WriteLine("Saisie invalide, recommencez !");
                }

            } while (!saisieOk);

            return valeurRetour;
        }

        public static float DemanderNombreFloatPositif(string _question)
        {
            string saisieUtilisateur;

            float valeurRetour;

            bool saisieOk;

            do
            {
                Console.WriteLine(_question);

                saisieUtilisateur = Console.ReadLine() ?? "";

                saisieOk = float.TryParse(saisieUtilisateur, out valeurRetour) && (valeurRetour >= 0);

                if (!saisieOk)
                {
                    Console.WriteLine("Saisie invalide, recommencez !");
                }

            } while (!saisieOk);
            return valeurRetour;
        }

        /*
        L'utilisateur entre un mot de passe
        Le programme contrôle si le mot de passe respecte les règles en vigueur
        - 12 caractères minimum
            ET Au moins 1 minuscule
            ET Au moins 1 majuscule
            ET Au moins 1 chiffre
            ET Au moins 1 caractère spécial
        OU
        - 20 caractères minimum
            ET Au moins 1 minuscule
            ET Au moins 1 majuscule
            ET Au moins 1 chiffre
        */
        public static string DemanderMotDePasse(string _question = "Entrer mot de passe : ")
        {
            string motDePasse;
            string formatMotDePasse = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{12,}$|^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{20,}$";

            do
            {
                Console.WriteLine(_question);
                motDePasse = Console.ReadLine() ?? "";
            } while (!Regex.IsMatch(motDePasse, formatMotDePasse, RegexOptions.IgnoreCase));

            // Console.WriteLine("Mot de passe valide : " + motDePasse);
            return motDePasse;
        }
    }
}
