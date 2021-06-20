using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Camera
    {
        public Point4 cPos;
        public Point4 cTarget;
        public Point4 cUp;
        public Mat4 mat;
        public Mat4 matinv;
        public Camera(Point4 _cPos, Point4 _cTarget, Point4 _cUp)
        {
            cPos = _cPos;
            cTarget = _cTarget;
            cUp = _cUp;
            GetViewMatrix();
        }
        public void GetViewMatrix()
        {
            Point4 cZ = new Point4(cPos);
            cZ.Subtract(cTarget);
            cZ.Normalize();

            Point4 cX = new Point4(cUp.Cross(cZ));
            cX.Normalize();

            Point4 cY = new Point4(cZ.Cross(cX));
            cY.Normalize();

            mat = new Mat4(new double[,] {
                { cX.x, cX.y, cX.z, cX.Dot3(cPos) },
                { cY.x, cY.y, cY.z, cY.Dot3(cPos) },
                { cZ.x, cZ.y, cZ.z, -cZ.Dot3(cPos) },
                { 0, 0, 0, 1 }
            });


            // Compute the inverse
            Mat4 t = new Mat4(new double[,] {
                { 1, 0, 0, -mat.data[0, 3] },
                { 0, 1, 0, -mat.data[1, 3] },
                { 0, 0, 1, -mat.data[2, 3] },
                { 0, 0, 0, 1}
            });


            Mat4 o = new Mat4(new double[,] {
                { mat.data[0, 0], mat.data[0, 1], mat.data[0, 2], 0 },
                { mat.data[1, 0], mat.data[1, 1], mat.data[1, 2], 0 },
                { mat.data[2, 0], mat.data[2, 1], mat.data[2, 2], 0 },
                { 0, 0, 0, 1 }
            });

            o = o.Transpose();

            matinv = new Mat4();
            matinv = o.MultiplyMatrix(t);


        }
        public Point4 MultiplyInverseViewMatrix(Point4 point)
        {
            Point4 result = matinv.MultiplyPoint(point);
            return result;
        }

    }
}
