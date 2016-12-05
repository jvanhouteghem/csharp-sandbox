using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    abstract class Personne : Animal
    {

        private string nom;
        public string Nom { get; set; }
        private string distance;
        public int Distance { get; set; }
        abstract public void marche();
        abstract public void court();

    }
}
