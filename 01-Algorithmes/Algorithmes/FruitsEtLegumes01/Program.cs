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
            string alphaNum = "0123456789";
            int nombreLegumes = 0;
            string[] legumesPrix;

            /* TRAITEMENT */

            while (saisieUtilisateur != "go")
            {
                Console.Write("Saisier un légume et son prix : ");
                saisieUtilisateur = Console.ReadLine();
                int i = 0;
                while (i < saisieUtilisateur.Length)
                {
                    int j = 0;
                    while (j < alphaNum.Length)
                    {
                        if (saisieUtilisateur[i] == alphaNum[j] && saisieUtilisateur[i - 1] == ' ')
                        {
                            nombreLegumes++;
                            nomsLegumes += saisieUtilisateur+"\n";
                            i = saisieUtilisateur.Length;
                            j = alphaNum.Length;
                        }
                        j++;
                    }
                    i++;
                }
            }

            legumesPrix = new string[nombreLegumes];
            int positionLegume = 0;

            for(int i = 0; i < nomsLegumes.Length; i++)
            {
                for(int j = 0; j < alphaNum.Length; j++)
                {
                    if (nomsLegumes[i] == '\n')
                    {
                        // stocker prix
                        legumesPrix[positionLegume] = nomsLegumes.Remove(i-1);
                        positionLegume++;
                        i = 0;
                    }
                    /*if (nomsLegumes[i] == alphaNum[j] && nomsLegumes[i - 1] == ' ')
                    {
                        // stocker légume
                        legumesPrix[0,0] = nomsLegumes.Remove(i);
                    }*/
                }
            }

            /* AFFICHAGE */
            Console.WriteLine("Chaine de caractères de légumes et prix : " + "\n"+ nomsLegumes);
            Console.WriteLine("Nombre de légumes : " + nombreLegumes);
            foreach(string l in legumesPrix)
            {
                Console.WriteLine("une chaine de caractères légume et prix : " + l);
            }
            
        }
    }
}
