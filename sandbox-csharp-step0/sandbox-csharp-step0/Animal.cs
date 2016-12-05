using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    abstract class Animal
    {

        int age; // par défaut la visibilité est private
        public int Age { get; set; }
        abstract public string sexe();
        abstract public string toString();

    }
}
