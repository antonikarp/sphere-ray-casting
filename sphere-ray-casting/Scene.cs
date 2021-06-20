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

        public void InitializeExampleScene(Point4 cPos, Point4 cTarget, Point4 cUp)
        {
            camera = new Camera(cPos, cTarget, cUp);

            spheres = new List<Sphere>();

            Material defaultMaterial;
            defaultMaterial.ambientReflection = new Reflection(100, 100, 100);
            defaultMaterial.diffuseReflection = new Reflection(100, 100, 100);
            defaultMaterial.specularReflection = new Reflection(100, 100, 100);

            Sphere sphere1;
            sphere1.center = new Point4(0, 0, 0, 1);
            sphere1.radius = 100;
            sphere1.material = defaultMaterial;

            Sphere sphere2;
            sphere2.center = new Point4(200, 0, 0, 1);
            sphere2.radius = 80;
            sphere2.material = defaultMaterial;

            Sphere sphere3;
            sphere3.center = new Point4(-400, 0, 0, 1);
            sphere3.radius = 70;
            sphere3.material = defaultMaterial;

            spheres.Add(sphere1);
            spheres.Add(sphere2);
            spheres.Add(sphere3);

            Intensity ambientIntensity = new Intensity(255, 255, 255);
            ambientLight = new AmbientLight(ambientIntensity);

            Point4 pointLightPosition = new Point4(0, 0, 500, 1);
            Intensity pointLightIntensity = new Intensity(255, 255, 255);
            pointLight = new PointLight(pointLightPosition, pointLightIntensity);

        }
    }
}
