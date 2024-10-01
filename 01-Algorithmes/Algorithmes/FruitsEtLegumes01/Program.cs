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
            string[,] tableauLegumesEtPrix;

            /* TRAITEMENT */

            while (saisieUtilisateur != "go")
            {
                Console.Write("Saisir un légume et son prix : ");
                saisieUtilisateur = Console.ReadLine();
                int i = 0;
                while (i < saisieUtilisateur.Length)
                {
                    int j = 0;
                    while (j < alphaNum.Length)
                    {
                        // Détecter le prix chiffre précédé d'un espace cas particulier pomme de terre 1.80
                        if (saisieUtilisateur[i] == alphaNum[j] && saisieUtilisateur[i - 1] == ' ')
                        {
                            // compteur de légumes
                            nombreLegumes++;

                            // Affecter le légume et son prix. Ajouter un séparateur
                            nomsLegumes += saisieUtilisateur+"\n";
                            // Retour vers choix saisir ou go pour finir
                            i = saisieUtilisateur.Length;
                            j = alphaNum.Length;
                        }
                        j++;
                    }
                    i++;
                }
            }

            // Remplir tableau éléments légumes et prix

            float prixMoinsCher = 1000.0f;
            tableauLegumesEtPrix = new string[nombreLegumes, 2];
            int indexLegumesPrix = 0;
            int indexPrixMoinsCher = 0;


            for (int i = 0; i < nomsLegumes.Length; i++)
            {
                for(int j = 0; j < alphaNum.Length; j++)
                {
                    if (nomsLegumes.Length != 0)
                    {
                        if (nomsLegumes[i] == alphaNum[j] && nomsLegumes[i - 1] == ' ')
                        {
                            tableauLegumesEtPrix[indexLegumesPrix, 0] = nomsLegumes.Substring(i - i, i - 1);
                            nomsLegumes = nomsLegumes.Remove(i - i, i);
                            i -= i;
                        }
                        if (nomsLegumes[i] == '\n')
                        {
                            tableauLegumesEtPrix[indexLegumesPrix, 1] = nomsLegumes.Substring(i - i, i);
                            nomsLegumes = nomsLegumes.Remove(i - i, i + 1);

                            // Trouver index prix moins cher
                            if(float.Parse(tableauLegumesEtPrix[indexLegumesPrix, 1]) < prixMoinsCher)
                            {
                                indexPrixMoinsCher = i;
                            }
                            prixMoinsCher = float.Parse(tableauLegumesEtPrix[indexLegumesPrix, 1]);

                            indexLegumesPrix++;
                            i = 0;
                        }
                    }
                    
                }
            }
           
            /* AFFICHAGE */

            Console.WriteLine("Légumes moins cher : " + tableauLegumesEtPrix[indexPrixMoinsCher, 0]);
            
        }
    }
}
