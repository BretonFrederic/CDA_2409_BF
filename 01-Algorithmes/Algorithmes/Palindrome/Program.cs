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

        static void Main(string[] args)
        {
            /* VARIABLES */
            List<string> mots;
            bool estPalindrome;

            /* TRAITEMENT */
            estPalindrome = false;
            // Inverser le mot et stocker dans un new string
            mots = new List<string>(){ "LONDRES", "" };
            mots[1] = new string(mots[0].Reverse().ToArray());

            // Comparer le mot avec sa copie inversée. Définir si c'est un palindrome avec une booléen
            if (mots[0] == mots[1])
            {
                estPalindrome = true;
            }

            /* AFFICHAGE */

            if (estPalindrome)
            {
                Console.WriteLine($"Le mot {mots[0]} inversé est {mots[1]} c'est un palindrome.");
            }
            else
            {
                Console.WriteLine($"Le mot {mots[0]} inversé est {mots[1]} ce n'est pas un palindrome.");
            }
        }
    }
}
