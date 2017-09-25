using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVorwaertskinematik
{
    class Program
    {
        static void Main(string[] args)
        {

            Manipulator Manipu = new Manipulator();
            Manipu.readJoints();




            Console.WriteLine(Manipu.ToString());
            Console.ReadLine();
        }

    }
}
