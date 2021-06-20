using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sphere_ray_casting
{
    public struct Material
    {
        public Reflection ambientReflection;
        public Reflection diffuseReflection;
        public Reflection specularReflection;
    }
}
