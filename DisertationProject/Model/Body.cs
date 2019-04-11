using DisertationProject.CalculationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DisertationProject.Model
{
    /// This interface represents the body of planet and it's properties
    public class Body : IBody
    {       
        #region Members
        private double m_mass = 0.0;
        private double m_radius = 0.0;
        private Vect2d m_velocity = new Vect2d(0, 0);
        private Point m_position = new Point(0, 0);
        private ConsoleColor m_color = ConsoleColor.Black;
        #endregion

        #region Constructors
        /// Default constructor
        public Body() { }

        ///Constructor
        public Body(Body body)
        {
            Mass = body.Mass;
            Radius = body.Radius;
            Velocity.X = body.Velocity.X;
            Velocity.Y = body.Velocity.Y;
            Position = new Point (body.Position.X, body.Position.Y) ;
            Color = body.Color;
        }

        /// Copy Constructor
        public Body(double mass, double radius, Vect2d velocity, Point position, ConsoleColor color)
        {
            Mass = mass;
            Radius = radius;
            Velocity = velocity;
            Position = position;
            Color = color;
        }

        #endregion

        #region Properties
        /// This is the mass of a body
        public double Mass
        {
            get { return m_mass; }
            set
            {
                m_mass = value;                
                //Raise property changed
            }
        }

        /// This is the radius of a body
        public double Radius
        {
            get { return m_radius; }
            set
            {
               m_radius = value;
            }
        }

        /// This is the velocity of the body -> needs to be a 2d vector
        public Vect2d Velocity
        {
            get { return m_velocity; }
            set
            {
                m_velocity = value;
            }
        }

        /// This is the position of the body-> need to be a point with x,y,z
        public Point Position
        {
            get { return m_position; }
            set
            {
                m_position = value;
            }
        }

        /// This is the color of a body
        public ConsoleColor Color
        {
            get { return m_color; }
            set
            {
                m_color = value;
            }
        }

        #endregion
    }
}
