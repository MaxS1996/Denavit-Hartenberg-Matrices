using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVorwaertskinematik
{
    class Manipulator
    {
        protected List<Joint> Joints;
        public List<Joint> getJoints() {
            return Joints;
        }

        protected Transmatrix wholeMatrix;

        public Manipulator()
        {
            Joints = new List<Joint>();
            wholeMatrix = calcWholeMatrix();
        }

        protected void AddJoint(Joint newJoint)
        {
            Joints.Add(newJoint);
            wholeMatrix = calcWholeMatrix();
        }

        public bool IsCorrect()
        {
            bool correct = true;
            foreach (Joint joint in Joints) {
                correct = correct && joint.IsCorrect();
            }
            return correct;
        }

        public Joint CreateJoint(double theta, double d, double a, double alpha)
        {
            Joint newJoint = new Joint(theta, d, a, alpha, Joints.Count);
            AddJoint(newJoint);
            

            return newJoint;
        }

        public Transmatrix calcWholeMatrix()
        {
            Transmatrix newMatrix = new Transmatrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            foreach (Joint joint in Joints)
            {
                newMatrix = Transmatrix.Multiply(newMatrix, joint.TransMatrix());
            }

            return newMatrix;
        }

        public void readJoints()
        {
            Console.WriteLine("Creating new Manipulator ");
            Console.WriteLine("======================== ");
            bool more = true;

            double theta;
            double d;
            double a;
            double alpha;

            while (more)
            {
                theta = 0;
                d = 0;
                a = 0;
                alpha = 0;

                Console.WriteLine("Creating new Joint ");

                Console.WriteLine("Theta: ");
                theta = readValue();

                Console.WriteLine("d: ");
                d = readValue();

                Console.WriteLine("a: ");
                a = readValue();

                Console.WriteLine("alpha: ");
                alpha = readValue();

                CreateJoint(theta, d, a, alpha);
                Console.WriteLine("-------------------- ");
                Console.WriteLine("add more?");
                more = readBool();
            }
        }




        double readValue()
        {
            double value;
            Console.WriteLine("please enter value : ");
            if (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Not correct! Please enter a double\n");
                value = readValue();
            }
            return value;
        }

        bool readBool()
        {
            bool value;
            if (!bool.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Not correct! Please enter a boolean\n");
                value = readBool();
            }
            return value;
        }

        public override string ToString()
        {
            String text = "# of Joints: "+ Joints.Count;
            foreach(Joint joint in Joints)
            {
                text = text + "\n\n" + joint.ToString();
            }

            text = text + "\n\nBase to End:" + wholeMatrix.ToString();
            return text;
        }

    }
}
