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
                
                String formatPrenom = "^[a-z]{2,32}$"; // longueur min/max prénom recherche internet

                do
                {
                    Console.WriteLine("Saisissez votre prénom : ");
                    prenom = Console.ReadLine();
                } while (!Regex.IsMatch(prenom, formatPrenom, RegexOptions.IgnoreCase)); // Comparer la saisie avec le format regex en ignorant la case

                Console.WriteLine("Bonjour " + prenom);
            }
            catch
            {
                Console.WriteLine("Contactez le service informatique.");
            }

            try
            {
                string? dateNaissance;
                DateTime datetime;

                do
                {
                    Console.WriteLine("Saisissez votre date de naissance : ");
                    dateNaissance = Console.ReadLine();

                } while (!DateTime.TryParse(dateNaissance, out datetime)); // Essayer de convertir la saisie en date 

                Console.WriteLine("Votre date de naissance est : " + dateNaissance);
            }
            catch
            {
                Console.WriteLine("Date de naissance invalide.");
            }

            try
            {
                string? mail;

                string formatMail = @"^[\w\-\.]+@[\w\-\.]+?\.[a-zA-Z]{2,6}$";

                do
                {
                    Console.WriteLine("Entrer votre mail : ");
                    mail = Console.ReadLine();
                } while (!Regex.IsMatch(mail, formatMail, RegexOptions.IgnoreCase));

                Console.WriteLine("Votre adresse mail est : " + mail);
            }
            catch
            {
                Console.WriteLine("Adresse mail invalide.");
            }
            
            try
            {
                string? numSecu;

                string formatNumSecu = @"^[1|2]{1}[\d]{2}(0[1-9]|10|11|12)[0-9][1-9]([0-9]{2}[1-9]){2}$";

                do
                {
                    Console.WriteLine("Entrer votre numéro de sécurité sociale : ");
                    numSecu = Console.ReadLine();
                } while (!Regex.IsMatch(numSecu, formatNumSecu, RegexOptions.IgnoreCase));

                Console.WriteLine("Votre numéro de sécurité sociale est : " + numSecu);
            }
            catch
            {
                Console.WriteLine("Numéro de sécurité sociale invalide.");
            }
        }
    }
}
