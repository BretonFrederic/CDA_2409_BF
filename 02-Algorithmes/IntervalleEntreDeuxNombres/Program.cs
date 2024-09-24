using System;
using System.Linq;

namespace IntervalleEntreDeuxNombres
{
    /*
    Exercice 3a.3 : Intervalle entre 2 nombres.
    Lire 2 nombres entier A et B puis afficher tous les nombres entier dans l’intervalle.
    */
    class Program
    {
        // Fonction qui demande un nombre à l'utilisateur
        static int DemanderNombreUtilisateur()
        {
            int nombre;
            while (true)
            {
                try
                {
                    Console.Write("Entrer un nombre : ");
                    nombre = int.Parse(Console.ReadLine());
                    return nombre;
                }
                catch
                {
                    Console.WriteLine("ERREUR : Donnée invalide.");
                }
            }
        }

        // Fonction qui créer un tableau de nombres de l'intervalle de 2 nombres
        static List<int> NombresDeIntervalle(int nbr1, int nbr2)
        {
            bool ordreDecroissant = false;
            List<int> intervalle = new List<int>();
            //nbr1 plus petit que nbr2
            int temp;
            if (nbr1 > nbr2)
            {
                temp = nbr1;
                nbr1 = nbr2;
                nbr2 = temp;
                ordreDecroissant = true;
            }

            // Création de la liste de nombres
            for (int i = nbr1; i <= nbr2; i++)
            {
                intervalle.Add(i);
            }

            if (ordreDecroissant)
            {
                intervalle = intervalle.OrderDescending().ToList();
            }
            return intervalle;
        }

        // Fonction qui affiche une liste de nombres
        static void AfficherListeNombres(List<int> nombres)
        {
            for (int i = 0; i < nombres.Count; i++)
            {
                System.Console.Write(nombres[i] + " ");
            }
        }

        static void Main(string[] args)
        {
            /* VARIABLES */

            int nombre1, nombre2;
            List<int> nombres = new List<int>();

            /* TRAITEMENT */

            //L'utilisateur entre les 2 nombres
            nombre1 = DemanderNombreUtilisateur();
            nombre2 = DemanderNombreUtilisateur();
            System.Console.WriteLine("");

            //Déterminer les nombres de l'intervalle
            nombres = NombresDeIntervalle(nombre1, nombre2);

            /* AFFICHAGE */

            AfficherListeNombres(nombres);
        }
    }
}