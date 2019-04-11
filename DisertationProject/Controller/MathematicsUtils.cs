using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DisertationProject.CalculationHelper;
using DisertationProject.Model;

namespace DisertationProject.Controller
{
    public class MathematicsUtils : IMathematicsUtils
    {
        public static Vect2d ComputeAcceleration(Body body, Body otherBody)
        {
            Vect2d vector = new Vect2d(body.Position, otherBody.Position);
            const double G = 6.673e-11;
            double squareDistance = vector.SquareLenght;
            double acceleration = (G * otherBody.Mass) / squareDistance;

            vector.Rescale(acceleration);
            return vector;
        }

        public Point MaxPoint(List<Body> bodies)
        {
            if (bodies.Count > 0)
            {
                Point maxPoint = new Point(0, 0);
                maxPoint = bodies.ElementAt(0).Position;
                foreach(Body body in bodies)
                {
                    if (maxPoint.X <= body.Position.X)
                        maxPoint.X = body.Position.X;
                    if (maxPoint.Y <= body.Position.Y)
                        maxPoint.Y = body.Position.Y;
                }
                return maxPoint;
            }
            return new Point(0, 0);
        }

        public Point MinPoint(List<Body> bodies)
        {
            if(bodies.Count > 0)
            {
                Point minPoint = new Point(0, 0);
                minPoint = bodies.ElementAt(0).Position;
                foreach(Body body in bodies) {
                    if(minPoint.X >= body.Position.X)
                    {
                        minPoint.X = body.Position.X;
                    }
                    if(minPoint.Y >= body.Position.Y)
                    {
                        minPoint.Y = body.Position.Y;
                    }
                }
                return minPoint;
            }
            return new Point(0, 0);
        }
    }
}
