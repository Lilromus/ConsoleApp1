using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Prostokat : Figura
    {
        private double a, b;

        public Prostokat(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override double ObliczPole()
        {
            return a * b;
        }

        public override double ObliczObwod()
        {
            return 2 * (a + b);
        }
    }
}
