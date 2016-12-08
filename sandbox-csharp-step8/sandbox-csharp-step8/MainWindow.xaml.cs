using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sandbox_csharp_step8 {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private Mover mover;
        private Liquid liquid;

        private double tempsTotalMillisecond;
        private Stopwatch stopWatch;

       /* L'objectif est de pouvoir calculer le temps entre 2 frames, appelé deltaTime. Pour cela, utiliser la
classe Stopwatch qui permet de manipuler le temps de façon précise.Créer trois champs, lastTime
(long), currentTime(long), stopwatch(Stopwatch) et initialiser-les dans le constructeur.*/

        private int countFrame;


        public MainWindow() {

            InitializeComponent();
            mover = new Mover(50, 25, -100, this.canvas);

            // Ajout du liquide
            double windowHeight = this.canvas.Height;
            double windowWidth = this.canvas.Width;

            double liquidWidth = 150;
            double liquidHeight = 100;

            double liquidX = 0;
            double liquidY = windowHeight - liquidHeight * 2;

            liquid = new Liquid(liquidX, liquidY, liquidWidth, liquidHeight, 50, this.canvas);

            stopWatch = new Stopwatch();
            stopWatch.Start();

            // Refresh frame (déplacement de l'objet)
            countFrame = 0;
            CompositionTarget.Rendering += update;

            //System.Threading.Thread.Sleep(2000);

            //stopWatch.Stop();

        }

        public void update(Object sender, EventArgs e) {
            Vector gravite = new Vector();
            gravite.Y = 50;
            mover.applyForce(gravite);
            mover.update();
            mover.display();
            mover.checkEdges(400);

            //Console.WriteLine(liquid.contains(mover));

            countFrame++;
            textBoxFrame.Text = "Frame : " + countFrame;
            //Console.WriteLine(countFrame);

            TimeSpan ts = stopWatch.Elapsed;
            double tempPasseMilliseconds = ts.Milliseconds;
            tempsTotalMillisecond += tempPasseMilliseconds;

            if (tempsTotalMillisecond > 10000) {
                textBoxFramePerSecond.Text = "FPS : " + String.Format("{0:0.0000}", (countFrame / tempsTotalMillisecond)*1000);
                countFrame = 0;
                tempsTotalMillisecond = 0;
            }

        }

    }
}
