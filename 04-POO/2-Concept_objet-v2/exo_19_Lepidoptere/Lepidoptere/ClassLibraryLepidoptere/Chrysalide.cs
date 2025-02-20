using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLepidoptere
{
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
}
