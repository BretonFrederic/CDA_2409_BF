using ClassLibraryBouteille;

namespace ConsoleAppBouteille
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bouteille myBottle = new Bouteille("Vittel", 1f, 5f);
            myBottle.Ouvrir();
            myBottle.Vider(0.7f);
            myBottle.Remplir(0.5f);
            myBottle.Remplir(0.2f);
        }
    }
}
