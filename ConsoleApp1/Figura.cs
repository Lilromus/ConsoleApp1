using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Figura : ObliczObwod, ObliczPole
    {
        public abstract double ObliczPole();

        public abstract double ObliczObwod();
    }

}
