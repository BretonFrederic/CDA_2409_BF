namespace DenombrerLettresAlphabetTableau
{
    internal class Program
    {
        /* CONSIGNE */

        // Exercice 5.3 : Dénombrer les lettres de l’alphabet dans un tableau
        // Lire un texte d’au moins 120 caractères(à contrôler).
        // Compter et afficher le nombre d’occurrences(d’apparitions) de chacune des lettres de l’alphabet.

        /* FONCTIONS */
        static void Main(string[] args)
        {
            /* VARIABLES */
            string texte;
            const int nombreCharacteres = 200;
            bool texteValide;
            string alphabet;
            Dictionary<char, int> occurences;

            /* TRAITEMENT */
            occurences = new Dictionary<char, int>();
            texteValide = false;
            alphabet = "abcdefghijklmnopqrstuvwxyz";

            // 1 Texte valide 200 caractères
            texte = " La vie est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.  – Albert Einstein"+
                    " La vie est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.  – Albert Einstein";

            // 2 texte invalide pas égal à 200 caractères
            //texte = "La vie est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.» – Albert Einstein";

            // Contrôler nombre de caractères vaut 120
            if (nombreCharacteres != texte.Length)
            {
                texteValide = false;
            }
            else if(nombreCharacteres == texte.Length)
            {
                // Initialisation dictionnaire avec lettres alphabet et occurences
                foreach (char ch in alphabet)
                {
                    occurences.Add(ch, texte.Where(lettre => lettre.ToString().Equals(ch.ToString(), StringComparison.OrdinalIgnoreCase)).Count());
                }
                texteValide = true;
            }

            /* AFFICHAGE */
            if (texteValide)
            {
                Console.WriteLine($"Dans le texte : {texte}\n");
                foreach(char ch in alphabet)
                {
                    Console.WriteLine("La lettre " + ch + " apparaît : " + occurences[ch]);
                }
                
            }
            else if (!texteValide)
            {
                Console.WriteLine("Le texte contient " + texte.Length + " il doit en contenir 200 caractères.");
            }
        }
    }
}
