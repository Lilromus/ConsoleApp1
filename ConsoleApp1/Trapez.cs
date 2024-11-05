using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Trapez : Figura
    {
        private double a, b, c, d, h;

        public Trapez(double a, double b, double c, double d, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.h = h;
        }

        public override double ObliczPole() 
        {
            return ((a + b) * h) / 2;
        }

        public override double ObliczObwod()
        {
            return a + b + c + d;
        }
    }
}
