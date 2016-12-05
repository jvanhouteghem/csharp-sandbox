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

            // Count
            int equalCount = 0;
            int victoryCount = 0;
            int looseCount = 0;

            Random random = new Random();

            int nbPartie = 10;

            for (int i = 0; i < nbPartie; i++) {

                int randomPlayer1 = random.Next(0, 2);
                String coupPlayer1 = ((Choix)listChoix[randomPlayer1]).Nom;

                int randomPlayer2 = random.Next(0, 2);
                String coupPlayer2 = ((Choix)listChoix[randomPlayer2]).Nom;

                int resultat = ((Choix)listChoix[randomPlayer1]).comparer(coupPlayer1, coupPlayer2);

                Console.WriteLine(coupPlayer1 + " " + coupPlayer2 + " " + resultat );

                // Update count
                if (resultat == 0) {
                    equalCount++;
                } else if (resultat == 1) {
                    victoryCount++;
                } else {
                    looseCount++;
                }

            }

            Console.WriteLine("----------------");
            Console.WriteLine("Score final : \nJoueur 1 : " + victoryCount + " \nJoueur 2 : " + looseCount);

            String nomGagnant;
            if (victoryCount > looseCount) {
                nomGagnant = "Joueur 1";
            } else {
                nomGagnant = "Joueur 2";
            }

            Console.WriteLine("----------------");
            Console.WriteLine(nomGagnant + " gagne !");

            Console.ReadKey();

        }
    }
}
