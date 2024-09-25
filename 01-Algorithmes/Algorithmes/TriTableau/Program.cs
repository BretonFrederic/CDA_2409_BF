using static System.Reflection.Metadata.BlobBuilder;
using System.Security.AccessControl;
using System;

namespace TriTableau;

class Program
{
    /* CONSIGNE */

    // Exercice 5.4 : Tri d’un tableau

    // Nous désignerons par a1, a2, …, aN les éléments d’un tableau à trier par ordre croissant.
    // Exemple: [128, 64, 8, 512, 16, 32, 256]
    // On commence par chercher l’indice du plus petit des éléments, soit j cet indice.
    // On permute alors les valeurs de a1(128) et aj(8).
    // Le tableau devient[8, 64, 128, 512, 16, 32, 256].
    // On cherche ensuite l’indice du plus petit des éléments entre a2 et aN et on permute avec a2.
    // Le tableau devient[8, 16, 128, 512, 64, 32, 256].
    // On cherche ensuite l’indice du plus petit des éléments a3, a4, …, aN etc…

    /* FONCTIONS */
    static void Main(string[] args)
    {
        /* VARIABLES */
        int[] tab;
        int indice;
        int temp;

        /* TRAITEMENT */
        tab = new int[] { 128, 64, 8, 512, 16, 32, 256 };

        indice = 0;
        for(int j = 0; j < tab.Length-1; j++)
        {
            indice = j;
            for (int i = j; i < tab.Length; i++)
            {
                if (tab[indice] > tab[i])
                {
                    indice = i;
                }
            }
            temp = tab[indice];
            tab[indice] = tab[j];
            tab[j] = temp;
            temp = 0;
        }


        /* AFFICHAGE */
        foreach(int element in tab)
        {
            Console.Write(element + " ");
        }
    }
}
