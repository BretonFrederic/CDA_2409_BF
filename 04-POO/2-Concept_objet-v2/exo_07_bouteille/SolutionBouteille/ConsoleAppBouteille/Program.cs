using ClassLibraryBouteille;

namespace ConsoleAppBouteille
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instance constructeur par défaut
            Bouteille vittel = new Bouteille();

            // Instance constructeur avec paramètres
            Bouteille evian = new Bouteille("Evian", 2, 2, false);

            // Instance constructeur hybride
            //Bouteille cristaline = new Bouteille("Cristaline", 0.5, 0.5);

            // instance constructeur par clonage
            Bouteille vittelClone = new Bouteille(vittel);

            // Tests comportements
            bool vittelTestOuvrir = vittel.Ouvrir();
            //vittelTestOuvrir = vittel.Ouvrir();

            bool vittelTestVider = vittel.Vider();
            //vittelTestVider = vittel.Vider();

            bool vittelTestRemplir = vittel.Remplir();
            //vittelTestRemplir = vittel.Remplir();

            bool vittelTestViderQuantite = vittel.Vider(0.7);
            //vittelTestViderQuantite = vittel.Vider(-0.9);

            bool vittelTestRemplirQuantite = vittel.Remplir(0.5);
            vittelTestRemplirQuantite = vittel.Remplir(0.2);

            bool vittelTestFermer = vittel.Fermer();
            //vittelTestFermer = vittel.Fermer();
        }
    }
}
