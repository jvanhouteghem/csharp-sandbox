using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace sandbox_csharp_step5 {
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Point currentPoint;
        //private object paintSurface;

        //fail
        //int panelWidth = this.Size.Width;
        //int panelHeight = this.Size.Height;
        int canvasTpHeight = 321;
        int canvasTpWidth = 518;

        public MainWindow() {
            InitializeComponent();
            CanvasTP.Focus();

        }

        // Clic event
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e) {

            // test sur le bouton de la souris est appuyé
            if (e.ButtonState == MouseButtonState.Pressed) {
                // récupère la position de la souris
                currentPoint = e.GetPosition(this);
                Trace.WriteLine("clic");
                TextBoxName.Text = currentPoint.ToString();
            }
        }

        // Draw
        private void Canvas_MouseMove(object sender, MouseEventArgs e) {

            // si le bouton gauche de la souris est appuyé
            if (e.LeftButton == MouseButtonState.Pressed) {
                // créer une nouvelle ligne
                Line line = new Line();
                // définir le style de la ligne
                line.Stroke = SystemColors.WindowFrameBrush;
                // positionner le début de la ligne sur le dernier point courant enregistré
                // (attribué dans la méthode du gestionnaire de MouseDown)
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                // positionner la fin de la ligne sur le point courant
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                currentPoint = e.GetPosition(this);
                // affiche sur l'élément paintSurface (canvas) la ligne
                CanvasTP.Children.Add(line);
                Console.WriteLine("left clic");
            }

            // si le bouton gauche de la souris est appuyé
            // Oeil gauche
            if (e.RightButton == MouseButtonState.Pressed) {
                // créer une nouvelle ligne
                Line line = new Line();
                // définir le style de la ligne
                line.Stroke = SystemColors.WindowFrameBrush;
                line.Width = 0;
                // positionner le début de la ligne sur le dernier point courant enregistré
                // (attribué dans la méthode du gestionnaire de MouseDown)
                line.X1 = canvasTpWidth/2;
                line.Y1 = canvasTpHeight/2;
                // positionner la fin de la ligne sur le point courant
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                currentPoint = e.GetPosition(this);
                // affiche sur l'élément paintSurface (canvas) la ligne
                CanvasTP.Children.Add(line);
                Console.WriteLine("right clic");

                // Calcul de la position de l'iris

                double dx = line.X2 - line.X1;
                double dy = line.Y2 - line.Y1;

                double angle = Math.Atan2(dy, dx);

                //double angle = Math.Atan2();
                double positionIrisLeftX = line.X1 -15 + (10 * Math.Cos(angle));
                double positionIrisLeftY = line.Y1 -15 + (10 * Math.Sin(angle));


                // Déplacer l'iris
                Canvas.SetLeft(IrisLeft, positionIrisLeftX);
                Canvas.SetTop(IrisLeft, positionIrisLeftY);

                // Oeil droit
                // Déplacer l'iris

                double positionIrisRightX = positionIrisLeftX +60;
                double positionIrisRightY = positionIrisLeftY;

                Canvas.SetLeft(IrisRight, positionIrisRightX);
                Canvas.SetTop(IrisRight, positionIrisRightY);
            }

        }

        // Keydown
        private void CanvasTP_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Return) { TextBoxName.Text = "Return"; }
            if (e.Key == Key.Space) { TextBoxName.Text = "Space"; }
        }

        private void exit_Click(Object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
