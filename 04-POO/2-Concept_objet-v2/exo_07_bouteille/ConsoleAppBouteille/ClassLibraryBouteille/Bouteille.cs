using System.Net.Sockets;

namespace ClassLibraryBouteille
{
    public class Bouteille
    {
        // Attributs
        public string? nom { get; private set; }
        public float capaciteEnLitre { get; init; }
        public float contenuEnLitre { get; private set; }
        public bool estOuverte { get; private set; }

        // Constructeur par défaut (interdépendance)

        /// <summary>
        /// Définit l'instance de Bouteille avec des paramètres par défaut.
        /// </summary>
        public Bouteille() : this("Vittel", 1.5f, 1.5f, false)
        {
        }

        // constructeur principal classique

        /// <summary>
        /// Définit l'instance de Bouteille prend les paramètres nom, capaciteEnLitre, contenuEnLitre, estOuverte.
        /// </summary>
        /// <param name="nom">Argument de type string</param>
        /// <param name="capaciteEnLitre">Argument de type float</param>
        /// <param name="contenuEnLitre">Argument de type float</param>
        /// <param name="estOuverte">Argument de type bool</param>
        public Bouteille(string nom, float capaciteEnLitre, float contenuEnLitre, bool estOuverte)
        {
            this.nom = nom;
            this.capaciteEnLitre = capaciteEnLitre;
            this.contenuEnLitre = contenuEnLitre;
            this.estOuverte = estOuverte;
            
        }

        // constructeur hybride (interdépendance)

        /// <summary>
        /// Définit l'instance de Bouteille prend en paramètres, nom, capaciteEnLitre, contenuEnLitre.
        /// Constructeur par interdépendance :this dernier paramètre défini par défaut sur false.
        /// </summary>
        /// <param name="nom">Argument de type string</param>
        /// <param name="capaciteEnLitre">Quantité max du volume Bouteille en litre de type float.</param>
        /// <param name="contenuEnLitre">Quantité à l'intérieur de Bouteille en litre de type float</param>
        public Bouteille(string nom, float capaciteEnLitre, float contenuEnLitre) : this(nom,
                                                                                              capaciteEnLitre,
                                                                                              contenuEnLitre,
                                                                                              false)
        {
            
        }

        // constructeur par clonage (interdépendance)

        /// <summary>
        /// Définit l'instance de Bouteille prend en paramètre un objet bouteilleACopier de type Bouteille.
        /// bouteilleACopier doit avoir un autre constructeur.
        /// </summary>
        /// <param name="bouteilleACopier">Obj : Argument de type Bouteille</param>
        public Bouteille(Bouteille bouteilleACopier) : this(bouteilleACopier.nom="", bouteilleACopier.capaciteEnLitre, bouteilleACopier.contenuEnLitre, bouteilleACopier.estOuverte)
        {

        }

        /// <summary>
        /// Ouvre la bouteille
        /// </summary>
        /// <returns>True si la bouteille était déjà fermée. False si la bouteille était déjà ouverte.</returns>
        public bool Ouvrir()
        {
            if (this.estOuverte)
            {
                return false;
            }
            else
            {
                estOuverte = true;
                return true;
            }
        }

        /// <summary>
        /// Ferme la bouteille
        /// </summary>
        /// <returns>True si la bouteille était déjà ouverte. False si la bouteille était déjà fermée.</returns>
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

        /// <summary>
        /// Vide entièrement la bouteille si elle est ouverte.
        /// </summary>
        /// <returns>True si la bouteille est ouverte et vidée. False si la bouteille est fermée.</returns>
        public bool Vider()
        {
            if (!this.estOuverte)
            {
                return false;
            }
            else
            {
                this.contenuEnLitre = 0;
                return true;
            }
        }

        /// <summary>
        /// Vider une quantité choisie en litre dans la bouteille.
        /// </summary>
        /// <param name="quantiteEnLitre">Quantité en litre à vider</param>
        /// <returns>True si la bouteille est ouverte et a été vidée. False si la bouteille est fermée.</returns>
        /// <exception cref="ArgumentException">la quantiteEnLitre est inférieur à 0 ou supérieur à la contenance de la bouteille</exception>
        public bool Vider(float quantiteEnLitre)
        {
            if (!this.estOuverte)
            {
                return false;
            }
            else if (quantiteEnLitre <= 0 || quantiteEnLitre > this.contenuEnLitre)
            {
                throw new ArgumentException(String.Format("Erreur. La quantité à vider " +
                                                          "ne peut pas être inférieur à 0 Litre ou supérieur à {0} Litre.",
                                                          this.contenuEnLitre), nameof(quantiteEnLitre));
                //return false;
            }
            else
            {
                this.contenuEnLitre -= quantiteEnLitre;
                return true;
            }
        }

        /// <summary>
        /// Remplir entièrement la bouteille.
        /// </summary>
        /// <returns>True si la bouteille est ouverte et a été remplie. False si la bouteille est fermée.</returns>
        public bool Remplir()
        {
            if (!this.estOuverte)
            {
                return false;
            }
            else
            {
                this.contenuEnLitre = this.capaciteEnLitre;
                return true;
            }
        }

        /// <summary>
        /// Remplir une quantité choisie en litre dans la bouteille.
        /// </summary>
        /// <param name="quantiteEnLitre">Quantité en litre à remplir</param>
        /// <returns>True si la bouteille est ouverte et a été rempli. False si la bouteille est fermée.</returns>
        /// <exception cref="ArgumentException">la quantiteEnLitre est inférieur à 0 ou supérieur à la contenance de la bouteille</exception>
        public bool Remplir(float quantiteEnLitre)
        {
            float volumeLibreEnLitre = this.capaciteEnLitre - this.contenuEnLitre;
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
                this.contenuEnLitre += quantiteEnLitre;
                return true;
            }
        }
    }
}

