using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertationProject.CalculationHelper
{
    /// This is the vector 2d
    public interface IVect2d
    {
        void Rescale(double newLenght);
        double Lenght { get; }
        double SquareLenght { get; }
        double X { get; set; }
        double Y { get; set; }
    }
}
