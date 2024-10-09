using FBretonTools;
using System.Text.RegularExpressions;
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
            string[] utilisateurs = new string[] {"", "Benjamin", "Marie", "Laurent", "Jerome"};
            string[] sommes = new string[] {"50", "18", "36", "45", "0"};
            const int PRIX_REPAS = 4;
            string carteValide = "^[a-zA-Z]{4,32}$";

            /* TRAITEMENT */
            for(int i = 0; i < utilisateurs.Length; i++)
            {
                if (Regex.IsMatch(utilisateurs[i], carteValide))
                {
                    Console.WriteLine("Carte " + (i+1) + " valide propriétaire : " + utilisateurs[i]);
                    Console.WriteLine("Fonds disponible : " + sommes[i]);
                    Console.WriteLine("Prix du repas : " + PRIX_REPAS);
                    int sommeInt = 0;
                    bool estConverti = false;
                    while (!estConverti)
                    {
                        try
                        {

                            sommeInt = Convert.ToInt32(sommes[i]);
                            if (sommeInt >= 4)
                            {
                                sommeInt -= PRIX_REPAS;
                                sommes[i] = Convert.ToString(sommeInt);
                                Console.WriteLine("Nouveau solde : " + sommes[i]);
                            }
                            else
                            {
                                Console.WriteLine("Solde insuffisante !");
                            }
                            estConverti = true;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Carte " + (i + 1) + " invalide");
                }
            }

            /* AFFICHAGE */
        }
    }
}
