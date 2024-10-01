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
            string[][] legumesPrix;

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
                        if (saisieUtilisateur[i - 1] == ' ' && saisieUtilisateur[i] == alphaNum[j])
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

            legumesPrix = new string[nombreLegumes][];



            /* AFFICHAGE */
            Console.WriteLine("Chaine de caractères de légumes et prix : " + "\n"+ nomsLegumes);
            Console.WriteLine("Nombre de légumes : " + nombreLegumes);
        }
    }
}
