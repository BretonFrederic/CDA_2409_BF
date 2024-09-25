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
            String phrase;
            int occurences;
            char lettre;


            /* TRAITEMENT */
            String = "Parfois ce sont les gens que personne n’aurait imaginé qui accomplissent des choses que personne n’avait imaginé.";

            /* AFFICHAGE */

            Console.WriteLine("La phrase est vide.");
            Console.WriteLine("La lettre n'est pas présente.");
            Console.WriteLine("La lettre est présente une ou plusieurs fois.");
        }
    }
}
