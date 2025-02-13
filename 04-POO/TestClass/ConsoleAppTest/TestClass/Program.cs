namespace TestClass
{
    internal class Program
    {
        class Voiture
        {
            // Attributs
            public string? marque { get; init; }
            public string? modele { get; init; }
            public string? couleur { get; private set; }
            public int nbrePortes { get; init; }
            public string? typeMoteur { get; init; }


            // Constructeurs
            public Voiture()
            {
                this.marque = "peugeot";
                this.modele = "306";
                this.couleur = "rouge";
                this.nbrePortes = 3;

            }

            public Voiture(string marque, string modele, string couleur, int nbrePortes) : this()
            {

            }

            public Voiture(Voiture titine) : this()
            {

            }

            // Méthodes
        }
        static void Main(string[] args)
        {
            // test égalité Voiture cloner
            Voiture v1 = new Voiture("Citroën", "Xara", "bleue", 5);
            Voiture v2 = new Voiture(v1);

            Console.WriteLine(v1.Equals(v2) + " 2 objets différents car cloner");
            Console.WriteLine("HashCode de v1 : " + v1.GetHashCode());
            Console.WriteLine("HashCode de v2 : " + v2.GetHashCode());

            Console.WriteLine();

            // test égalité Voiture par référence
            Voiture v3 = new Voiture("Citroën", "Xara", "bleue", 5);
            Voiture v4 = v3;

            Console.WriteLine("v4 = v3 is " + v4.Equals(v3) + " car v4 pointe sur v3");
            Console.WriteLine("HashCode de v3 : " + v3.GetHashCode());
            Console.WriteLine("HashCode de v4 : " + v4.GetHashCode());
        }
    }
}
