using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Rotate
    {
        public double alpha;
        public double beta;
        public double gamma;
        public Rotate(int _alpha_deg, int _beta_deg, int _gamma_deg)
        {
            alpha = _alpha_deg * Math.PI / 180;
            beta = _beta_deg * Math.PI / 180;
            gamma = _gamma_deg * Math.PI / 180;
        }
        public Point4 DoRotate(Point4 point)
        {
            Mat4 rotateX = new Mat4();
            rotateX.data[0, 0] = 1;
            rotateX.data[1, 1] = Math.Cos(alpha);
            rotateX.data[1, 2] = -Math.Sin(alpha);
            rotateX.data[2, 1] = Math.Sin(alpha);
            rotateX.data[2, 2] = Math.Cos(alpha);
            rotateX.data[3, 3] = 1;

            Mat4 rotateY = new Mat4();
            rotateY.data[0, 0] = Math.Cos(beta);
            rotateY.data[0, 2] = Math.Sin(beta);
            rotateY.data[1, 1] = 1;
            rotateY.data[2, 0] = -Math.Sin(beta);
            rotateY.data[2, 2] = Math.Cos(beta);
            rotateY.data[3, 3] = 1;

            Mat4 rotateZ = new Mat4();
            rotateZ.data[0, 0] = Math.Cos(gamma);
            rotateZ.data[0, 1] = -Math.Sin(gamma);
            rotateZ.data[1, 0] = Math.Sin(gamma);
            rotateZ.data[1, 1] = Math.Cos(gamma);
            rotateZ.data[2, 2] = 1;
            rotateZ.data[3, 3] = 1;

            Point4 result;
            result = rotateZ.MultiplyPoint(rotateY.MultiplyPoint(rotateX.MultiplyPoint(point)));
            return result;
        }
    }
}
