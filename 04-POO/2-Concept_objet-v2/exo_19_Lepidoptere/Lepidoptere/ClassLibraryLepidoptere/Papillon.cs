using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLepidoptere
{
    public class Papillon : StadeEvolution
    {
        public Papillon()
        {

        }
        public override StadeEvolution SeMetamorphoser()
        {
            return this;
        }
        public override void SeDeplacer()
        {
            Console.WriteLine("Je peux voler, je suis un papillon !");
        }

    }
}
