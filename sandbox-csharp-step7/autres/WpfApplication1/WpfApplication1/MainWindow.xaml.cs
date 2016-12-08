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

namespace WpfApplication1
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

            // Exercice yeux
            oeilGauche.Width = 30;
            oeilGauche.Height = 30;
            Canvas.SetTop(oeilGauche, 280);
            Canvas.SetLeft(oeilGauche, 250);

            oeilDroit.Width = 30;
            oeilDroit.Height = 30;
            Canvas.SetTop(oeilDroit, 280);
            Canvas.SetLeft(oeilDroit, 270);

            irisGauche.Width = 15;
            irisGauche.Height = 15;
            Canvas.SetTop(irisGauche, 100 + oeilGauche.Height / 4);
            Canvas.SetLeft(irisGauche, 190 + oeilGauche.Width / 4);

            irisDroit.Width = 15;
            irisDroit.Height = 15;
            Canvas.SetTop(irisDroit, 100 + oeilDroit.Height / 4);
            Canvas.SetLeft(irisDroit, 150 + oeilDroit.Width / 4);

            irisDroit.Visibility = Visibility.Hidden;
            irisGauche.Visibility = Visibility.Hidden;

            MouseMove += Canvas_MouseMove_3;
            MouseDown += Canvas_MouseDown_2;
        }


        private void Canvas_MouseMove_3(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point p = e.GetPosition(canvas);

            //if (e.LeftButton == MouseButtonState.Pressed) {
            irisDroit.Visibility = Visibility.Visible;
            irisGauche.Visibility = Visibility.Visible;
            double irisTaille = irisDroit.Width / 4;
            //if (e.LeftButton == MouseButtonState.Pressed) irisTaille = irisDroit.Width * 10;

            double dx = p.X - (Canvas.GetLeft(oeilDroit) + oeilDroit.Width / 2);
            double dy = p.Y - (Canvas.GetTop(oeilDroit) + oeilDroit.Height / 2);
            double angle = Math.Atan2(dy, dx);
            Canvas.SetLeft(irisDroit, Canvas.GetLeft(oeilDroit) + oeilDroit.Width / 2 - irisDroit.Width / 2 + irisTaille * Math.Cos(angle));
            Canvas.SetTop(irisDroit, Canvas.GetTop(oeilDroit) + oeilDroit.Height / 2 - irisDroit.Height / 2 + irisTaille * Math.Sin(angle));

            dx = p.X - (Canvas.GetLeft(oeilGauche) + oeilGauche.Width / 2);
            dy = p.Y - (Canvas.GetTop(oeilGauche) + oeilGauche.Height / 2);
            angle = Math.Atan2(dy, dx);
            Canvas.SetLeft(irisGauche, Canvas.GetLeft(oeilGauche) + oeilGauche.Width / 2 - irisGauche.Width / 2 + irisTaille * Math.Cos(angle));
            Canvas.SetTop(irisGauche, Canvas.GetTop(oeilGauche) + oeilGauche.Height / 2 - irisGauche.Height / 2 + irisTaille * Math.Sin(angle));
            //} else {
            //    irisDroit.Visibility = Visibility.Hidden;
            //    irisGauche.Visibility = Visibility.Hidden;
            //}
        }

        private void Canvas_MouseDown_2(object sender, System.Windows.Input.MouseEventArgs e)
        {
            irisDroit.Visibility = Visibility.Visible;
            irisGauche.Visibility = Visibility.Visible;

        }
    }
}
