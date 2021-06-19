using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public struct Sphere
    {
        public Point4 center;
        public int radius;
    }
    public class SphereSet
    {
        public List<Sphere> spheres;
        public SphereSet()
        {
            spheres = new List<Sphere>();

            Sphere sphere1;
            sphere1.center = new Point4(0, 0, 0, 1);
            sphere1.radius = 100;

            Sphere sphere2;
            sphere2.center = new Point4(200, 0, 0, 1);
            sphere2.radius = 80;

            Sphere sphere4;
            sphere4.center = new Point4(-400, 0, 0, 1);
            sphere4.radius = 70;

            spheres.Add(sphere1);
            spheres.Add(sphere2);
            spheres.Add(sphere4);

        }

    }
}
