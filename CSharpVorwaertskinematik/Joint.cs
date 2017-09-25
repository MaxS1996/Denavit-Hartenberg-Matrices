using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVorwaertskinematik
{
    class Joint
    {

        protected double theta;
        protected double d;
        protected double a;
        protected double alpha;
        protected int pos;
        bool correct;
        protected Transmatrix trans;

        public Joint(double theta, double d, double a, double alpha, int pos)
        {
            this.theta = theta;
            this.d = d;
            this.a = a;
            this.alpha = alpha;
            this.pos = pos;
            this.correct = (d > 0) && (a > 0);
            this.trans = new Transmatrix(this);
        }

        //Real functions







        //Getter

        public override string ToString()
        {
            String row1 = "theta = " + theta;
            String row2 = "d = " + d;
            String row3 = "a = " + a;
            String row4 = "alpha = " + alpha;

            String row = row1 + " " + row2 + " " + row3 + " " + row4;
            return row + trans.ToString();
        }

        public double Theta()
        {
            return theta;
        }

        public double D()
        {
            return d;
        }

        public double A()
        {
            return a;
        }

        public double Alpha()
        {
            return alpha;
        }

        public bool IsCorrect()
        {
            return correct;
        }

        public Transmatrix TransMatrix()
        {
            return trans;
        }
    }
}
