namespace ClassLibraryLepidoptere
{
    public abstract class StadeEvolution
    {
        public abstract StadeEvolution SeMetamorphoser();
        public abstract void SeDeplacer();
    }

    public class Oeuf :StadeEvolution
    {
        public Oeuf()
        {

        }
        public override StadeEvolution SeMetamorphoser()
        {
            return new Chenille();
        }
        public override void SeDeplacer()
        {
            Console.WriteLine("Je peux pas !");
        }

    }

    public class Chenille : StadeEvolution
    {
        public Chenille()
        {

        }
        public override StadeEvolution SeMetamorphoser()
        {
            return new Chrysalide();
        }
        public override void SeDeplacer()
        {
            Console.WriteLine("Je peux ramper !");
        }

    }

    public class Chrysalide : StadeEvolution
    {
        public Chrysalide()
        {

        }
        public override StadeEvolution SeMetamorphoser()
        {
            return new Papillon();
        }
        public override void SeDeplacer()
        {
            Console.WriteLine("Je peux pas je suis en mutation !");
        }

    }

    public class Papillon : StadeEvolution
    {
        public Papillon()
        {

        }
        public override StadeEvolution SeMetamorphoser()
        {
            return new Chenille();
        }
        public override void SeDeplacer()
        {
            Console.WriteLine("Je peux voler !");
        }

    }
    public class Lepidoptere
    {
        private string espece;
        private StadeEvolution? sonStadeCourant;

        // Constructeur
        public Lepidoptere(string espece)
        {
            this.espece = espece;
            this.sonStadeCourant = new Oeuf();
        }

        // Méthodes
        public void SeMetamorphoser()
        {
            this.sonStadeCourant.SeMetamorphoser();
        }
        public void SeDeplacer()
        {
            this.sonStadeCourant.SeDeplacer();
        }
    }
}
