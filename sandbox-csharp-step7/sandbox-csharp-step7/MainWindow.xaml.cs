using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sandbox_csharp_step7 {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private Mover mover;
        private Liquid liquid;


        public MainWindow() {

            InitializeComponent();
            mover = new Mover(50, 25, -100, this.canvas);

            // Ajout du liquide
            double windowHeight = this.canvas.Height;
            double windowWidth = this.canvas.Width;

            double liquidWidth = 150;
            double liquidHeight = 100;

            double liquidX = 0;
            double liquidY = windowHeight - liquidHeight*2;

            liquid = new Liquid(liquidX, liquidY, liquidWidth, liquidHeight, 50,this.canvas);

            // Refresh frame (déplacement de l'objet)
            CompositionTarget.Rendering += update;
        }
        public void update(Object sender, EventArgs e) {
            Vector gravite = new Vector();
            gravite.Y = 50;
            mover.applyForce(gravite);
            mover.update();
            mover.display();
            mover.checkEdges(400);

            Console.WriteLine(liquid.contains(mover));

        }

    }
}
