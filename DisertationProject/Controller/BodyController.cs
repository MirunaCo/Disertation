using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisertationProject.CalculationHelper;
using DisertationProject.Model;

namespace DisertationProject.Controller
{
    public class BodyController : IBodyController
    {
        private List<Body> m_lstBodies = new List<Body>();
        string m_strPath = null;

        public void AddBody(Body body)
        {
            m_lstBodies.Add(body);
            // TODO: sort m_lstbodies
            m_lstBodies.Sort(m_lstBodies.First(), LessThan);
            //SortedList(m_lstBodies.First(), LessThan);
        }

        public List<Body> Bodies()
        {
            return m_lstBodies;
        }

        public void CalculateRadius()
        {
            throw new NotImplementedException();
        }

        public bool Collision()
        {
            bool bIsCollision = false;
            double tolerance = 0.001;
            int numBodies = m_lstBodies.Count;
            for(int index=0; index < numBodies; index++)
            {
                for(int otherIndex = 0; otherIndex < numBodies; otherIndex++)
                {
                    if (index != otherIndex)
                    {
                        Vect2d vector = new Vect2d(m_lstBodies.ElementAt(index).Position, m_lstBodies.ElementAt(otherIndex).Position);
                        if (vector.SquareLenght < tolerance)
                        {
                            if (m_lstBodies.ElementAt(index).Mass >= m_lstBodies.ElementAt(otherIndex).Mass)
                            {
                                double procentOne = m_lstBodies.ElementAt(index).Mass / (m_lstBodies.ElementAt(index).Mass + m_lstBodies.ElementAt(otherIndex).Mass);
                                double procentTwo = m_lstBodies.ElementAt(otherIndex).Mass / (m_lstBodies.ElementAt(index).Mass + m_lstBodies.ElementAt(otherIndex).Mass);

                                m_lstBodies.ElementAt(index).Velocity = m_lstBodies.ElementAt(index).Velocity * procentOne + m_lstBodies.ElementAt(otherIndex).Velocity * procentTwo;
                                m_lstBodies.ElementAt(index).Mass = m_lstBodies.ElementAt(index).Mass + m_lstBodies.ElementAt(otherIndex).Mass;

                                m_lstBodies.Remove(m_lstBodies.ElementAt(otherIndex));
                                bIsCollision = true;
                                otherIndex++;
                                numBodies--;
                                if(numBodies == index)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return bIsCollision;
        }

        public string Path
        {
            get { return m_strPath; }
        }

        public bool LessThan(Body bodyOne, Body bodyTwo)
        {
            return bodyOne.Mass < bodyTwo.Mass;
        }

        public void LoadFromXML(string strXML)
        {
            throw new NotImplementedException();
        }

        public void SaveState(string strPath)
        {
            throw new NotImplementedException();
        }

        public void SetPath(string strNewPath)
        {
            m_strPath = strNewPath;
        }

        public void Update(double deltaT)
        {
            if (Collision())
                CalculateRadius();
            List<Body> newBodies = new List<Body>();
            newBodies.AddRange(m_lstBodies);
            
            foreach (Body body in m_lstBodies)
            {
                Vect2d acceleration = new Vect2d(0,0);
            foreach (Body otherBody in m_lstBodies)
            {
                if (body != otherBody)
                {
                    acceleration += MathematicsUtils.ComputeAcceleration(body, otherBody);
                }
            }
            //Step 1: update position
            Body newBody = new Body(body);
                //todo: find a solution
            //newBody.Position += body.Velocity * deltaT + acceleration * deltaT * deltaT * 0.5;

            //Step 2: compute acceleration
            Vect2d accelerationNext = new Vect2d(0,0);

            foreach (Body otherBody in m_lstBodies)
            {
                if (body != otherBody)
                {
                    accelerationNext += MathematicsUtils.ComputeAcceleration(newBody, otherBody);
                }
            }
            //Step 3: update Velocity

            newBody.Velocity += (acceleration + accelerationNext) * deltaT * 0.5;
            newBodies.Add(newBody);
        }
            //TODO: make swap method
           // m_lstBodies.swap(newBodies);
        }
    }
}
