using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryBouteille
{
    public class Bouteille
    {
        // Attributs
        private string? nom;
        private double capaciteEnLitres;
        private double contenanceEnLitres;
        private bool estOuverte;

        // Constructeur par défaut
        public Bouteille()
        {
            nom = "vittel";
            capaciteEnLitres = 1.5;
            contenanceEnLitres = 1.5;
            estOuverte = false;
        }

        // constructeur principal
        public Bouteille(string nom, double capaciteEnLitres, double contenanceEnLitres, bool estOuverte)
        {
            this.nom = nom;
            this.capaciteEnLitres = capaciteEnLitres;
            this.contenanceEnLitres = contenanceEnLitres;
            this.estOuverte = estOuverte;
        }

        // constructeur hybride
        public Bouteille(string nom, double capaciteEnLitres, double contenanceEnLitres) : this(nom, capaciteEnLitres, contenanceEnLitres, false)
        {

        }

        // Méthodes
        public bool Ouvrir()
        {
            if(this.estOuverte)
            {
                return false;
            }
            else
            {
                estOuverte = true;
                return true;
            }
        }

        public bool Fermer()
        {
            if (!this.estOuverte)
            {
                return false;
            }
            else
            {
                estOuverte = false;
                return true;
            }
        }

        public bool Vider()
        {
            if (!this.estOuverte)
            {
                return false;
            }
            else
            {
                this.contenanceEnLitres = 0;
                return true;
            }
        }
    }
}
