using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public struct Intensity
    {
        public int r;
        public int g;
        public int b;
        public Intensity(int _r, int _g, int _b)
        {
            r = _r;
            g = _g;
            b = _b;
        }
    }
    public struct Reflection
    {
        public int r;
        public int g;
        public int b;
        public Reflection(int _r, int _g, int _b)
        {
            r = _r;
            g = _g;
            b = _b;
        }
    }
}
