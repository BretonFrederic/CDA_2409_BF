using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    internal class Bouteille
    {
        // CHAMPS
        public string? marque { private set; get; }
        public string? typeContenu { private set; get; }
        public double volume { private set; get; }
        public double quantite { private set; get; }
        public bool estOuverte { private set; get; }

        // CONSTRUCTEUR PAR DEFAUT
        public Bouteille()
        {
            this.marque = "inconnu";
            this.typeContenu = "eau";
            this.volume = 1.0;
            this.quantite = 1.0;
            this.estOuverte = false;
        }

        // CONSTRUCTEUR
        public Bouteille(string _marque, string _typeContenu, double _volume, double _quantite)
        {
            this.marque = _marque;
            this.typeContenu = _typeContenu;
            this.volume = _volume;
            this.quantite = _quantite;
            this.estOuverte = false;
        }

        // METHODES
        public bool Ouvrir()
        {
            if (!this.estOuverte)
            {
                this.estOuverte = true;
                Console.WriteLine("La bouteille a été ouverte.\n");
                return true;
            }
            else
            {
                Console.WriteLine("Echec. La bouteille est ouverte.\n");
                return false;
            }
        }

        public bool Fermer()
        {
            if (this.estOuverte)
            {
                this.estOuverte = false;
                Console.WriteLine("La bouteille a été fermée.\n");
                return true;
            }
            else
            {
                Console.WriteLine("La bouteille est déjà fermée.\n");
                return false;
            }
        }

        public void ViderTout()
        {
            if (this.estOuverte)
            {
                if (this.quantite > 0)
                {
                    this.quantite = 0;
                    Console.WriteLine($"La bouteille contient à présent {this.quantite} litre(s)");
                }
                else
                {
                    Console.WriteLine("La bouteille est déjà vide.");
                }

            }
            else
            {
                Console.WriteLine($"Echec, la bouteille bouteille est fermée.");
            }
        }

        public bool Vider(double _quantiteRetiree)
        {
            // Boolean retournée
            bool estVidee = false;

            if (_quantiteRetiree > 0)
            {
                // Projection de la nouvelle quantité du liquide dans la bouteille
                double nouvelleQuantite = this.quantite - _quantiteRetiree;

                if (this.estOuverte)
                {
                    if (this.quantite >= _quantiteRetiree)
                    {
                        // Bouteille ouverte on vide la bouteille
                        this.quantite = nouvelleQuantite;

                        // l'action vide a été réalisé
                        estVidee = true;
                        Console.WriteLine($"La bouteille contient à présent {this.quantite} litre(s)");
                    }
                    else
                    {
                        Console.WriteLine($"Echec, quantité à vider {_quantiteRetiree} litre(s), la bouteille contient {this.quantite}/{this.volume} litre(s).");
                    }

                }
                else
                {
                    Console.WriteLine("La bouteille est fermée !");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Echec vous avez saisie une valeur négative.");
            }
            return estVidee;
        }

        public void RemplirTout()
        {
            if (this.estOuverte)
            {
                if (this.quantite < this.volume)
                {
                    this.quantite = this.volume;
                    Console.WriteLine($"La bouteille contient à présent {this.quantite} litre(s)");
                }
                else
                {
                    Console.WriteLine("La bouteille est déjà pleine.");
                }

            }
            else
            {
                Console.WriteLine($"Echec, la bouteille est fermée.");
            }
        }

        public bool Remplir(double _quantiteAjoutee)
        {
            // Boolean retournée
            bool estRemplie = false;
            if (_quantiteAjoutee > 0)
            {
                // Projection de la nouvelle quantité du liquide dans la bouteille
                double nouvelleQuantite = _quantiteAjoutee + this.quantite;

                if (this.estOuverte)
                {
                    if (nouvelleQuantite <= this.volume)
                    {
                        // Bouteille ouverte on rempli la bouteille
                        this.quantite = nouvelleQuantite;

                        // l'action remplir a été réalisé
                        estRemplie = true;
                        Console.WriteLine($"La bouteille contient à présent {nouvelleQuantite} litre(s).");
                    }
                    else
                    {
                        Console.WriteLine($"Echec, quantité à remplir {_quantiteAjoutee} litre(s), la bouteille contient {this.quantite}/{this.volume} litre(s)");
                    }

                }
                else
                {
                    Console.WriteLine("La bouteille est ouverte !");
                }
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Echec vous avez saisie une valeur négative.");
            }
            return estRemplie;
        }
    }

}
