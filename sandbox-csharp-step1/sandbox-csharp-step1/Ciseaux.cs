using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step1
{
    class Ciseaux : Choix
    {

        public override void initialize()
        {
            this.Nom = CISEAUX;
            this.GagneContre = FEUILLE;
            this.PerdContre = PIERRE;
        }

    }
}
