using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Point4
    {
        public double x;
        public double y;
        public double z;
        public double w;

        public Point4()
        {

        }
        public Point4(double _x, double _y, double _z, double _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        public Point4(Point4 p)
        {
            x = p.x;
            y = p.y;
            z = p.z;
            w = p.w;
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        public double Dot3(Point4 point)
        {
            return (x * point.x + y * point.y + z * point.z);
        }
        public double Dot4(Point4 point)
        {
            return (x * point.x + y * point.y + z * point.z + w * point.w);
        }

        public Point4 Cross(Point4 point)
        {
            Point4 result = new Point4();
            result.x = y * point.z - z * point.y;
            result.y = z * point.x - x * point.z;
            result.z = x * point.y - y * point.x;
            result.w = 1;
            return result;
        }
        public void Multiply(double c)
        {
            x = x * c;
            y = y * c;
            z = z * c;
        }
        public void Subtract(Point4 point)
        {
            x = x - point.x;
            y = y - point.y;
            z = z - point.z;
        }
        public void Normalize()
        {
            double length = Length();
            if (length != 0.0)
            {
                x = x / length;
                y = y / length;
                z = z / length;
            }

        }
    }
}
