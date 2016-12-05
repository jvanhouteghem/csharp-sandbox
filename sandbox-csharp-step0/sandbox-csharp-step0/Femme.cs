using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    class Femme : Personne
    {

        // A constructor with two arguments:
        public Femme(string nom_, int age_)
        {
            this.Nom = nom_;
            this.Age = age_;
        }

        public Femme() {

        }

        public override void court()
        {
            Distance += 9;
        }

        public override void marche()
        {
            Distance += 7;
        }

        public override string sexe()
        {
            return "femme";
        }

        public override string toString()
        {
            return "Nom : " + Nom + " - Sexe : " + sexe() + " - Age : " + Age + " - Distance parcourue : " + Distance;
        }
    }
}

