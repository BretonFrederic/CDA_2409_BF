using System;

namespace MaBicyclette
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES */

            bool etatBicyclette = true;
            bool reparationRapide = true;
            bool beauDemain = true;
            bool monLivreGOT = false;
            bool livreGOTBiblio = false;
            bool romanBiblio = false;

            /* DEBUT PROGRAMME */

            if(beauDemain)
            {
                System.Console.WriteLine("Il fait beau demain. Faire balade bicyclette.");
                if(!etatBicyclette)
                {
                    System.Console.WriteLine("Bicyclette ne fonctionne pas. Passer chez le garagiste avant la balade.");
                    if(!reparationRapide)
                    {
                        System.Console.WriteLine("Réparation longue.");
                        System.Console.WriteLine("Renoncer à la balade en bicyclette.\nAller à l'étang à pied pour cueillir les joncs.");
                    }
                }
                if(etatBicyclette || reparationRapide)
                {
                    if(!etatBicyclette && reparationRapide)
                    {
                        System.Console.WriteLine("Réparation rapide de la bicyclette.");
                    }
                    if(etatBicyclette)
                    {
                        System.Console.WriteLine("La bicyclette est en bonne état.");
                    }
                    System.Console.WriteLine("j’irai faire une balade à bicyclette.");
                }
            }
            else if(!beauDemain)
            {
                System.Console.WriteLine("Il ne fait pas beau demain. Journée lecture.");
                if(!monLivreGOT)
                {
                    System.Console.WriteLine("Le livre Game of Thrones n'est pas dans la bibliothèque du salon.");
                    System.Console.WriteLine("Emprunter le livre Game of Thrones à la bibliothèque municipale.");
                    if(!livreGOTBiblio)
                    {
                        System.Console.WriteLine("Le livre Game of Thrones n'est pas à la bibliothèque municipale.");
                        System.Console.WriteLine("Emprunter un roman policier.");
                    }
                    else if(livreGOTBiblio)
                    {
                        System.Console.WriteLine("Le livre Game of Thrones est à la bibliothèque municipale.");
                    }
                    System.Console.WriteLine("Rentrer ensuite directement à la maison.");
                }
                else if(monLivreGOT)
                {
                    System.Console.WriteLine("Le livre Game of Thrones est dans la bibliothèque du salon.");
                }
                if(monLivreGOT || livreGOTBiblio)
                {
                    System.Console.WriteLine("Relire le 1er tome de Game of Thrones.");
                }
                romanBiblio = true;
                
                if(monLivreGOT || livreGOTBiblio || romanBiblio)
                {
                    System.Console.WriteLine("S’installer confortablement dans un fauteuil et me plonger dans la lecture.");
                }
                else
                {
                    System.Console.WriteLine("Aucun livres n'a été choisi.");
                }
            }

            /* FIN PROGRAMME */
        }
    }
}
