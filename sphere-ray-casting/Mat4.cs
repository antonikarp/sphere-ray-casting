using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Mat4
    {
        public double[,] data;
        public Mat4()
        {
            data = new double[4,4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    data[i, j] = 0.0;
                }
            }
        }
        public Mat4(double[,] arr)
        {
            data = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    data[i, j] = arr[i, j];
                }
            }
        }
        public Point4 GetColumn(int j)
        {
            Point4 column;
            column.x = data[0, j];
            column.y = data[1, j];
            column.z = data[2, j];
            column.w = data[3, j];
            return column;
        }
        public Point4 GetRow(int i)
        {
            Point4 row;
            row.x = data[i, 0];
            row.y = data[i, 1];
            row.z = data[i, 2];
            row.w = data[i, 3];
            return row;
        }
        public static double Dot(Point4 p1, Point4 p2)
        {
            return (p1.x * p2.x + p1.y * p2.y + p1.z * p2.z + p1.w * p2.w);
        }

        public Mat4 MultiplyMatrix(Mat4 mat)
        {
            Mat4 result = new Mat4();
            result.data[0, 0] = Dot(GetRow(0), mat.GetColumn(0));
            result.data[0, 1] = Dot(GetRow(0), mat.GetColumn(1));
            result.data[0, 2] = Dot(GetRow(0), mat.GetColumn(2));
            result.data[0, 3] = Dot(GetRow(0), mat.GetColumn(3));

            result.data[1, 0] = Dot(GetRow(1), mat.GetColumn(0));
            result.data[1, 1] = Dot(GetRow(1), mat.GetColumn(1));
            result.data[1, 2] = Dot(GetRow(1), mat.GetColumn(2));
            result.data[1, 3] = Dot(GetRow(1), mat.GetColumn(3));

            result.data[2, 0] = Dot(GetRow(2), mat.GetColumn(0));
            result.data[2, 1] = Dot(GetRow(2), mat.GetColumn(1));
            result.data[2, 2] = Dot(GetRow(2), mat.GetColumn(2));
            result.data[2, 3] = Dot(GetRow(2), mat.GetColumn(3));

            result.data[3, 0] = Dot(GetRow(3), mat.GetColumn(0));
            result.data[3, 1] = Dot(GetRow(3), mat.GetColumn(1));
            result.data[3, 2] = Dot(GetRow(3), mat.GetColumn(2));
            result.data[3, 3] = Dot(GetRow(3), mat.GetColumn(3));

            return result;
        }

        public Point4 MultiplyPoint(Point4 point)
        {
            Point4 result;
            result.x = Dot(GetRow(0), point);
            result.y = Dot(GetRow(1), point);
            result.z = Dot(GetRow(2), point);
            result.w = Dot(GetRow(3), point);
            return result;
        }
    }
}
