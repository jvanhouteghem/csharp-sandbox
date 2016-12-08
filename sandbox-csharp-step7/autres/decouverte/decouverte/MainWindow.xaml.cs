using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace decouverte
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 

    class TempRecord
    {
        private float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F, 61.3F, 65.9F, 62.1F, 59.2F, 57.5F };

        public float this[int index]
        {
            get { return temps[index]; }
            set { temps[index] = value; }
        }
    }

public partial class MainWindow : Window
    {
        Point currentPoint;
        public MainWindow()
        {
            InitializeComponent();
            canvas.Focus();


            TempRecord tempRecord = new TempRecord();
            tempRecord[3] = 58.3F;
            tempRecord[5] = 60.1F;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Element #{0} = {1}", i, tempRecord[i]);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                currentPoint = e.GetPosition(canvas);
                textBox.Text = currentPoint.ToString();
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // si le bouton gauche de la souris est appuyé
            if (e.LeftButton == MouseButtonState.Pressed)
            {
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
                canvas.Children.Add(line);
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) { textBox.Text = "Return"; }
            if (e.Key == Key.Space) { textBox.Text = "Space"; }
        }
    }
}
