using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace plouf
{
    class Mover
    {
        public Vector velocity;
        public Vector acceleration;
        public double mass;
        public Vector location;
        Ellipse e;

        public Mover(double m, double x, double y, Canvas canvas)
        {
            mass = m;
            location = new Vector(x, y);
            velocity = new Vector(0, 0);
            acceleration = new Vector(0, 0);

            e = new Ellipse();
            Color color = Color.FromArgb(255, 0, 0, 0);
            SolidColorBrush b = new SolidColorBrush();
            b.Color = color;
            e.Fill = b;
            e.StrokeThickness = 2;
            e.Stroke = Brushes.Black;

            e.Width = m * 10;
            e.Height = m * 10;

            double centreBallX = location.X - e.Width / 2;
            double centreBallY = location.Y - e.Width / 2;
            Canvas.SetLeft(e, centreBallX);
            Canvas.SetTop(e, centreBallY);

            canvas.Children.Add(e);
        }

        // Newton's 2nd law: F = M * A
        // or A = F / M
        public void applyForce(Vector force)
        {
            // Divide by mass 
            Vector f = force / mass;

            // Accumulate all forces in acceleration
            acceleration += f;
        }

        public void update()
        {
            // Velocity changes according to acceleration
            velocity += acceleration;

            // Location changes by velocity
            location += velocity;

            // We must clear acceleration each frame
            acceleration *= 0;
        }

        // Draw Mover
        public void display()
        {
            double centreBallX = location.X - e.Width / 2;
            double centreBallY = location.Y - e.Width / 2;

            Canvas.SetLeft(e, centreBallX);
            Canvas.SetTop(e, centreBallY);
            e.Width = mass * 16;
            e.Height = mass * 16;
        }

        // Bounce off bottom of window
        public void checkEdges(double HeightEdge)
        {
            if (location.Y > HeightEdge)
            {
                velocity.Y *= -0.9;  // A little dampening when hitting the bottom
                location.Y = HeightEdge;
            }
        }
    }

}
