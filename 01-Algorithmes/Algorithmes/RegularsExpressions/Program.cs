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
                    prenom = Console.ReadLine();
                }

                Console.WriteLine("Bonjour " + prenom);
            }
            catch
            {
                Console.WriteLine("Contactez le service informatique.");
            }

            try
            {
                string? dateNaissance;

                Console.WriteLine("Entrer votre date de naissance : ");
                dateNaissance = Console.ReadLine();

                String formatDate = @"^[\d]{2}/[\d]{2}/[\d]{4}$";

                while (!Regex.IsMatch(dateNaissance, formatDate, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Saisissez une année de naissance valide !");
                    dateNaissance = Console.ReadLine();
                }

                Console.WriteLine("Votre année de " + dateNaissance);
            }
            catch
            {
                Console.WriteLine("Date de naissance invalide.");
            }

            try
            {
                string? mail;

                Console.WriteLine("Entrer votre mail : ");
                mail = Console.ReadLine();

                String formatMail = @"^[\w\-\.]+@[\w\-\.]+\.[a-zA-Z]{2,}$";

                while(!Regex.IsMatch(mail, formatMail, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Saisissez une adresse mail valide !");
                    mail = Console.ReadLine();
                }

                Console.WriteLine("Votre adresse mail " + mail);
            }
            catch
            {
                Console.WriteLine("Adresse mail invalide.");
            }
        }
    }
}
