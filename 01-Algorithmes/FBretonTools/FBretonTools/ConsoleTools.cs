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

        // Fonction qui demande et renvoie une chaîne de caractères
        public static string DemanderString(string _question = "Saisir du texte")
        {
            string texte;
            Console.Write(_question);
            texte = Console.ReadLine() ?? "";
            return texte;
        }

        // Fonction qui demande de choisir entre o(oui) et n(non) et renvoie un booleen true o, false n
        public static bool DemanderChoixOuiNon(string _question = "Voulez-vous continuer ? (o/n) : ")
        {
            char choixCaractere = ' ';
            bool choixBool = false;
            bool reponseValide = false;
            do
            {
                Console.Write(_question);
                choixCaractere = Console.ReadKey().KeyChar;
                Console.WriteLine();
                
                if(choixCaractere == 'o' || choixCaractere == 'O')
                {
                    reponseValide = true;
                    choixBool = true;
                }
                else if(choixCaractere == 'n' || choixCaractere == 'N')
                {
                    reponseValide = true;
                    choixBool = false;
                }
            } while (!reponseValide);
            return choixBool;
        }
    }
}
