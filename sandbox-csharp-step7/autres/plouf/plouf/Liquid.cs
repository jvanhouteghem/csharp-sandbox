using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace plouf
{
    class Liquid
    {

        // Liquid is a rectangle
        double x, y, w, h;

        // Coefficient of drag
        double c;
        Rectangle r;

        public Liquid(double x_, double y_, double w_, double h_, double c_, Canvas canvas)
        {
            x = x_;
            y = y_;
            w = w_;
            h = h_;
            c = c_;

            r = new Rectangle();
            Color color = Color.FromArgb(0, 0, 255, 0);
            SolidColorBrush b = new SolidColorBrush();
            b.Color = color;
            r.Fill = b;
            r.StrokeThickness = 2;
            r.Stroke = Brushes.Blue;

            r.Width = w;
            r.Height = h;
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);

            canvas.Children.Add(r);
        }

        // Is the Mover in the Liquid?
        public bool contains(Mover m)
        {
            Vector l = m.location;
            if (l.X > x && l.X < x + w && l.Y > y && l.Y < y + h)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Calculate drag force
        public Vector drag(Mover m)
        {
            // Magnitude is coefficient * speed squared
            double speed = Math.Sqrt(m.velocity.X * m.velocity.X + m.velocity.Y * m.velocity.Y);
            double dragMagnitude = c * speed * speed;

            // Direction is inverse of velocity
            Vector drag = new Vector(m.velocity.X, m.velocity.Y);
            drag *= -1;

            // Scale according to magnitude
            drag.Normalize();
            drag *= dragMagnitude;

            return drag;
        }

        public void display()
        {
            r.Width = w;
            r.Height = h;

            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
        }
    }
}

