using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class Scene
    {
        public Camera camera;
        public List<Sphere> spheres;
        public AmbientLight ambientLight;
        public PointLight pointLight;
        public Intensity backgroundIntensity;

        public void InitializeExampleScene(Point4 cPos, Point4 cTarget, Point4 cUp, Point4 lightPos)
        {
            camera = new Camera(cPos, cTarget, cUp);

            spheres = new List<Sphere>();

            Material material1;
            material1.ambientReflection = new Reflection(0.1, 0.1, 0.1);
            material1.diffuseReflection = new Reflection(0.5, 0.4, 0.5);
            material1.specularReflection = new Reflection(1, 0.7, 1);
            material1.specularFocus = 20;

            Sphere sphere1;
            sphere1.center = new Point4(0, 0, 0, 1);
            sphere1.radius = 100;
            sphere1.material = material1;

            Material material2;
            material2.ambientReflection = new Reflection(0.1, 0.1, 0.1);
            material2.diffuseReflection = new Reflection(0.4, 0.5, 0.5);
            material2.specularReflection = new Reflection(1, 0.8, 0.8);
            material2.specularFocus = 10;

            Sphere sphere2;
            sphere2.center = new Point4(200, 0, 0, 1);
            sphere2.radius = 80;
            sphere2.material = material2;

            Material material3;
            material3.ambientReflection = new Reflection(0.1, 0.1, 0.1);
            material3.diffuseReflection = new Reflection(0.5, 0.5, 0.4);
            material3.specularReflection = new Reflection(0.8, 1, 0.8);
            material3.specularFocus = 10;

            Sphere sphere3;
            sphere3.center = new Point4(-400, 0, 0, 1);
            sphere3.radius = 70;
            sphere3.material = material3;

            Material material4;
            material4.ambientReflection = new Reflection(0.0, 0.0, 0.2);
            material4.diffuseReflection = new Reflection(0.4, 0.4, 0.7);
            material4.specularReflection = new Reflection(0.8, 0.9, 0.8);
            material4.specularFocus = 10;

            Sphere sphere4;
            sphere4.center = new Point4(100, 100, 0, 1);
            sphere4.radius = 50;
            sphere4.material = material4;

            spheres.Add(sphere1);
            spheres.Add(sphere2);
            spheres.Add(sphere3);
            spheres.Add(sphere4);

            Intensity ambientIntensity = new Intensity(255, 255, 255);
            ambientLight = new AmbientLight(ambientIntensity);

            Point4 pointLightPosition = new Point4(lightPos);
            Intensity pointLightIntensity = new Intensity(255, 255, 255);
            pointLight = new PointLight(pointLightPosition, pointLightIntensity);

            backgroundIntensity = new Intensity(0, 0, 0);

        }
    }
}
