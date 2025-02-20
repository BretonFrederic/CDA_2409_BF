using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLepidoptere
{
    public class Oeuf : StadeEvolution
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
}
