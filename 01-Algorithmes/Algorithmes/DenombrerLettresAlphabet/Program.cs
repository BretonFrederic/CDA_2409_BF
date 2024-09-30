using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

namespace DenombrerLettresAlphabet
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 6.4 : DENOMBRER LES LETTRES DE L’ALPHABET

        // Lire une chaine de caractères d’au moins 100 caractères(à contrôler).
        // Compter et afficher:

        //    le nombre de consonnes.
        //    le nombre de voyelles
        //    le nombre de chiffres
        //    la moyenne des chiffres, 0 si aucun chiffre.

        /* FONCTIONS */
        static void Main(string[] args)
        {
            /* VARIABLES */
            string chaineCharacteres = "";
            string digital = "0123456789";
            string consonnes = "bcdfghjklmnpqrstvwxz";
            string voyelles = "aeiouy";
            int nombreConsonnes = 0;
            int nombreVoyelles = 0;
            int nombreChiffres = 0;
            int totalChiffres = 0;
            int moyenne = 0;
            Random rand = new Random();
            string caracteres = digital + consonnes + voyelles;

            /* TRAITEMENT */

            // Affecter au moins 100 caractères à la chaine de caractère
            while (chaineCharacteres.Length < rand.Next(100, 200))
            {
                chaineCharacteres += caracteres[rand.Next(0, 36)];
            }

            // Récupérer nombres d'occurences consonnes, voyelles, chiffres
            foreach(char ch in chaineCharacteres)
            {
                foreach(char num in digital)
                {
                    if (ch.Equals(num))
                    {
                        nombreChiffres++;
                        totalChiffres += int.Parse(ch.ToString());

                    }

                }
                foreach (char c in consonnes)
                {
                    if (ch.Equals(c))
                    {
                        nombreConsonnes++;
                    }

                }
                foreach (char v in voyelles)
                {
                    if (ch.Equals(v))
                    {
                        nombreVoyelles++;
                    }

                }
            }

            /* AFFICHAGE */
            Console.WriteLine("Chaine de caractères({0}) : {1}\n",chaineCharacteres.Length, chaineCharacteres);
            Console.WriteLine("Consonnes : {0}", nombreConsonnes);
            Console.WriteLine("Voyelles : {0}", nombreVoyelles);
            Console.WriteLine("Chiffres : {0}", nombreChiffres);
            Console.WriteLine();
            if (nombreChiffres > 0)
            {
                moyenne = totalChiffres / nombreChiffres;
                Console.WriteLine("moyenne des chiffres : {0}", moyenne);
            }
            else
            {
                Console.WriteLine("Nombre de chiffres : 0");
            }
        }
    }
}
