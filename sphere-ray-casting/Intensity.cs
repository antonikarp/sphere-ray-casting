using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Intensity
    {
        public double r;
        public double g;
        public double b;
        public Intensity()
        {
        }
        public Intensity(double _r, double _g, double _b)
        {
            r = _r;
            g = _g;
            b = _b;
        }
        public void Clamp()
        {
            r = Math.Max(0, r);
            r = Math.Min(255, r);
            g = Math.Max(0, g);
            g = Math.Min(255, g);
            b = Math.Max(0, b);
            b = Math.Min(255, b);

        }
    }
    public struct Reflection
    {
        public double r;
        public double g;
        public double b;
        public Reflection(double _r, double _g, double _b)
        {
            r = _r;
            g = _g;
            b = _b;
        }
    }
}
