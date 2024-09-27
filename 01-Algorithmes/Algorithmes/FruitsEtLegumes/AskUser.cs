using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsEtLegumes
{
    internal class AskUser
    {
        /* VARIABLES */
        private string message { get; set; }
        private string reponse { get; set; }
        private int nombre { get; set; }

        /* CONSTRUCTEUR */
        public AskUser(string _message, int _nombre)
        {
            _message = this.message;
            _nombre = this.nombre;
        }

        public AskUser(string _message, string _reponse)
        {
            _message = this.message;
            _reponse = this.reponse;
        }

        /* METHODES */

        // Demande et renvoie un nombre
        public int DemanderNombreUtilisateur()
        {
            Console.WriteLine(this.message);
            try
            {
                this.nombre = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("ERREUR : Vous devez entrer un nombre.");
            }
            return this.nombre;
        }

        // Demande et renvoie un nombre
        public string DemanderStringUtilisateur()
        {
            Console.WriteLine(this.message);
            try
            {
                this.message = Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return this.message;
        }
    }
}
