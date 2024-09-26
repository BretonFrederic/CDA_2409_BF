using System.Drawing;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Linq;

namespace Palindrome
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 5.5 : Palindrome

        // Un palindrome est une chaîne de caractères que l’on peut lire identiquement de droite à gauche, et gauche à droite.
        // Par exemple:
        // AA
        // 38783
        // LAVAL
        // LAVAL A ETE A LAVAL
        // ET LA MARINE VA VENIR A MALTE
        // L’utilisateur saisit une chaîne de caractères terminée par un point. (à contrôler).
        // Ecrivez l’algorithme et le programme permettant d’affirmer si cette phrase est ou non un palindrome.
        // Si la chaîne de caractères n’est composée que du caractère ‘.’, l’utilisateur est invité à recommencer.
        // L’algorithme doit prévoir les 3 cas suivants :
        // la phrase est vide
        // la chaîne de caractères n’est pas un palindrome
        // la chaîne de caractères est un palindrome

        /* FONCTIONS */

        // Fonction qui demande une chaîne de caractères à l'utilisateur
        static string DemanderPhraseUtilisateur()
        {
            string phrase;
            do
            {
                Console.Write("Entrer une phrase : ");
                phrase = Console.ReadLine();
                if(phrase.Length != 0)
                {
                    if (!(phrase.Length > 1 && phrase[phrase.Length - 1] == '.'))
                    {
                        phrase = "...";
                        Console.WriteLine("La phrase doit se terminer par un point.");
                    }
                }
                
            } while (phrase.All(ch => ch == '.') && phrase != "");

            //string charactereSpeciaux = "!:;,§/.?ù*µ%$^£¨&~\"#'{([-|`_\\@)]°=}+- ";

            return phrase;
        }

        static void Main(string[] args)
        {
            /* VARIABLES */
            List<string> phrases;
            bool estPalindrome;
            string phraseUtilisateur;

            /* TRAITEMENT */
            estPalindrome = false;
            
            phrases = new List<string>(){ "", "" };

            // Demander un mot à l'utilisateur
            phraseUtilisateur = DemanderPhraseUtilisateur();
            Console.WriteLine(phraseUtilisateur);

            // Retirer les espaces de la phrase
            phrases[0] = phraseUtilisateur.Trim();

            // Inverser le mot et stocker dans un new string
            phrases[1] = new string(phrases[0].Reverse().ToArray());



            // Comparer le mot avec sa copie inversée. Définir si c'est un palindrome avec une booléen
            if (phrases[0] == phrases[1])
            {
                estPalindrome = true;
            }

            /* AFFICHAGE */

            if (phrases[0] == "")
            {
                Console.WriteLine("La phrase vide.");
            }
            if (estPalindrome)
            {
                Console.WriteLine($"Le mot {phrases[0]} inversé est {phrases[1]} c'est un palindrome.");
            }
            else
            {
                Console.WriteLine($"Le mot {phrases[0]} inversé est {phrases[1]} ce n'est pas un palindrome.");
            }
        }
    }
}
