namespace MaRetraite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES */

            int age;

            /* CONSTANTES */

            const int retraite = 60;

            /* DEBUT DE PROGRAMME */

            //Demande à l'utilisateur de rentrer son âge
            Console.Write("Entrer votre âge : ");
            age = int.Parse(Console.ReadLine());

            //Condition qui valide ou invalide l'age de la retraite et affiche un message en fonction de la situation
            if (age > retraite)
            {
                int diff = age - retraite;
                Console.WriteLine("Vous êtes à la retraite depuis " + diff + " années.");
            }
            else if (age < retraite)
            {
                int diff = retraite - age;
                Console.WriteLine("Il vous reste " + diff + " année(s) avant la retraite.");
            }
            else if (age == retraite)
            {
                Console.WriteLine("C'est le moment de prendre sa retraite.");
            }
            else
            {
                Console.WriteLine("La valeur fournie n'est pas un âge valide.");
            }
            /* FIN DE PROGRAMME */
        }
    }
}
