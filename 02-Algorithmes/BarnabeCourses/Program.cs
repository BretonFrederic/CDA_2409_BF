using System;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Text;

namespace BarnabeCourses
{
    class Program
    {
        /* CONSIGNE */

        // Exercice 3a.7 : Barnabé fait ses courses

        // Barnabé fait ses courses dans plusieurs magasins.
        // Dans chacun, il dépense 1 € de plus que la moitié de ce qu’il possédait en entrant.
        // Dans le dernier magasin, il dépense le solde.
        // Soit la somme S dont il disposait au départ (S > 1 €).
        // Représenter l’algorithme permettant de trouver le nombre de magasins dans lesquels il a acheté.

        /* FONCTIONS */

        // Fonction qui trouve et renvoie le nombre de magasins visités
        static int DefinirMagasinVisiter(int solde)
        {
            int nbrMagasins = 0;
            while (solde > 0)
            {
                if (solde == 1)
                {
                    solde = 0;
                }
                else if (solde % 2 == 0)
                {
                    solde = solde / 2 - 1;
                }
                else if (solde % 2 != 0)
                {
                    solde = (solde - 1) / 2;
                }
                nbrMagasins++;
            }
            return nbrMagasins;
        }
        static void Main(string[] args)
        {
            /* VARIABLES */
            const int soldeDepart = 180;
            int soldeActuelle;
            int nombreMagasins;


            /* TRAITEMENT */
            soldeActuelle = soldeDepart;
            nombreMagasins = 0;

            // Trouver nombre de magasins dans lesquels Barnabé a acheté
            nombreMagasins = DefinirMagasinVisiter(soldeActuelle);



            /* AFFICHAGE */
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Le solde de départ de Barnabé était de : " + soldeDepart + " €");
            Console.WriteLine("Barnabé a fait ses courses, il a acheté dans " + nombreMagasins + " magasins");
        }
    }
}
