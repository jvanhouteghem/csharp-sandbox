using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_csharp_step4 {
    public partial class Form1 : Form {

        // Graphics est l'élément sur lequel on dessine
        private Graphics g;

        public Form1() {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

            // Méthode similaire
            g = panel1.CreateGraphics();

            int panelWidth = this.Size.Width;
            int panelHeight = this.Size.Height;
            Console.WriteLine("h : " + panelHeight + " - " + "w" + panelWidth);

            Pen blackPen = new Pen(Color.Black, 3);
            Brush[] myBrush = new Brush[9];
            myBrush[0] = new SolidBrush(Color.Gray);
            myBrush[1] = new SolidBrush(Color.DarkRed);
            myBrush[2] = new SolidBrush(Color.Yellow);
            myBrush[3] = new SolidBrush(Color.Violet);
            myBrush[4] = new SolidBrush(Color.Blue);
            myBrush[5] = new SolidBrush(Color.Brown);
            myBrush[6] = new SolidBrush(Color.Green);
            myBrush[7] = new SolidBrush(Color.Black);
            myBrush[8] = new SolidBrush(Color.Orange);

            // Create location and size of ellipse.
            // xPanel, le centre du grand cercle
            float xPanel = panelWidth/6;
            float yPanel = panelHeight/6;
            float widthEllipse = 200; // 355; 314
            float heightEllipse = 200;

            float rayon = widthEllipse / 2;

            float centerCerclePrincipalX = panelWidth / 2 - rayon; // panelWidth / 2 désigne le point en haut à gauche du carré contenant le cercle, pour avoir le centre on rajoute le rayon
            float centerCerclePrincipalY = panelHeight / 2 - rayon;

            // Draw ellipse to screen.
            g.DrawEllipse(blackPen, centerCerclePrincipalX, centerCerclePrincipalY, widthEllipse, heightEllipse);

            int nbPoints = 9;

            for (int i = 1; i < nbPoints+1; i++) {

                double angle = Math.PI/2;
                angle += Math.PI * 2 / nbPoints * i; // Rajouter un quart de cercle

                float rayonPetitCercle = 15;

                double positionXPetitCercle = panelWidth/2 - Math.Cos(angle) * rayon - rayonPetitCercle/2;
                double positionYPetitCercle = panelHeight/2 - Math.Sin(angle) * rayon - rayonPetitCercle/2;              

                g.FillEllipse(myBrush[i-1], (float)positionXPetitCercle, (float)positionYPetitCercle, rayonPetitCercle, rayonPetitCercle);

            }
        }
    }
}
