using System.Reflection.Metadata.Ecma335;

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
    }
}
