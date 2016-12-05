using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step1
{

    interface CoupInterface {

        /**
         * @Input(coupJoue) : le coup du joueur 1
         * @Input (coupAdversaire) : le coup de l'advsersaire
         * @Output : true si le joueur 1 gagne.
         */
        int comparer(String coupJoue, String coupAdversaire);

    }

    abstract class Choix : CoupInterface
    {
        public const String PIERRE = "pierre";
        public const String FEUILLE = "feuille";
        public const String CISEAUX = "ciseaux";

        // Le nom du coup (pierre, feuille, ciseaux etc)
        string nom; // par défaut la visibilité est private
        public string Nom { get; set; }

        // Le coup contre lequel il gagne (pierre, feuille, ciseaux etc)
        string gagneContre; 
        public string GagneContre { get; set; }

        // Le coup contre lequel il perd (pierre, feuille, ciseaux etc)
        string perdContre; 
        public string PerdContre { get; set; }

        // Définition du choix (nom, gagneContre, perdContre)
        public abstract void initialize();

        public bool comparer() {
            return true;
        }

        /**
         * @Input(coupJoue) : le coup du joueur 1
         * @Input (coupAdversaire) : le coup de l'advsersaire
         * @Output : 0 perdu, 1 égalité, 2 gagné
         */
        public int comparer(string coupJoue, string coupAdversaire) {
            int result = 0;
            if (coupJoue == coupAdversaire) {
                result = 1;
            }
            else if (GagneContre == coupAdversaire) {
                result = 2;
            } 
            return result;
        }
    }

}
