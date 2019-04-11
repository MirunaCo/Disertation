using DisertationProject.CalculationHelper;
using DisertationProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DisertationProject.Controller
{
    public interface IMathematicsUtils
    {
        Point MinPoint(List<Body> bodies);
        Point MaxPoint(List<Body> bodies);
        //Vect2d ComputeAcceleration(Body body, Body otherBody);
    }
}
