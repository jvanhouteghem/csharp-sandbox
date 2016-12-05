using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    class Homme : Personne
    {

        // A constructor with two arguments:
        public Homme(string nom_, int age_)
        {
            this.Nom = nom_;
            this.Age = age_;
            this.Distance = 0;
        }

        public override void court()
        {
            Distance += 10;
        }

        public override void marche()
        {
            Distance += 5;
        }

        public override string sexe()
        {
            return "homme";
        }

        public override string toString()
        {
            return "Nom : " + Nom + " - Sexe : " + sexe() + " - Age : " + Age + " - Distance parcourue : " + Distance;
        }
    }
}
