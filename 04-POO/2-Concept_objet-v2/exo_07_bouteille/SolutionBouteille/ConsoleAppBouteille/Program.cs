using ClassLibraryBouteille;

namespace ConsoleAppBouteille
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instance constructeur par défaut
            Bouteille vittel = new Bouteille();
            
            // Instance constructeur avec paramètres
            Bouteille evian = new Bouteille("Evian", 2, 2, false);

            // Instance constructeur hybride
            Bouteille cristaline = new Bouteille("Cristaline", 0.5, 0.5);

            // comportements
            bool vittelOuverte = vittel.Ouvrir();
            vittelOuverte = vittel.Fermer();
            bool vittelVidee = vittel.Vider();
        }
    }
}
