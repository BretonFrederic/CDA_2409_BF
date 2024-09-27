using static System.Runtime.InteropServices.JavaScript.JSType;
using static FruitsEtLegumes.AskUser;

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

        // 
        static void Main(string[] args)
        {
            /* VARIABLES */
            string message = "Entrer un prix";
            Dictionary<string, float> ingredients = new Dictionary<string, float>();
            float prixMin = 0.0f;
            string fruitMoinsCher = "";
            AskUser demanderNombre = new AskUser(message, prixMin);

            /* TRAITEMENT */
            ingredients.Add("pommes", 2.42f);
            ingredients.Add("oranges", 2.99f);
            ingredients.Add("poires", 2.29f);

            prixMin = ingredients["pommes"];

            foreach (var ingredient in ingredients)
            {
                
                Console.WriteLine("1 kilogramme de {0} coute {1} euros.", ingredient.Key, ingredient.Value);
                if(prixMin > ingredient.Value)
                {
                    prixMin = ingredient.Value;
                    fruitMoinsCher = ingredient.Key;
                } 
            }

            /* AFFICHAGE */

            Console.WriteLine("Le fruit le moins cher au kilo : {0} {1}", fruitMoinsCher, prixMin);
        }
    }
}
