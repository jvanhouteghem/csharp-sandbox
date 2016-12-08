using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ball
{
    class Ball
    {
        private Vector position;
        private Vector velocity;
        private double r;
        private double m;
        public String name { get; set; }

        public Ball(String name_, double x, double y, double r_, double vx, double vy)
        {
            position = new Vector(x, y);
            velocity = new Vector(vx, vy);
            r = r_;
            m = r * .1;
            name = name_;

        }

        public void update()
        {
            position.X += velocity.X;
            position.Y += velocity.Y;
        }

        public void checkBoundaryCollision(Canvas canvas)
        {

            if (position.X > canvas.Width - r)
            {
                position.X = canvas.Width - r;
                velocity.X *= -1;
            }
            else if (position.X < r)
            {
                position.X = r;
                velocity.X *= -1;
            }
            else if (position.Y > canvas.Height - r)
            {
                position.Y = canvas.Height - r;
                velocity.Y *= -1;
            }
            else if (position.Y < r)
            {
                position.Y = r;
                velocity.Y *= -1;
            }
        }

        public void checkCollision(Ball other)
        {

            // get distances between the balls components
            Vector bVect = other.position - position;

            // calculate magnitude of the vector separating the balls
            double bVectMag = Math.Sqrt(bVect.X * bVect.X + bVect.Y * bVect.Y);

            // if collision
            if (bVectMag < r + other.r)
            {
                // get angle of bVect
                double theta = Math.Atan(bVect.Y / bVect.X);

                // precalculate trig values
                double sine = Math.Sin(theta);
                double cosine = Math.Cos(theta);

                // bTemp will hold rotated ball positions. 
                // You just need to worry about bTemp[1] position
                Vector[] bTemp = { new Vector(), new Vector() };

                // this ball's position is relative to the other
                // so you can use the vector between them (bVect) as the 
                // reference point in the rotation expressions.
                // bTemp[0].position.x and bTemp[0].position.y will initialize
                // automatically to 0.0, which is what you want
                // since b[1] will rotate around b[0]
                bTemp[1].X = cosine * bVect.X + sine * bVect.Y;
                bTemp[1].Y = cosine * bVect.Y - sine * bVect.X;

                // rotate Temporary velocities
                Vector[] vTemp = { new Vector(), new Vector() };

                vTemp[0].X = cosine * velocity.X + sine * velocity.Y;
                vTemp[0].Y = cosine * velocity.Y - sine * velocity.X;
                vTemp[1].X = cosine * other.velocity.X + sine * other.velocity.Y;
                vTemp[1].Y = cosine * other.velocity.Y - sine * other.velocity.X;

                // Now that velocities are rotated, you can use 1D
                // conservation of momentum equations to calculate 
                // the final velocity along the x-axis.
                Vector[] vFinal = { new Vector(), new Vector() };

                // final rotated velocity for b[0]
                vFinal[0].X = ((m - other.m) * vTemp[0].X + 2 * other.m * vTemp[1].X) / (m + other.m);
                vFinal[0].Y = vTemp[0].Y;

                // final rotated velocity for b[0]
                vFinal[1].X = ((other.m - m) * vTemp[1].X + 2 * m * vTemp[0].X) / (m + other.m);
                vFinal[1].Y = vTemp[1].Y;

                // hack to avoid clumping
                bTemp[0].X += vFinal[0].X;
                bTemp[1].X += vFinal[1].X;

                /* Rotate ball positions and velocities back
                 Reverse signs in trig expressions to rotate 
                 in the opposite direction */
                // rotate balls
                Vector[] bFinal = { new Vector(), new Vector() };

                bFinal[0].X = cosine * bTemp[0].X - sine * bTemp[0].Y;
                bFinal[0].Y = cosine * bTemp[0].Y + sine * bTemp[0].X;
                bFinal[1].X = cosine * bTemp[1].X - sine * bTemp[1].Y;
                bFinal[1].Y = cosine * bTemp[1].Y + sine * bTemp[1].X;

                // update balls to screen position
                other.position.X = position.X + bFinal[1].X;
                other.position.Y = position.Y + bFinal[1].Y;

                position += bFinal[0];

                // update velocities
                velocity.X = cosine * vFinal[0].X - sine * vFinal[0].Y;
                velocity.Y = cosine * vFinal[0].Y + sine * vFinal[0].X;
                other.velocity.X = cosine * vFinal[1].X - sine * vFinal[1].Y;
                other.velocity.Y = cosine * vFinal[1].Y + sine * vFinal[1].X;
            }
        }

        public void display(Ellipse e)
        {
            double centreBallX = position.X - e.Width / 2;
            double centreBallY = position.Y - e.Width / 2;

            Canvas.SetLeft(e, centreBallX);
            Canvas.SetTop(e, centreBallY);
            e.Width = r * 2;
            e.Height = r * 2;
        }
    }
}