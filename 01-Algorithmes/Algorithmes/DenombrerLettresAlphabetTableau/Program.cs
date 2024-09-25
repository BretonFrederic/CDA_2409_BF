namespace DenombrerLettresAlphabetTableau
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 5.3 : Dénombrer les lettres de l’alphabet dans un tableau
        // Lire un texte d’au moins 120 caractères(à contrôler).
        // Compter et afficher le nombre d’occurrences(d’apparitions) de chacune des lettres de l’alphabet.

        /* FONCTIONS */

        // Fonction qui renvoie un dictionnaire <clé(lettre), valeur(occurences)> pour les caractères de l'alphabet
        static Dictionary<char, int> CompterOccurencesCharDansTexte(string alphabet, string texte)
        {
            Dictionary<char, int> occurences = new Dictionary<char, int>();
            foreach (char ch in alphabet)
            {
                occurences.Add(ch, texte.Where(lettre => lettre.ToString().Equals(ch.ToString(), StringComparison.OrdinalIgnoreCase)).Count());
            }
            return occurences;
        }
        static void Main(string[] args)
        {
            /* VARIABLES */
            string alphabet;
            string texte;
            const int nombreCharacteres = 200;
            bool texteValide;
            Dictionary<char, int> occurencesLettres;

            /* TRAITEMENT */
            occurencesLettres = new Dictionary<char, int>();
            texteValide = false;
            alphabet = "abcdefghijklmnopqrstuvwxyz";


            // 1 Texte valide 200 caractères
            texte = " La vie est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.  – Albert Einstein"+
                    " La vie est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.  – Albert Einstein";

            // 2 texte invalide pas égal à 200 caractères
            //texte = "La vie est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.» – Albert Einstein";

            // Contrôler nombre de caractères vaut 120
            if(nombreCharacteres == texte.Length)
            {
                // Compter le nombre d’occurrences (d’apparitions) de chacune des lettres de l’alphabet dans le texte.
                occurencesLettres = CompterOccurencesCharDansTexte(alphabet, texte);
                texteValide = true;
            }

            /* AFFICHAGE */
            if (texteValide)
            {
                Console.WriteLine($"Dans le texte : {texte}\n");
                foreach(char ch in alphabet)
                {
                    Console.WriteLine("La lettre " + ch + " apparaît : " + occurencesLettres[ch]);
                }
                
            }
            else if (!texteValide)
            {
                Console.WriteLine("Le texte contient " + texte.Length + " il doit en contenir 200 caractères.");
            }
        }
    }
}
