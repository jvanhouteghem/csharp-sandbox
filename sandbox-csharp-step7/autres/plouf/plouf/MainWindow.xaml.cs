using System;
using System.Windows;
using System.Windows.Media;

namespace plouf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        // exemple liquid
        Mover[] movers = new Mover[10];
        Liquid liquid;
        Random r;

        public MainWindow() {
            InitializeComponent();
        }

        void resetMovers() {
            for (int i = 0; i < movers.Length; i++) {
                double rd = 1 + 3 * r.NextDouble();
                double x = 40 + i * 70;

                movers[i] = new Mover(rd, x, 0, canvas);
            }
        }

        private void UpdateCanvasLiquid(object sender, EventArgs e) {
            // Draw water
            liquid.display();

            for (int i = 0; i < movers.Length; i++) {
                Mover m = movers[i];
                // Is the Mover in the liquid?
                if (liquid.contains(m)) {
                    // Calculate drag force
                    Vector drag = liquid.drag(m);

                    // Apply drag force to Mover
                    m.applyForce(drag);
                }

                // Gravity is scaled by mass here!
                Vector gravity = new Vector(0, 0.1 * m.mass);

                // Apply gravity
                m.applyForce(gravity);

                // Update and display
                m.update();
                m.display();
                m.checkEdges(canvas.Height);
            }
        }

        private void canvas_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            r = new Random();

            // Exercice liquid 
            liquid = new Liquid(0, canvas.Height / 2, 2 * canvas.Width / 3, canvas.Height / 2, 0.1, canvas);
            resetMovers();
            CompositionTarget.Rendering += UpdateCanvasLiquid;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            r = new Random();

            // Exercice liquid 
            liquid = new Liquid(0, canvas.Height / 2, 2 * canvas.Width / 3, canvas.Height / 2, 0.1, canvas);
            resetMovers();
            CompositionTarget.Rendering += UpdateCanvasLiquid;
        }

    }
}
