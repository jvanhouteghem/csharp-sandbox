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

namespace regard
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            canvas.Focus();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            double x0c = canvas.Width / 2; // Canvas.GetTop(canvas);
            double y0c = canvas.Height / 2; // Canvas.GetLeft(canvas);

            Point p = e.GetPosition(canvas);

            Line line = new Line();
            line.Stroke = SystemColors.WindowFrameBrush;
            line.X1 = x0c;
            line.Y1 = y0c;
            line.X2 = p.X;
            line.Y2 = p.Y;
            canvas.Children.Add(line);

            double dx = p.X - x0c;
            double dy = p.Y - y0c;

            double rayon = 75;
            double angle2 = Math.Atan2(dy, dx);

            double x = x0c + rayon * Math.Cos(angle2);
            double y = y0c + rayon * Math.Sin(angle2);

            Canvas.SetLeft(ellipse, x);
            Canvas.SetTop(ellipse, y);

            Console.WriteLine(x + " " + y);
        }
    }
}
