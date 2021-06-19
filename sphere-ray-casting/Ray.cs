using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Ray
    {
        public Point4 origin;
        public Point4 direction;
        public Point4 pixel;
        public int width;
        public int height;
        public Ray(Point4 _pixel, int _width, int _height)
        {
            pixel = _pixel;
            width = _width;
            height = _height;
        
        }
        public void Initialize(Camera camera)
        {
            int center_x = width / 2;
            int center_y = height / 2;
            int d = (width / 2); //right now theta = 90 deg
            Point4 p = new Point4();
            p.x = 0;
            p.y = 0;
            p.z = 0;
            p.w = 1;

            Point4 q = new Point4();
            q.x = pixel.x - center_x;
            q.y = pixel.y - center_y;
            q.z = -d;
            q.w = 1;
            q.Subtract(p);
            q.Normalize();

            origin = new Point4();
            origin = camera.MultiplyInverseViewMatrix(p);

            q.w = 0;
            direction = new Point4();
            direction = camera.MultiplyInverseViewMatrix(q);
        }
        public bool Cast(SphereSet sphereSet)
        {
            foreach (Sphere s in sphereSet.spheres)
            {
                Point4 diff = new Point4();
                diff = origin;
                diff.Subtract(s.center);
                double A = 1;
                double B = 2 * direction.Dot3(diff);
                double C = diff.Dot3(diff) - s.radius * s.radius;
                double delta = B * B - 4 * A * C;
                if (delta >= 0)
                {
                    double t1 = (-B - Math.Sqrt(delta)) / (2 * A);
                    double t2 = (-B + Math.Sqrt(delta)) / (2 * A);
                    if (t1 > 0 && t2 > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
            
            
        }
    }
}
