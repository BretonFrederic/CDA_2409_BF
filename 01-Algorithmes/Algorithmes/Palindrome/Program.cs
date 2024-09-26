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

        // Fonction qui demande et renvoie un message à l'utilisateur
        static string DemanderMessageUtilisateur()
        {
            int compteurPoint = 0;
            bool pointFin = false;
            string phrase = "";

            Console.Write("Entrer une phrase : ");
            phrase = Console.ReadLine();

            // Contrôler si il n'y a que des points dans la chaîne de caractère
            foreach (char ch in phrase)
            {
                if (ch == '.')
                {
                    compteurPoint++;
                }
            }

            // Vérifier si il y a un point final
            if (phrase.Length > 0)
            {
                if (phrase[phrase.Length - 1] == '.')
                {
                    pointFin = true;
                }
                if (compteurPoint == phrase.Length)
                {
                    Console.WriteLine("La phrase ne contient que des points");
                    return DemanderMessageUtilisateur();
                }
            }

            if (pointFin)
            {
                return phrase;
            }
            else if(phrase == "")
            {
                Console.WriteLine("La phrase est vide.");
                return DemanderMessageUtilisateur();
            }
            else
            {
                Console.WriteLine("Il manque le point final");
                return DemanderMessageUtilisateur();
            }
        }

        // Fonction qui cherche si la phrase est un palindrome et renvoie une boleen
        static bool RechercherPalindrome(string phr)
        {
            string phraseInversee = "";
            string phrOrigineInversee = "";

            // Retirer le point final et les espaces
            phrOrigineInversee = phr.Remove(phr.Length - 1);
            phr = phr.Remove(phr.Length - 1).Replace(" ", "");
            

            // Inverser la phrase
            phraseInversee = new string(phr.Reverse().ToArray());
            phrOrigineInversee = new string(phrOrigineInversee.Reverse().ToArray());

            // Contrôler si phrase palindrome ou pas
            if (phr == phraseInversee)
            {
                Console.WriteLine($"phrase inversée : {phrOrigineInversee}");
                return true;
            }
            else
            {
                return false;
            }
        }

        // Fonction qui affiche si la phrase est palindrome ou pas
        static void AfficherReponse(bool p)
        {
            if (!p)
            {
                Console.WriteLine("la chaîne de caractères n’est pas un palindrome");
            }
            else if (p)
            {
                Console.WriteLine("la chaîne de caractères est un palindrome");
            }
        }

        static void Main(string[] args)
        {
            /* VARIABLES */
            string phrase;
            bool estPalindrome;

            /* TRAITEMENT */
            phrase = "";
            estPalindrome = false;

            // Demander une phrase à l'utilisateur
            phrase = DemanderMessageUtilisateur();

            // Contrôler si la phrase est un palindrome
            estPalindrome = RechercherPalindrome(phrase);

            /* AFFICHAGE */
            AfficherReponse(estPalindrome);
        }
    }
}
