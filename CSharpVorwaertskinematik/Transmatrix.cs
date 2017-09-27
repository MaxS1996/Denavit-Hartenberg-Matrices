using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVorwaertskinematik
{
    class Transmatrix
    {
        protected double[] a;
        protected double[] b;
        protected double[] c;
        protected double[] d;



        public Transmatrix(Joint joint)
        {
            a = new double[4];
            b = new double[4];
            c = new double[4];
            d = new double[4];
            Generate(joint);
        }

        public Transmatrix(double a0, double a1, double a2, double a3, double b0, double b1, double b2, double b3, double c0, double c1, double c2, double c3, double d0, double d1, double d2, double d3)
        {
            a = new double[4];
            b = new double[4];
            c = new double[4];
            d = new double[4];

            a[0] = a0;
            a[1] = a1;
            a[2] = a2;
            a[3] = a3;

            b[0] = b0;
            b[1] = b1;
            b[2] = b2;
            b[3] = b3;

            c[0] = c0;
            c[1] = c1;
            c[2] = c2;
            c[3] = c3;

            d[0] = d0;
            d[1] = d1;
            d[2] = d2;
            d[3] = d3;
        }

        protected void Generate(Joint joint)
        {
            double CosTheta = Math.Cos(joint.Theta()*Math.PI/180);
            double SinTheta = Math.Sin(joint.Theta() * Math.PI / 180);

            double CosAlpha = Math.Cos(joint.Alpha() * Math.PI / 180);
            double SinAlpha = Math.Sin(joint.Alpha() * Math.PI / 180);

            a[0] = CosTheta;
            a[1] = SinTheta;
            a[2] = 0;
            a[3] = 0;

            b[0] = SinTheta * (-1) * CosAlpha;
            b[1] = CosTheta * CosAlpha;
            b[2] = SinAlpha;
            b[3] = 0;

            c[0] = SinTheta * SinAlpha;
            c[1] = (-1) * CosTheta * SinAlpha;
            c[2] = CosAlpha;
            c[3] = 0;

            d[0] = joint.A() * CosTheta;
            d[1] = joint.A() * SinTheta;
            d[2] = joint.D();
            d[3] = 1;
        }


        public static Transmatrix Multiply(Transmatrix One, Transmatrix Two)
        {
            double[] a = One.A();
            double[] b = One.B();
            double[] c = One.C();
            double[] d = One.D();

            double[] w = Two.A();
            double[] x = Two.B();
            double[] y = Two.C();
            double[] z = Two.D();

            //First Column
            double[] r = new double[4];
            for(int i=0; i<4; i++)
            {
                r[i] = a[i] * w[0] + b[i] * w[1] + c[i] * w[2] + d[i] * w[3];
            }

            //Second Cloumn
            double[] s = new double[4];
            for (int i = 0; i < 4; i++)
            {
                s[i] = a[i] * x[0] + b[i] * x[1] + c[i] * x[2] + d[i] * x[3];
            }

            //Third Column
            double[] t = new double[4];
            for (int i = 0; i < 4; i++)
            {
                t[i] = a[i] * y[0] + b[i] * y[1] + c[i] * y[2] + d[i] * y[3];
            }

            //Fourth Column
            double[] u = new double[4];
            for (int i = 0; i < 4; i++)
            {
                u[i] = a[i] * z[0] + b[i] * z[1] + c[i] * z[2] + d[i] * z[3];
            }

            return new Transmatrix(r[0], r[1], r[2], r[3], s[0], s[1], s[2], s[3], t[0], t[1], t[2], t[3], u[0], u[1], u[2], u[3]);
        }


        //Getter
        public double[] A()
        {
            return a;
        }

        public double[] B()
        {
            return b;
        }

        public double[] C()
        {
            return c;
        }

        public double[] D()
        {
            return d;
        }

        public override String ToString()
        {
            String text = "";

            for(int i=0; i<4; i++)
            {
                text = text + "\n" + a[i] + " " + b[i] + " " + c[i] + " " + d[i];
            }
            return text;
        }
    }
}
