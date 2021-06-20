using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public class AmbientLight
    {
        public Intensity intensity;
        public AmbientLight(Intensity _intensity)
        {
            intensity = _intensity;
        }

    }
    public class PointLight
    {
        public Point4 position;
        public Intensity intensity;
        public PointLight(Point4 _position, Intensity _intensity)
        {
            position = _position;
            intensity = _intensity;
        }
    }
}
