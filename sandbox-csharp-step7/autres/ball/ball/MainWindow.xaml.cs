using System;
using System.Windows;
using System.Windows.Shapes;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Media;
namespace ball
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // exemple balls
        ArrayList balls;
        Ball b1;
        Ball b2;
        Ball b3;

        public MainWindow()
        {
            InitializeComponent();

            // Exercice balls    
            b1 = new Ball("ball1", 100, 100, 10, 1, 2);
            b2 = new Ball("ball2", 300, 300, 50, 2, 3);
            b3 = new Ball("ball3", 200, 200, 25, 2, 2);

            balls = new ArrayList();
            balls.Add(new Ball("ball1", 100, 100, 10, 1, 2));
            balls.Add(new Ball("ball2", 300, 300, 60, 2, 3));
            balls.Add(new Ball("ball3", 200, 200, 25, 2, 2));
            //balls.Add(new Ball("ball4", 300, 100, 25, 1, 3));
            //balls.Add(new Ball("ball5", 130, 100, 10, 1, 4));
            //balls.Add(new Ball("ball6", 150, 100, 10, 4, 4));


            CompositionTarget.Rendering += UpdateCanvasBalls;
        }

        private void UpdateCanvasBalls(object sender, EventArgs e)
        {
            // paintSurface.Children.Clear();

            //Ball b1 = new Ball("ball1", 100, 100, 10, 1, 2);
            //balls.Add(b1);

            // update movment
            foreach (Ball b in balls)
            {
                b.update();
                Ellipse el = (Ellipse)this.FindName(b.name);
                b.display(el);
                b.checkBoundaryCollision(canvas);
            }

            // update collision

            //(b1).checkCollision(b2);
            // (b1).checkCollision(b3);
            // (b2).checkCollision(b3);
            for (int i = 0; i < balls.Count; i++)
            {
                for (int j = i + 1; j < balls.Count; j++)
                {
                    (((Ball)balls[i])).checkCollision(((Ball)balls[j]));
                }

            }
        }
    }
}
