using System.Collections.Generic;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FruitsEtLegumes
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


        /* FONCTIONS */
        
        // Fonction qui demande de saisir un légume et son prix retire les espaces et renvoie une chaine de caractères
        static string DemanderLegumeEtPrix(string message)
        {
            string saisieUtilisateur;
            while (true)
            {
                try
                {
                    Console.Write(message);
                    saisieUtilisateur = Console.ReadLine();
                    foreach (char ch in saisieUtilisateur)
                    {
                        if (ch.Equals(" "))
                        {
                            saisieUtilisateur.Replace(" ", "");
                        }
                    }
                    return saisieUtilisateur;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        // Fonction qui sépare le légume et le prix puis affecte les 2 chaines de caractères dans une liste et renvoie la liste.
        static List<string> AjouterLegumePrix(string saisieLegumePrix)
        {
            List<string> legumePrix = new List<string>() { "0", "0"};
;           string alphaNum = "0123456789";
            bool estUnNombre = false;
            

            int indexPrix = 0;
            
            while (!estUnNombre && indexPrix < saisieLegumePrix.Length)
            {
                int indexNum = 0;
                while (!estUnNombre && indexNum < alphaNum.Length)
                {
                    if (saisieLegumePrix[indexPrix].Equals(alphaNum[indexNum]))
                    {
                        estUnNombre = true;
                    }
                    indexNum++;
                }
                indexPrix++;
            }
            legumePrix[1] = saisieLegumePrix.Substring(indexPrix-1);
            int indexLegume = saisieLegumePrix.Length - legumePrix[1].Length;
            legumePrix[0] = saisieLegumePrix.Substring(0, indexLegume);
            return legumePrix;
        }

        // Fonction qui trouve et renvoie l'index du légume le moins cher
        static int TrouverIndexMoinsCher(List<List<string>> _listeLegumes)
        {
            int indexMoinsCher = 0;
            string prixFormat = _listeLegumes[0][1];
            float prixmoinsCher = float.Parse(prixFormat, CultureInfo.InvariantCulture.NumberFormat);
            for (int i = 0; i < _listeLegumes.Count - 1; i++)
            {
                if (float.Parse(_listeLegumes[i][1], CultureInfo.InvariantCulture.NumberFormat) < prixmoinsCher)
                {
                    indexMoinsCher = i;
                }
            }
            return indexMoinsCher;
        }

        // Fonction pour afficher les légumes leurs prix et le légume le moins cher
        static void AfficherLegumes(List<List<string>> _listeLegumes, int _index)
        {
            for (int i = 0; i < _listeLegumes.Count; i++)
            {
                Console.WriteLine("1 kilogramme de " + _listeLegumes[i][0] + " coûte " + _listeLegumes[i][1] + " euros.");
            }
            Console.WriteLine("\nLégume le moins cher au kilo : " + _listeLegumes[_index][0]);
        }
        static void Main(string[] args)
        {
            /* VARIABLES */

            string message = "Légume et prix ou go pour finir : ";
            string saisieUtilisateur = "";
            List<List<string>> listeLegumes = new List<List<string>>();
            int index = 0;

            /* TRAITEMENT */

            Console.WriteLine("Saisir un légume et son prix au kilo (ex : carottes 2.99) ou go pour afficher le résultat.");
            do
            {
                saisieUtilisateur = DemanderLegumeEtPrix(message);
                if(!saisieUtilisateur.Equals("go") && saisieUtilisateur.Length > 5)
                {
                    listeLegumes.Add(AjouterLegumePrix(saisieUtilisateur));
                }

            } while (saisieUtilisateur != "go");

            index = TrouverIndexMoinsCher(listeLegumes);

            /* AFFICHAGE */

            if (saisieUtilisateur.Equals("go"))
            {
                Console.WriteLine();
                AfficherLegumes(listeLegumes, index);
            }
        }
    }
}
