using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step3.classes {

    class TestPersonnalite {

        public int indexQuestion = 0;
        const int tailleTableauReponse = 9;
        const string nomFichierQuestion = "question.txt";
        const string nomFichierReponse = "reponse.txt";

        private int[] tableauReponse; // Liste des réponses par catégorie  {nbréponsecat1, nbréponsecat2 ...}
        private string repertoireProjet;
        public Question questioncourante;
        private StreamReader lectureFichier;
        private StreamWriter ecritureFichier;

        // no-args constructor
        public TestPersonnalite() {

            // Initialiser « tableauReponse » avec un tableau de « tailleTableauReponses » entier avec la valeur 0.
            tableauReponse = new int[tailleTableauReponse];

            //Initialiser « questionCourante » avec la valeur nulle.
            questioncourante = null;

            //Initialiser « repertoireProjet » à l’aide des classes Path et Directory.
            repertoireProjet = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            //Initialiser « lectureFichier » en créant un nouvel objet StreamReader avec le fichier « questions.txt ».
            System.IO.StreamReader lectureFichier; // déclaration
            //Console.WriteLine(repertoireProjet + nomFichierQuestion);
            lectureFichier = new System.IO.StreamReader(repertoireProjet + "/fichiers/" + nomFichierQuestion); // instanciation
            //String ligne = lectureFichier.ReadLine(); // lecture de la ligne courante
            //lectureFichier.Close(); // fermeture du fichier
            //lectureFichier.Dispose(); // libération de la mémoire

            //Initialiser « ecritureFichier » en créant un nouvel objet StreamWriter avec le fichier « reponses.txt ».*/
            ecritureFichier = new System.IO.StreamWriter(repertoireProjet + "/fichiers/" + nomFichierReponse); // instanciation
            //ecritureFichier.Write("test"); // écriture de la chaîne de caractère dans le fichier
            //ecritureFichier.Close(); // fermeture du fichier
        }

        /*Méthode questionSuivante()
        Permet de lire la ligne suivante du fichier « questions.txt ». La chaîne de caractère doit être
        décomposée, traduite et injectée dans un nouvel objet « Question ». 
        Cette question est ensuite assignée à l'attribut « questionCourante ». Cette méthode retourne la « questionCourante »*/
        public Question questionSuivante() {
            Question tmpQuestionCourante = new classes.Question(indexQuestion, "qa" + indexQuestion);
            questioncourante = tmpQuestionCourante;
            indexQuestion++;
            return tmpQuestionCourante;
        }

        /*Permet de comptabiliser les réponses par catégorie.
        Si la valeur du champ booléen réponse est vrai,
        alors ajouter 1 à la valeur de la catégorie correspondante dans le tableau de réponses(attention à la
        conversion indice/catégorie).*/
        public void ajouterReponse(Question q) {

            // Récupération de la réponse de la question
            bool qReponse = q.reponse;

            // Récupération de la catégorie
            int qCategorie = q.categorie;

            if (qReponse == true) {
                tableauReponse[qCategorie] ++;
            }
        }

        /*Permet d’afficher les résultats et la question courante dans la console.Faire appel aux méthodes
        existantes.*/
        public string afficherConsole() {
            return null;
        }

        /*La méthode doit retourner une chaîne de caractères contenant l'ensemble des résultats. Pour chaque
        élément, on rajoute à la chaîne une autre chaîne suivant le format :
        <indice du tableau + 1 (catégorie)>:<résultat><caractère fin ligne: \n>*/
        public string resultatToString() {
            string result = "";

            for (int i = 0; i < tableauReponse.Length; i++) {
                result += i + ":" + tableauReponse[i];
                if (i != tableauReponse.Length - 1) {
                    result += "\n";
                }
            }

            return result;
        }

        /*Enregistrer les résultats dans un fichier « reponses.txt », selon le format utilisé dans la méthode
        resultatToString().*/
        public void enregistrerResultat() {
            ecritureFichier.Write(resultatToString()); // écriture de la chaîne de caractère dans le fichier
            ecritureFichier.Close(); // fermeture du fichier
        }

    }
}
