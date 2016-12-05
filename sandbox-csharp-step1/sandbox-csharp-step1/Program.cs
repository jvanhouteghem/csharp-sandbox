using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step1
{
    class Program
    {
        static void Main(string[] args){

            // Initialize
            Pierre pierre = new Pierre();
            Feuille feuille = new Feuille();
            Ciseaux ciseaux = new Ciseaux();

            // Store into array of object
            System.Collections.ArrayList listChoix = new System.Collections.ArrayList();
            listChoix.Add(pierre);
            listChoix.Add(feuille);
            listChoix.Add(ciseaux);

            Random random = new Random();

            int nbPartie = 10;

            for (int i = 0; i < nbPartie; i++) {

                int randomPlayer1 = random.Next(0, 2);
                String coupPlayer1 = ((Choix)listChoix[randomPlayer1]).Nom;

                int randomPlayer2 = random.Next(0, 2);
                String coupPlayer2 = ((Choix)listChoix[randomPlayer2]).Nom;

                //Console.WriteLine(randomPlayer1 + " " + randomPlayer2);

                Console.WriteLine(coupPlayer1 + " " + coupPlayer2 + " " + ((Choix)listChoix[randomPlayer1]).comparer(coupPlayer1, coupPlayer2));

            }

            Console.ReadKey();

        }
    }
}
