using System.Text.RegularExpressions;

namespace RegularsExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string? prenom;
                /*
                 Généralement, vous utilisez un type valeur nullable lorsque vous avez besoin de représenter la valeur non définie d’un type valeur sous-jacent. 
                Par exemple, une variable booléenne ou bool, ne peut être que true ou false. Toutefois, dans certaines applications, une valeur de variable peut 
                être non définie ou manquante. Par exemple, un champ de base de données peut contenir true ou false, ou il peut ne contenir aucune valeur, 
                c’est-à-dire NULL. Vous pouvez utiliser le type bool? dans ce scénario.
                 */
                Console.WriteLine("Entrer votre prénom : ");
                prenom = Console.ReadLine();

                String formatPrenom = "^[a-z]{2,32}$"; // longueur min/max prénom recherche internet

                while(!Regex.IsMatch(prenom, formatPrenom, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Saisissez un vrai prénom !");
                    Console.ReadLine();
                }

                Console.WriteLine("Bonjour " + prenom);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Contactez le service informatique.");
            }

            try
            {
                string? mail;

                Console.WriteLine("Entrer votre mail : ");
                mail = Console.ReadLine();

                String formatMail = "^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";
            }
        }
    }
}
