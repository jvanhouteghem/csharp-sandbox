using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step1
{
    class Pierre : Choix {

        public override void initialize() {
            this.Nom = PIERRE;
            this.GagneContre = CISEAUX;
            this.PerdContre = FEUILLE;
        }

    }
}
