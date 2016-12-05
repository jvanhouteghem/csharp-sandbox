using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step1 {

    class Feuille : Choix {

        public override void initialize()
        {
            this.Nom = FEUILLE;
            this.GagneContre = PIERRE;
            this.PerdContre = CISEAUX;
        }

    }
}
