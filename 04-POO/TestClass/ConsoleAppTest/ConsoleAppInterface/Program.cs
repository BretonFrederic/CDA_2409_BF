namespace ConsoleAppInterface
{
    // INTERFACE
    interface IMotorise
    {
        public abstract void ConsommerEnergie();
    }

    // TRANSPORT
    abstract class Transport
    {
        // attributs
        protected int vitesseEnKmh { get; set; }

        // pas de constructeur dans une class abstraite, ne peut pas être instancié

        // méthodes
        public abstract void Avancer();

        public void BaisserLaVitesse()
        {
            // code...
        }
    }

    // TRANSPORTAERIEN
    abstract class TransportAerien : Transport
    {
        public override void Avancer()

        {
            // code...
        }
    }

    // TRANSPORTMARITIME
    abstract class TransportMaritime : Transport
    {
        public override void Avancer()
        {
            // code...
        }
    }

    // AVION
    class Avion : TransportAerien, IMotorise
    {
        // attributs
        public string nom { get; init; }
        public string pilote { get; set; }

        // constructeur
        public Avion(string nom, string pilote)
        {
            this.nom = nom;
            this.pilote = pilote;
        }

        // méthodes
        public void ConsommerEnergie()
        {
            Console.WriteLine("L'avion a consommé du carburant");
        }
    }

    // CARGO
    class Cargo : TransportMaritime, IMotorise
    {
        // attributs
        public string nom { get; set; }
        public string capitaine { get; set; }
        public Avion avion { get; set; }

        // constructeur
        public Cargo(string nom, string capitaine, Avion avion)
        {
            this.nom = nom;
            this.capitaine = capitaine;
            this.avion = avion;
        }

        // méthode
        public void ConsommerEnergie()
        {
            Console.WriteLine("Le cargo a consommé du carburant");
        }

        public override void Avancer()
        {
            // code...
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // LISTE IMOTORISE
            List<IMotorise> transportsMotorises = new List<IMotorise>()
            {
                new Cargo("La Licorne", "Archibald Haddock", new Avion("Mirage 2000", "Ate Chuet")), new Avion("Boeing 747", "Ted Striker")
            };

            transportsMotorises[0].ConsommerEnergie();

            transportsMotorises[1].ConsommerEnergie();

            /**************************************************/

            Cargo leKaraboudjan = new Cargo("Le Karaboudjan", "Barbossa", new Avion("Tomcat", "Maverick"));
            Console.WriteLine($"Le capitaine du cargo {leKaraboudjan.nom} est {leKaraboudjan.capitaine}, il transport un {leKaraboudjan.avion.nom}");

        }
    }
}
