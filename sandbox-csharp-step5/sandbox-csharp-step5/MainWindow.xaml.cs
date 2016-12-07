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
        private Point position;

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
                Console.WriteLine("line");
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
