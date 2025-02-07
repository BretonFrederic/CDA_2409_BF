using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibraryBouteille
{
    public class Bouteille
    {
        // Attributs
        public string? nom { get; private set; }
        public double capaciteEnLitre { get; init; }
        public double contenanceEnLitre { get; private set; }
        public bool estOuverte { get; private set; }

        /*
        // Constructeur par défaut
        public Bouteille()
        {
            nom = "Vittel";
            capaciteEnLitre = 15;
            contenanceEnLitre = 15;
            estOuverte = false;
        }

        // constructeur classique
        public Bouteille(string nom, double capaciteEnLitre, double contenanceEnLitre, bool estOuverte)
        {
            this.nom = nom;
            this.capaciteEnLitre = capaciteEnLitre;
            this.contenanceEnLitre = contenanceEnLitre;
            this.estOuverte = estOuverte;
        }

        // constructeur hybride (interdépendance)
        public Bouteille(string nom, double capaciteEnLitre, double contenanceEnLitre) : this(nom, 
                                                                                                capaciteEnLitre, 
                                                                                                contenanceEnLitre, 
                                                                                                false)
        {

        }

        // constructeur par clonage
        public Bouteille(Bouteille bouteilleACopier)
        {
            nom = bouteilleACopier.nom;
            capaciteEnLitre = bouteilleACopier.capaciteEnLitre;
            contenanceEnLitre = bouteilleACopier.contenanceEnLitre;
            estOuverte = bouteilleACopier.estOuverte;
        }
        */

        // Constructeur par défaut (interdépendance)

        public Bouteille():this("Vittel", 1.5, 1.5, false)
        {
        }

        // constructeur principal classique
        public Bouteille(string nom, double capaciteEnLitre, double contenanceEnLitre, bool estOuverte)
        {
            this.nom = nom;
            this.capaciteEnLitre = capaciteEnLitre;
            this.contenanceEnLitre = contenanceEnLitre;
            this.estOuverte = estOuverte;
        }

        // constructeur hybride (interdépendance)
        public Bouteille(string nom, double capaciteEnLitre, double contenanceEnLitre) : this(nom,
                                                                                              capaciteEnLitre,
                                                                                              contenanceEnLitre,
                                                                                              false)
        {

        }

        // constructeur par clonage (interdépendance)
        public Bouteille(Bouteille bouteilleACopier):this(bouteilleACopier.nom, bouteilleACopier.capaciteEnLitre, bouteilleACopier.contenanceEnLitre, bouteilleACopier.estOuverte)
        {
        }

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
                this.contenanceEnLitre = 0;
                return true;
            }
        }

        public bool Vider(double quantiteEnLitre)
        {
            if (!this.estOuverte)
            {
                return false;
            }
            else if (quantiteEnLitre <= 0 || quantiteEnLitre > this.contenanceEnLitre)
            {
                throw new ArgumentException(String.Format("Erreur. La quantité à vider " +
                                                          "ne peut pas être inférieur à 0 Litre ou supérieur à {0} Litre.", 
                                                          this.contenanceEnLitre), nameof(quantiteEnLitre));
                //return false;
            }
            else
            {
                this.contenanceEnLitre -= quantiteEnLitre;
                return true;
            }
        }

        public bool Remplir()
        {
            if (!this.estOuverte)
            {
                return false;
            }
            else
            {
                this.contenanceEnLitre = this.capaciteEnLitre;
                return true;
            }
        }

        public bool Remplir(double quantiteEnLitre)
        {
            double volumeLibreEnLitre = this.capaciteEnLitre - this.contenanceEnLitre;
            if (!this.estOuverte)
            {
                return false;
            }
            else if (quantiteEnLitre <= 0 || quantiteEnLitre > volumeLibreEnLitre)
            {
                throw new ArgumentException(String.Format("Erreur. La quantité à remplir " +
                                                          "ne peut pas être inférieur à 0 Litre ou supérieur à {0} Litre.",
                                                          volumeLibreEnLitre), nameof(quantiteEnLitre));
                //return false;
            }
            else
            {
                this.contenanceEnLitre += quantiteEnLitre;
                return true;
            }
        }
    }
}
