using FBretonTools;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace RestaurantCRM
{
    internal class Program
    {
        /*
        Solutionnez la problématique suivante dans une application en mode « Console » dans un des langages suivants : 
        C#.

        Au CRM, chaque stagiaire et chaque membre du personnel dispose d’une carte à son nom. 
        Pour régler les consommations avec la carte, il est nécessaire de l’alimenter en €. (Principe de la « carte prépayée »). 
        Pour régler un repas au restaurant du CRM, la carte est vérifiée :
        -   Les données de la carte correspondent-elle à une personne enregistrée ?
        -   Y’a-t-il suffisamment de fonds disponibles ?
        Si les contrôles sont validés, le prix du repas est soustrait de la somme disponible sur la carte.

        Votre travail consiste à développer l’algorithme de validation de la carte.

        Pour simuler le fonctionnement, l’algorithme sera programmé dans une application en mode ‘Console’. 
        -   Le tableau ‘utilisateurs’ contiendra 5 utilisateurs.
        -   Le prix du repas sera fixé à 4 €
        -   Il n’est pas possible d’être « à découvert »
         */

        /* FONCTIONS */

        static void Main(string[] args)
        {
            /* VARIABLES */
            string[] utilisateurs = new string[] {"Fabrice", "Benjamin", "Marie", "Laurent", "Jerome"};
            string[] sommes = new string[] { "65", "18", "3", "5", "0" };
            int sommeInt;
            const int PRIX_REPAS = 4;
            string saisie;
            bool utilisateurValide = false;

            /* TRAITEMENT */
            // Les données de la carte correspondent-elle à une personne enregistrée ?
            Console.Write("Saisir un nom : ");
            saisie = Console.ReadLine() ?? "";
            for(int i = 0; i < utilisateurs.Length; i++)
            {
                if (saisie.Equals(utilisateurs[i]))
                {
                    utilisateurValide = true;
                    Console.WriteLine("Carte valide.");
                    Console.Write("Nom : " + utilisateurs[i] + "\nNuméro de carte : " + (i+1) + "\nsolde : " + sommes[i] + " euros." + " ");
                    // Y’a-t-il suffisamment de fonds disponibles ?
                    if (int.TryParse(sommes[i], out sommeInt))
                    {
                        // le prix du repas est soustrait de la somme disponible sur la carte.
                        if (sommeInt >= PRIX_REPAS)
                        {
                            sommeInt -= PRIX_REPAS;
                            Console.WriteLine();
                            Console.WriteLine("Repas : " + PRIX_REPAS + " euros.");
                            Console.WriteLine("Nouveau solde : " + sommeInt);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Repas : " + PRIX_REPAS + " euros.");
                            Console.WriteLine("Votre solde est insuffisant.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("somme invalide.");
                    }
                }
            }
            if (!utilisateurValide)
            {
                Console.WriteLine("Carte non enregistrée.");
            }



            /* AFFICHAGE */
        }
    }
}
