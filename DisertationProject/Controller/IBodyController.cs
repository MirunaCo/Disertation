using DisertationProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisertationProject.Controller
{
    public interface IBodyController
    {
        void LoadFromXML(string strXML);
        void SaveState(string strPath);
        void Update(double deltaT);
        string Path { get; }
        void SetPath(string strNewPath);
        void AddBody(Body body);
        List<Body> Bodies();
        void CalculateRadius();
        bool LessThan(Body bodyOne, Body bodyTwo);
        bool Collision();
        
    }
}
