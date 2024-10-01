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
            string[] listesCharacteres = new string[] { "0123456789", "bcdfghjklmnpqrstvwxz", "aeiouy" };
            int[] nombresCaracteres = new int[] { 0, 0, 0 };
            int totalChiffres = 0;
            Random rand = new Random();
            string[] categories = new string[] {"Consonnes : ", "Voyelles : ", "Chiffres : "};

            /* TRAITEMENT */

            // Affecter au moins 100 caractères à la chaine de caractère
            while (chaineCharacteres.Length < rand.Next(100, 200))
            {
                chaineCharacteres += (listesCharacteres[0] + listesCharacteres[1] + listesCharacteres[2])[rand.Next(0, 36)];
            }

            // Récupérer nombres d'occurences consonnes, voyelles, chiffres
            foreach(char ch in chaineCharacteres)
            {
                for(int i = 0; i < listesCharacteres.Length; i++)
                {
                    foreach (char c in listesCharacteres[i])
                    {
                        if (ch.Equals(c))
                        {
                            nombresCaracteres[i]++;
                            if (i == 0)
                                {
                                    totalChiffres += int.Parse(ch.ToString());
                                }
                        }
                    }
                }
            }

            /* AFFICHAGE */
            Console.WriteLine("Chaine de caractères({0}) : {1}\n",chaineCharacteres.Length, chaineCharacteres);
            for(int i = 0; i < listesCharacteres.Length; i++)
            {
                Console.WriteLine(categories[i] + nombresCaracteres[i]);
            }
            Console.WriteLine();
            if (totalChiffres > 0)
            {
                int moyenne = totalChiffres / nombresCaracteres[0];
                Console.WriteLine("moyenne des chiffres : {0}", moyenne);
            }
            else
            {
                Console.WriteLine("Nombre de chiffres : 0");
            }
        }
    }
}
