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
            data = new double[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    data[i, j] = 0.0;
                }
            }
        }
        public Point4 GetColumn(int j)
        {
            Point4 column = new Point4();
            column.x = data[0, j];
            column.y = data[1, j];
            column.z = data[2, j];
            column.w = data[3, j];
            return column;
        }
        public Point4 GetRow(int i)
        {
            Point4 row = new Point4();
            row.x = data[i, 0];
            row.y = data[i, 1];
            row.z = data[i, 2];
            row.w = data[i, 3];
            return row;
        }


        public Mat4 MultiplyMatrix(Mat4 mat)
        {
            Mat4 result = new Mat4();
            result.data[0, 0] = GetRow(0).Dot4(mat.GetColumn(0));
            result.data[0, 1] = GetRow(0).Dot4(mat.GetColumn(1));
            result.data[0, 2] = GetRow(0).Dot4(mat.GetColumn(2));
            result.data[0, 3] = GetRow(0).Dot4(mat.GetColumn(3));

            result.data[1, 0] = GetRow(1).Dot4(mat.GetColumn(0));
            result.data[1, 1] = GetRow(1).Dot4(mat.GetColumn(1));
            result.data[1, 2] = GetRow(1).Dot4(mat.GetColumn(2));
            result.data[1, 3] = GetRow(1).Dot4(mat.GetColumn(3));

            result.data[2, 0] = GetRow(2).Dot4(mat.GetColumn(0));
            result.data[2, 1] = GetRow(2).Dot4(mat.GetColumn(1));
            result.data[2, 2] = GetRow(2).Dot4(mat.GetColumn(2));
            result.data[2, 3] = GetRow(2).Dot4(mat.GetColumn(3));

            result.data[3, 0] = GetRow(3).Dot4(mat.GetColumn(0));
            result.data[3, 1] = GetRow(3).Dot4(mat.GetColumn(1));
            result.data[3, 2] = GetRow(3).Dot4(mat.GetColumn(2));
            result.data[3, 3] = GetRow(3).Dot4(mat.GetColumn(3));

            return result;
        }

        public Point4 MultiplyPoint(Point4 point)
        {
            Point4 result = new Point4();
            result.x = GetRow(0).Dot4(point);
            result.y = GetRow(1).Dot4(point);
            result.z = GetRow(2).Dot4(point);
            result.w = GetRow(3).Dot4(point);
            return result;
        }

        public Mat4 Negate()
        {
            Mat4 result = new Mat4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.data[i, j] = -data[i, j];
                }
            }
            return result;
        }

        public Mat4 Transpose()
        {
            Mat4 result = new Mat4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.data[i, j] = data[j, i];
                }
            }
            return result;
        }
    }
}
