using System;
using FBretonTools;

namespace TriNombre
{
    class Program
    {
        static int DemanderNombreUtilisateur()
            {
                int nombre = 0;
                bool nombreValide = false;
                while(!nombreValide)
                {
                    System.Console.Write("Entrer un nombre : ");
                    try
                    {
                        nombre = int.Parse(Console.ReadLine());
                        nombreValide = true;
                    }
                    catch
                    {
                        System.Console.WriteLine("ERREUR : Vous devez entrer un nombre.");
                    }
                }
                return nombre;
            }
        static void Main(string[] args)
        {
            /* VARIABLES */
            int nombreA, nombreB, nombreC, temp;


            /* DEBUT PROGRAMME */

            //Recupère les nombres
            nombreA = ConsoleTools.DemanderNombreEntier("Entrer un nombre : ");
            nombreB = ConsoleTools.DemanderNombreEntier("Entrer un nombre : ");
            nombreC = ConsoleTools.DemanderNombreEntier("Entrer un nombre : ");
            temp = 0;
            
            //tri les nombres
            
            if(nombreA > nombreB)
            {
                temp = nombreB;
                nombreB = nombreA;
                nombreA = temp;
                temp = 0;
            }
            if (nombreA > nombreC)
            {
                temp = nombreC;
                nombreC = nombreA;
                nombreA = temp;
                temp = 0;
            }
            if (nombreB > nombreC)
            {
                temp = nombreB;
                nombreB = nombreC;
                nombreC = temp;
                temp = 0;
            }

            Console.WriteLine(nombreA + ", " + nombreB + ", " + nombreC);

            /* FIN PROGRAMME */
        }
    }
}
