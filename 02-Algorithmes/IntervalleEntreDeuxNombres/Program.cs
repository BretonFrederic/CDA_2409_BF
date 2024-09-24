using System;

namespace IntervalleEntreDeuxNombres
{
    /*
    Exercice 3a.3 : Intervalle entre 2 nombres.
    Lire 2 nombres entier A et B puis afficher tous les nombres entier dans l’intervalle.
    */
    internal class Program
    {
        //Fonction qui demande un nombre à l'utilisateur
        static int DemanderNombreUtilisateur()
        {
            int nombre;
            while(true)
            {
                try
                {
                    Console.WriteLine("Entrer un nombre : ");
                    nombre = int.Parse(Console.ReadLine());
                    return nombre;
                }
                catch
                {
                    System.Console.WriteLine("ERREUR : Donnée invalide.");
                }
            }
        
        //Fonction qui créer un tableau de nombres de l'intervalle de 2 nombres
        static List<int> NombresDeIntervalle(int nbr1, int nbr2)
        {
            List<int> intervalle = new List<int>();
            if(nbr2 > nbr1)
            {
                intervalle.Add(nbr1);
                for(int i = nbr1; i < nbr2; i++)
                {
                    intervalle.Add(i);
                }
                intervalle.Add(nbr2);
            }
            else if(nbr1 > nbr2)
            {
                intervalle.Add(nbr2);
                for(int i = nbr2; i < nbr1; i++)
                {
                    intervalle.Add(i);
                }
                intervalle.Add(nbr1);
            }
            return intervalle;
        }

        //Fonction qui affiche une liste de nombres
        static void AfficherListeNombres(List<int> nombres)
        {
            //
        }
            
        }
        static void Main(string[] args)
        {
            /* VARIABLES */
            int nombre1, nombre2;
            List<int> nombres = new List<int>();

            /* DEBUT PROGRAMME */
            //L'utilisateur entre les 2 nombres
            nombre1 = DemanderNombreUtilisateur();
            nombre2 = DemanderNombreUtilisateur();

            //Déterminer les nombres de l'intervalle
            nombres = NombresDeIntervalle(nombre1, nombre2);

            //Afficher le résultat

            /* FIN PROGRAMME */
        }
    }
}