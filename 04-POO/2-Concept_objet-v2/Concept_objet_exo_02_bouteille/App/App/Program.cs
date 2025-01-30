using System.Linq.Expressions;

namespace App
{
    internal class Program
    {
        // Choisir la quantité à remplir ou vider
        static public double ChoisirQuantite()
        {
            double quantite = 0;
            Console.WriteLine("Choisir la quantité en litre : ");
            if(int.TryParse(Console.ReadLine(), out quantite){
                //
            }
            return 0.0;
        }
        static void Main(string[] args)
        {
            char quitter = ' ';

            Bouteille BouteilleVittel = new Bouteille("Vittel", "eau", 1.5, 1.5);

            do
            {
                int menu = 0;
                while (menu < 1 || menu > 4)
                {
                    Console.WriteLine("\nChosir :\n\t1 - Ouvrir la bouteille" +
                                              "\n\t2 - Fermer la bouteille" +
                                              "\n\t3 - Vider la bouteille" +
                                              "\n\t4 - Remplir la bouteille");
                    try
                    {
                        menu = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                }

                switch (menu)
                {
                    case 1:
                        if (BouteilleVittel.Ouvrir())
                        {
                            Console.WriteLine("La bouteille a été ouverte.");
                        }
                        else
                        {
                            Console.WriteLine("La bouteille est déjà ouverte.");
                        }
                        break;
                    case 2:
                        if (BouteilleVittel.Fermer())
                        {
                            Console.WriteLine("La bouteille a été fermée.");
                        }
                        else
                        {
                            Console.WriteLine("La bouteille est déjà fermée.");
                        }
                        break;
                    case 3:
                        if (BouteilleVittel.Vider())
                        {
                            Console.WriteLine("La bouteille a été vidée.");
                        }
                        else
                        {
                            Console.WriteLine("La bouteille est fermée ou déjà vide.");
                        }
                        break;
                    case 4:
                        if (BouteilleVittel.Remplir())
                        {
                            Console.WriteLine("La bouteille a été remplie.");
                        }
                        else
                        {
                            Console.WriteLine("La bouteille est fermée ou déjà remplie au maximum de sa capacité.");
                        }
                        break;
                    default:
                        //
                        break;
                }

                Console.Write("Entrer q pour quitter ou n'importe quelle autre pour continuer :");
            } while (!Console.ReadKey().Key.ToString().Equals("q", StringComparison.OrdinalIgnoreCase));

        }
    }
}
