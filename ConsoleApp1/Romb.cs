using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Romb : Figura
    {
        private double a, h;

        public Romb(double a, double h)
        {
            this.a = a;
            this.h = h;
        }

        public override double ObliczObwod()
        {
            return 4 * a;
        }

        public override double ObliczPole()
        {
            return a * h;
        }
    }
}
