using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Transform
    {
        public static Point4 RotateY(Point4 point, double alpha)
        {
            Point4 newPoint;
            newPoint.x = point.x * Math.Cos(alpha) + point.z * Math.Sin(alpha);
            newPoint.y = point.y;
            newPoint.z = -point.x * Math.Sin(alpha) + point.z * Math.Cos(alpha);
            newPoint.w = point.w;
            return newPoint;
        }

    }
}
