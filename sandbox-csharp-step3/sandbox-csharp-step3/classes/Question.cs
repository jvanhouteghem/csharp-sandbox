using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step3.classes {

    class Question {

        /*Classe Question
        Créer un répertoire « classes » pour ranger l'ensemble des classes.
        Créer une classe « Question »dans l’espace de nom CESI.VOSINITIALES.TestPerso avec 3 attributs :
        « catégorie » (entier), « question » (chaîne de caractères) et « reponse » (booléen).
        Créer les accesseurs de ces 3 attributs.
        Créer une méthode toString() qui retourne une chaîne de caractères avec les libellés et les valeurs des
        3 attributs.*/

        public Question(int categorie, string question) {
            this.categorie = categorie;
            this.question = question;
        }

        public int categorie { get; set; }
        public string question { get; set; }
        public bool reponse { get; set; }

        public string toString() { // public override string toString() {
            return "categorie : " + categorie + " - question : " + question + " - reponse : " + reponse;
        }

    }
}
