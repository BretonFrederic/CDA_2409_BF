using FBretonTools;

namespace ListGenerateurPhrases
{
    internal class Program
    {
        /*
         Exercice phrases aléatoires

         Ecrire un programme qui demande à l'utilisateur d'entrer une liste de sujets, verbes, compléments. 
         Le programme doit assembler sujet verbe complément aléatoirement pour former une phrase à la 3 ème Pers. singulier.
         
         Exemple : Le chat + conduit + la voiture
         */
        static void Main(string[] args)
        {

            /* VARIABLES */
            Random rand = new Random();
            int indexRand = 0;

            List<string> sujets = new();
            string sujet = " ";

            List<string> verbes = new();
            string verbe = " ";

            List<string> complements = new();
            string complement = " ";

            List<List<string>> phrases = new();
            bool continuer = false;

            /* TRAITEMENT */
            Console.WriteLine("Vous devez saisir à la 3ème personne du singulier des sujets puis des verbes enfin des compléments.");
            Console.WriteLine("Par exemple\n\tsujet : Une grand-mère\tverbe : attrape\tcomplément : le soleil.");
            Console.WriteLine();
            
            

            do
            {
                // Récupère le string sujet
                sujet = ConsoleTools.DemanderString("Saisir un sujet : ");
                Console.WriteLine();
                sujets.Add(sujet);

                // Demande si l'utilisateur souhaite continuer à entrer un sujet
                continuer = ConsoleTools.DemanderChoixOuiNon();
                Console.WriteLine();
            } while (continuer);

            do
            {
                // Récupère le string verbe
                verbe = ConsoleTools.DemanderString("Saisir un verbe : ");
                Console.WriteLine();
                verbes.Add(verbe);

                // Demande si l'utilisateur souhaite continuer à entrer un verbe
                continuer = ConsoleTools.DemanderChoixOuiNon();
                Console.WriteLine();
            } while (continuer);

            do
            {
                // Récupère le string complément
                complement = ConsoleTools.DemanderString("Saisir un complément : ");
                Console.WriteLine();
                complements.Add(complement);

                // Demande si l'utilisateur souhaite continuer à entrer un complément
                continuer = ConsoleTools.DemanderChoixOuiNon();
                Console.WriteLine();
            } while (continuer);

            // Stocker les mots sujets verbes compléments dans des listes
            phrases.Add(sujets);
            phrases.Add(verbes);
            phrases.Add(complements);

            /* AFFICHAGE */

            indexRand = rand.Next(phrases[0].Count);
            Console.Write(phrases[0][indexRand] + " ");

            indexRand = rand.Next(phrases[1].Count);
            Console.Write(phrases[1][indexRand] + " ");

            indexRand = rand.Next(phrases[2].Count);
            Console.Write(phrases[2][indexRand]);
        }
    }
}

