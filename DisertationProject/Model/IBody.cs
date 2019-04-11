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
    public interface IBody
    {
        /// The mass of the body
        double Mass { get; set; }

        /// The radius of the body
        double Radius { get; set; }

        /// The velocity of the body
        Vect2d Velocity { get; set; }

        /// The position of the body
        Point Position { get; set; }

        /// The color of the body
        ConsoleColor Color { get; set; }
    }
}
