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

            mat = new Mat4();
            mat.data[0, 0] = cX.x;
            mat.data[0, 1] = cX.y;
            mat.data[0, 2] = cX.z;
            mat.data[0, 3] = cX.Dot3(cPos);

            mat.data[1, 0] = cY.x;
            mat.data[1, 1] = cY.y;
            mat.data[1, 2] = cY.z;
            mat.data[1, 3] = cY.Dot3(cPos);

            mat.data[2, 0] = cZ.x;
            mat.data[2, 1] = cZ.y;
            mat.data[2, 2] = cZ.z;
            mat.data[2, 3] = -cZ.Dot3(cPos);

            mat.data[3, 0] = 0;
            mat.data[3, 1] = 0;
            mat.data[3, 2] = 0;
            mat.data[3, 3] = 1;

            // Compute the inverse
            Mat4 t = new Mat4();
            
            t.data[0, 3] = mat.data[0, 3];
            t.data[1, 3] = mat.data[1, 3];
            t.data[2, 3] = mat.data[2, 3];
            t = t.Negate();
            t.data[0, 0] = 1;
            t.data[1, 1] = 1;
            t.data[2, 2] = 1;
            t.data[3, 3] = 1;
            

            Mat4 o = new Mat4();
            o.data[0, 0] = mat.data[0, 0];
            o.data[0, 1] = mat.data[0, 1];
            o.data[0, 2] = mat.data[0, 2];
            o.data[1, 0] = mat.data[1, 0];
            o.data[1, 1] = mat.data[1, 1];
            o.data[1, 2] = mat.data[1, 2];
            o.data[2, 0] = mat.data[2, 0];
            o.data[2, 1] = mat.data[2, 1];
            o.data[2, 2] = mat.data[2, 2];
            o.data[3, 3] = 1;
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
