using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaycasterEngine;

public class Ray
{
    public vec3 orig = new vec3();
    public vec3 dir = new vec3();
    public Ray(vec3 origin, vec3 direction)
    {
        orig = origin;
        dir = direction;
    }
    public vec3 origin() { return orig; }
    public vec3 direction() { return dir; }

    public vec3 at(double t)
    {
        return orig+dir*t;
    }

}
