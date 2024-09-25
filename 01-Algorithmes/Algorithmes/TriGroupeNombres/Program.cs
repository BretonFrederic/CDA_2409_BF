namespace TriGroupeNombres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES */

            int[] nombres = new int[] { 22, 15, 181 };
            int temp = 0;

            /* DEBUT PROGRAMME */

            //Boucles de triage des nombres ordre décroissant
            for (int j = 0; j < nombres.Length - 1; j++)
            {
                for (int i = 0; i < nombres.Length - 1; i++)
                {
                    if (nombres[i] < nombres[i + 1])
                    {
                        temp = nombres[i + 1];
                        nombres[i + 1] = nombres[i];
                        nombres[i] = temp;
                        temp = 0;
                    }
                }
            }


            //Boucle affichage des nombres triés
            for (int i = 0; i < nombres.Length; i++)
            {
                string nbre = nombres[i].ToString();
                Console.Write(nbre + " ");
            }

            /* FIN PROGRAMME */
        }

    }
}
