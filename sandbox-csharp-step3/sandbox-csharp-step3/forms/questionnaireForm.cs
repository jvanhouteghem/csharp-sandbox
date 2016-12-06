using sandbox_csharp_step3.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_csharp_step3.forms {
    public partial class questionnaireForm : Form {

        private TestPersonnalite testPersonnalite;
        private Question q;
        /*TextBox txtBox;
        Button btnCMoi;
        Button btnCPasMoi;*/

        public questionnaireForm() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Console.WriteLine("clic oui");

            // Si c'est pas la dernière question
            if (testPersonnalite.questionnaireTermine() == false) {

                testPersonnalite.tableauReponse[testPersonnalite.indexQuestion - 1]++;

                q = testPersonnalite.questionSuivante();
                textBox1.Text = q.question;
            }
            // Sinon afficher résultat
            else {
                String titre = "Questionnaire Terminé";
                String message = testPersonnalite.resultatToString();
                DialogResult d = MessageBox.Show(message, titre);

                // Ecriture
                testPersonnalite.ecritureFichier.Write(message); // écriture de la chaîne de caractère dans le fichier
                testPersonnalite.ecritureFichier.Close(); // fermeture du fichier
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Console.WriteLine("clic non");

            // Si c'est pas la dernière question
            if (testPersonnalite.questionnaireTermine() == false) {

                testPersonnalite.tableauReponse[testPersonnalite.indexQuestion - 1]++;

                q = testPersonnalite.questionSuivante();
                textBox1.Text = q.question;
            }
            // Sinon afficher résultat
            else {
                String titre = "Questionnaire Terminé";
                String message = testPersonnalite.resultatToString();
                DialogResult d = MessageBox.Show(message, titre);

                // Ecriture
                testPersonnalite.ecritureFichier.Write(message); // écriture de la chaîne de caractère dans le fichier
                testPersonnalite.ecritureFichier.Close(); // fermeture du fichier
            }

        }

        private void questionnaireForm_Load(object sender, EventArgs e) {
            testPersonnalite = new TestPersonnalite();
            q = testPersonnalite.questionSuivante();
            textBox1.Text = q.question;
        }
    }
}
