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
            Mat4 rotateX = new Mat4(new double[,] {
                { 1, 0, 0, 0 },
                { 0, Math.Cos(alpha), -Math.Sin(alpha), 0 },
                { 0, Math.Sin(alpha), Math.Cos(alpha), 0 },
                { 0, 0, 0, 1 }
            });

            Mat4 rotateY = new Mat4(new double[,] {
                { Math.Cos(beta), 0, Math.Sin(beta), 0 },
                { 0, 1, 0, 0 },
                { -Math.Sin(beta), 0, Math.Cos(beta), 0 },
                { 0, 0, 0, 1 }
            });

            Mat4 rotateZ = new Mat4(new double[,] {
                { Math.Cos(gamma), -Math.Sin(gamma), 0, 0 },
                { Math.Sin(gamma), Math.Cos(gamma), 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            });

            Point4 result;
            result = rotateZ.MultiplyPoint(rotateY.MultiplyPoint(rotateX.MultiplyPoint(point)));
            return result;
        }
    }
}
