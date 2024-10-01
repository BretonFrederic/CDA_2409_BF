namespace FruitsEtLegumes01
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 6.1 : Les fruits et légumes

        // L’utilisateur peut saisir des noms de légumes.Pour chaque légume, l’utilisateur précise un prix au kilo.
        // Exemple : “carottes 2.99”
        // Lorsque l’utilisateur saisit la valeur “go”, le programme affiche la liste des légumes avec leur prix ainsi que le légume le moins cher.
        // Exemple :
        // 1 kilogramme de carottes coute 2.99 euros.
        // 1 kilogramme de poireaux coute 1.99 euros.
        // [...]
        // Légume le moins cher au kilo : poireaux
        static void Main(string[] args)
        {
            /* VARIABLES */
            string nomsLegumes = "";
            string saisieUtilisateur = "";

            /* TRAITEMENT */
            //saisieUtilisateur = DemanderLegumePrix();
            //static string DemanderLegumePrix()
            //{
                int i = 0;
                int indexDebut = 0;
                int indexFin = 0;
                string alphaNum = "0123456789";
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                Console.Write("Saisir un légume et son prix : ");
                string saisie = Console.ReadLine();

                // Chercher indexDepart prix
                while( i < saisie.Length && indexDebut == 0)
                {
                    foreach(char c in alphaNum)
                    {
                        if (saisie[i].Equals(c))
                        {
                            indexDebut = i;
                        }
                    }
                    i++;
                }

            // Chercher indexFin prix
            i = indexDebut;
            while (i < saisie.Length)
            {
                foreach (char c in alphabet)
                {
                    if (saisie[i].Equals(c))
                    {
                        indexFin = i-1;
                    }
                }
                i++;
            }


            // return saisie;
            //}

            /* AFFICHAGE */
            Console.WriteLine(saisieUtilisateur);
            Console.WriteLine(index);
        }
    }
}
