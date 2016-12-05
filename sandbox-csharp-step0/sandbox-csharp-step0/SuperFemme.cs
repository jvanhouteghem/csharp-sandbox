using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{

    interface Pouvoir
    {
        void vol();
    }

    class SuperFemme : Femme, Pouvoir
    {
        static int instance = 0;

        public SuperFemme(string nom_, int age_) : base(nom_, age_)
        {
            instance++;
        }

        public SuperFemme()
        {
            instance++;
        }

        public void vol()
        {
            Distance += 25;
            ///throw new NotImplementedException();
        }

        public override string toString()
        {
            return "Instance : " + instance + " - Nom : " + Nom + " - Sexe : " + sexe() + " - Age : " + Age + " - Distance parcourue : " + Distance;
        }
    }
}
