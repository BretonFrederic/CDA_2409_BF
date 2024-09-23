namespace TriNombres
{
    internal class Program
    {
        static int DemanderNombreUtilisateur()
        {
            int nombre;
            while(true)

            {
                try
                {
                    //Demande à l'utilisateur d'entrer un nombre
                    Console.Write("Entrer le nombre A : ");
                    nombre = int.Parse(Console.ReadLine());
                    return nombre;
                }
                catch
                {
                    System.Console.WriteLine("ERREUR : Vous devez entrer un nombre.");
                }
            }
        }

        static void TriNombres(int nb1, int nb2)
        {
            //Condition pour tri et affichage ordre croissant
            if(nb1 < nb2)
            {
                Console.Write(nb1.ToString() + ", " + nb2.ToString());
            }
            else
            {
                Console.Write(nb2.ToString() + ", " + nb1.ToString());
            }
        }

        static void Main(string[] args)
        {
            /* VARIABLES */

            int nombreA, nombreB;

            /* DEBUT PROGRAMME */

            //Demande à l'utilisateur d'entrer un nombre A
            nombreA = DemanderNombreUtilisateur();

            //Demande à l'utilisateur d'entrer un nombre B
            nombreB = DemanderNombreUtilisateur();

            //Fonction de tri de nombres
            TriNombres(nombreA, nombreB);

            /* FIN PROGRAMME */
        }
    }
}

