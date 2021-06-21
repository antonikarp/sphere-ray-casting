using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace sphere_ray_casting
{
    public class Ray
    {
        public Point4 origin;
        public Point4 direction;
        public Point4 pixel;
        public int width;
        public int height;
        public Scene scene;
        public Ray(Point4 _pixel, int _width, int _height, Scene _scene)
        {
            pixel = _pixel;
            width = _width;
            height = _height;
            scene = _scene;

            int center_x = width / 2;
            int center_y = height / 2;
            int d = (width / 2); //right now theta = 90 deg
            Point4 p = new Point4(0, 0, 0, 1);

            Point4 q = new Point4(pixel.x - center_x, -pixel.y + center_y, -d, 1);
            q.Subtract(p);
            q.Normalize();

            origin = new Point4();
            origin = scene.camera.MultiplyInverseViewMatrix(p);

            q.w = 0;
            direction = new Point4();
            direction = scene.camera.MultiplyInverseViewMatrix(q);

        }
        public Intensity Cast()
        {
            List<Tuple<Sphere, double>> hitList = new List<Tuple<Sphere, double>>();  
            foreach (Sphere sphere in scene.spheres)
            {
                Point4 diff = new Point4();
                diff = origin;
                diff.Subtract(sphere.center);
                double A = 1;
                double B = 2 * direction.Dot3(diff);
                double C = diff.Dot3(diff) - sphere.radius * sphere.radius;
                double delta = B * B - 4 * A * C;
                
                if (delta >= 0)
                {
                    double t1 = (-B - Math.Sqrt(delta)) / (2 * A);
                    double t2 = (-B + Math.Sqrt(delta)) / (2 * A);
                    double t = Math.Min(t1, t2);
                    if (t > 0)
                    {
                        hitList.Add(Tuple.Create(sphere, t));
                        
                    }
                }
            }

            hitList.Sort((tuple1, tuple2) => (tuple1.Item2.CompareTo(tuple2.Item2)));
            if (hitList.Count == 0)
            {
                return scene.backgroundIntensity;
            }
            else
            {
                Intensity resultIntensity;
                double t = hitList[0].Item2;
                Point4 p_t = new Point4(direction);
                p_t.Multiply(t);
                p_t.Add(origin);
                resultIntensity = calculateIntensity(scene, hitList[0].Item1, p_t);
                return resultIntensity;
            }
        }

        public Intensity calculateIntensity(Scene scene, Sphere sphere, Point4 p_t)
        {
            Intensity resultIntensity = new Intensity();

            Point4 normal = new Point4(p_t);
            normal.Subtract(sphere.center);
            normal.Normalize();

            Point4 lightVec = new Point4(scene.pointLight.position);
            lightVec.Subtract(p_t);
            lightVec.Normalize();

            double dotDiffuse = Math.Max(normal.Dot3(lightVec), 0);

            Point4 viewVec = new Point4(scene.camera.cPos);
            viewVec.Subtract(p_t);
            viewVec.Normalize();

            Point4 reflectionVec = new Point4(normal);
            reflectionVec.Multiply(2 * normal.Dot3(lightVec));
            reflectionVec.Subtract(lightVec);

            double dotSpecular = Math.Max(viewVec.Dot3(reflectionVec), 0);
            double dotSpecularPower = Math.Pow(dotSpecular, sphere.material.specularFocus);

            resultIntensity.r = scene.ambientLight.intensity.r * sphere.material.ambientReflection.r;
            resultIntensity.g = scene.ambientLight.intensity.g * sphere.material.ambientReflection.g;
            resultIntensity.b = scene.ambientLight.intensity.b * sphere.material.ambientReflection.b;

            resultIntensity.r += scene.pointLight.intensity.r * sphere.material.diffuseReflection.r * dotDiffuse;
            resultIntensity.g += scene.pointLight.intensity.g * sphere.material.diffuseReflection.g * dotDiffuse;
            resultIntensity.b += scene.pointLight.intensity.b * sphere.material.diffuseReflection.b * dotDiffuse;

            resultIntensity.r += scene.pointLight.intensity.r * sphere.material.specularReflection.r * dotSpecularPower;
            resultIntensity.g += scene.pointLight.intensity.g * sphere.material.specularReflection.g * dotSpecularPower;
            resultIntensity.b += scene.pointLight.intensity.b * sphere.material.specularReflection.b * dotSpecularPower;

            resultIntensity.Clamp();

            return resultIntensity;
        }
    }
}
