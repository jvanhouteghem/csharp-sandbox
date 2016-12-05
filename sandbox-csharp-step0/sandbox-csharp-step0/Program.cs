using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    class Program
    {
        static void Main(string[] args)
        {

            Homme homme = new Homme("jean", 30);
            homme.marche(); homme.marche(); homme.court();

            Femme femme = new Femme("gaelle", 20);
            femme.court(); femme.marche(); femme.court();

            Console.WriteLine(homme.toString() + " \n" + femme.toString());

            SuperFemme superfemme = new SuperFemme();
            superfemme.vol(); superfemme.vol();
            SuperFemme superfemme2 = new SuperFemme("WonderWoman", 62);
            superfemme2.vol();
            Console.WriteLine(superfemme.toString() + " /n " + superfemme2.toString());
            Console.ReadKey();

            Console.ReadKey();

        }
    }
}
