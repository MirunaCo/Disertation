using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DisertationProject.CalculationHelper
{
    public class Vect2d : IVect2d
    {
        #region Members 

        private double m_x = 0.0;
        private double m_y = 0.0;

        #endregion

        #region Constructors 

        public Vect2d() { }

        public Vect2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vect2d( Point pointOne, Point pointTWo)
        {
            X = pointTWo.X - pointOne.X;
            Y = pointTWo.Y - pointOne.Y;
        }
        #endregion

        #region Properties
        public double Lenght
        {
            get { return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2)); }
           
        }
        public double SquareLenght
        {
            get { return Math.Pow(X, 2) + Math.Pow(Y, 2); }
        }
        public double X
        {
            get { return m_x; }
            set
            {
                m_x = value;
            }
        }
        public double Y
        {
            get { return m_y; }
            set
            {
                m_y = value;
            }
        }

        #endregion

        public void Rescale(double newLenght)
        {
            double lenght = Lenght;
            X /= lenght;
            X *= newLenght;

            Y /= lenght;
            Y *= newLenght;
        }

        public Vect2d Multiply(double var)
        {
            Vect2d newVect = new Vect2d
            {
                X = X * var,
                Y = Y * var
            };
            return newVect;
        }

        public static Vect2d operator *(Vect2d vectOne2D, Vect2d vectTwo2D) => new Vect2d(vectOne2D.X * vectTwo2D.X, vectOne2D.Y * vectTwo2D.Y);

        public static Vect2d operator *(Vect2d vectOne2D, double dValue) => new Vect2d(vectOne2D.X * dValue, vectOne2D.Y * dValue);

        public static Vect2d operator +(Vect2d vectOne2D, Vect2d vectTwo2D) => new Vect2d(vectOne2D.X + vectTwo2D.X, vectOne2D.Y + vectTwo2D.Y);

        //public static Vect2d operator +=(Vect2d vectOne2D, Vect2d vectTwo2D) => new Vect2d(vectOne2D.X + vectTwo2D.X, vectOne2D.Y + vectTwo2D.Y);
    }
}
