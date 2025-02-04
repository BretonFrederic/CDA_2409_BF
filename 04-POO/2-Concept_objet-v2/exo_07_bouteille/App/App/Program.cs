using System.Linq.Expressions;

namespace App
{
    internal class Program
    {
        // Choisir la quantité à remplir ou vider
        static public double ChoisirQuantite()
        {
            double quantiteDeplacee = 0.0;
            Console.Write("Choisir la quantité en litres (ex : 0,7) : ");
            bool nombreValide = double.TryParse(Console.ReadLine(), out quantiteDeplacee);
            if (!nombreValide && quantiteDeplacee <= 0 || quantiteDeplacee < 0)
            {
                Console.WriteLine("Erreur saisie quantité en litres supérieur à 0. Le séparateur doit être une virgule.");
                return ChoisirQuantite();
            }
            return quantiteDeplacee;
        }

        static public void AfficherInfo(Bouteille _bouteille)
        {
            string etatBouchon = "fermée";
            if (_bouteille.estOuverte)
            {
                etatBouchon = "ouverte";
            }
            Console.WriteLine("La bouteille {0} est {1} elle contient {2} / {3} litres.", _bouteille.marque, etatBouchon, _bouteille.quantite, _bouteille.volume);
        }
        static void Main(string[] args)
        {
            bool quitter = false;

            Bouteille bouteilleVittel = new Bouteille("Vittel", "eau", 1.5, 1.5);

            do
            {
                int menu = 0;
                while (menu < 1 || menu > 6)
                {
                    AfficherInfo(bouteilleVittel);
                    Console.WriteLine("\nChoisir :\n\t1 - Ouvrir la bouteille" +
                                              "\n\t2 - Fermer la bouteille" +
                                              "\n\t3 - Vider la bouteille" +
                                              "\n\t4 - Remplir la bouteille" +
                                              "\n\t5 - Vider toute la bouteille" +
                                              "\n\t6 - Remplir toute la bouteille");
                    try
                    {
                        menu = int.Parse(Console.ReadLine()?? "");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                switch (menu)
                {
                    case 1:
                        bouteilleVittel.Ouvrir();
                        break;
                    case 2:
                        bouteilleVittel.Fermer();
                        break;
                    case 3:
                        Console.WriteLine("Vous avez choisi Vider.");
                        bouteilleVittel.Vider(ChoisirQuantite());
                        break;
                    case 4:
                        Console.WriteLine("Vous avez choisi Remplir.");
                        bouteilleVittel.Remplir(ChoisirQuantite());
                        break;
                    case 5:
                        Console.WriteLine("Vous avez choisi Vider toute la bouteille.");
                        bouteilleVittel.ViderTout();
                        break;
                    case 6:
                        Console.WriteLine("Vous avez choisi Remplir toute la bouteille.");
                        bouteilleVittel.RemplirTout();
                        break;
                    default:
                        // Console.WriteLine("Saisie menu incorrect.");
                        break;
                }

                Console.Write("Entrer q pour quitter ou n'importe quelle autre pour continuer :");
                if(Console.ReadKey().Key.ToString().Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    quitter = true;
                }
                Console.WriteLine();
                Console.WriteLine();
            } while (!quitter);

        }
    }
}
