using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract15_mamazhonova
{
    class Complex
    {
        public double r, i;
        public Complex Sum (Complex a, Complex b)
        {
            Complex res = new Complex( );
            res.r = a.r + b.r;
            res.i = a.i + b.i;
            return res;
        }

        public Complex Proizv (Complex a, Complex b)
        {
            Complex res = new Complex( );
            res.r = a.r * b.r;
            res.i = a.i * b.i;
            return res;
        }

        public Complex Razn (Complex a, Complex b)
        {
            Complex res = new Complex( );
            res.r = a.r - b.r;
            res.i = a.i - b.i;
            return res;
        }
    }
}
