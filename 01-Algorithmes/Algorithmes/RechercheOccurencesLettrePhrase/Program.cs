using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text;
using System.Threading.Channels;

namespace RechercheOccurencesLettrePhrase
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 5.2 : Rechercher le nombre d’occurences d’une lettre dans une phrase
        // Soit une chaîne de caractères terminée par le caractère « . ».
        // Donnez l’algorithme d’un programme qui compte le nombre d’occurrences d’une lettre donnée(“a” par exemple) dans cette chaîne.
        // Si la chaîne de caractères est vide ou n’est composée que d’un caractère « . », le message “LA CHAINE EST VIDE” sera affiché.
        // Proposez un jeu d’essai prévoyant les 3 cas suivants :
        //                                                          La phrase est vide
        //                                                          La lettre n’est pas présente
        //                                                          La lettre est présente une ou plusieurs fois

        /* FONCTIONS */

        static void Main(string[] args)
        {

            /* VARIABLES */
            string phrase;
            int occurences;
            char lettre;


            /* TRAITEMENT */

            //phrase = "";
            //phrase = ".";
            phrase = "Parfois ce sont les gens que personne n’aurait imaginé qui accomplissent des choses que personne n’avait imaginé.";
            occurences = 0;
            lettre = 'A';

            // Chercher le nombre d'occurences de la lettre dans la phrase
            
            /* OrdinalIgnoreCase traite les caractères des chaînes à comparer 
             * comme s'ils étaient convertis en majuscules à l'aide des conventions
             * de la culture invariante, puis effectue une simple comparaison
             * d'octets indépendante de la langue. */

            // Solution 1
            /*foreach (char ch in phrase)
            {
                if (ch.ToString().Equals(lettre.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    occurences++;
                }
            }*/

            // Solution 2
            occurences = phrase.Where(ch => ch.ToString().Equals(lettre.ToString(), StringComparison.OrdinalIgnoreCase)).Count();

            /* AFFICHAGE */

            Console.WriteLine("Dans la phrase : " + "\"" + phrase + "\"");
            if(phrase.Equals("") || phrase.Equals("."))
            {
                Console.WriteLine("La phrase est vide.");
            }
            else if(occurences == 0)
            {
                Console.WriteLine("La lettre n'est pas présente.");
            }
            else
            {
                Console.WriteLine("La lettre " + lettre + " est présente " + occurences + " fois.");
            }
        }
    }
}
