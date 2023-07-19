using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaycasterEngine;

internal class ExtraMethods
{
    public double aspectRatio = 16.0 / 9.0;

    public static bool ikp(Keyboard.Key key)
    {
        bool boolx = false;
        if (Keyboard.IsKeyPressed(key))
        {
            boolx = true;
        }
        return boolx;
    }
    public static vec3 unitVector(vec3 v)
    {
        /*if (v.Length() != 0.0)
        {
            double invLength = 1.0 / v.Length();
            return (new vec3(v.x * invLength, v.y * invLength, v.z * invLength));
        }
        else
        {
            return new vec3();
        }*/
        return v / v.Length();
    }
    public static double Dot(vec3 u,vec3 v) 
    {
        return u.e[0] * v.e[0]
             + u.e[1] * v.e[1]
             + u.e[2] * v.e[2];
    }
    public static vec3 cross( vec3 u,  vec3 v) {
        return new vec3(u.e[1] * v.e[2] - u.e[2] * v.e[1],
                        u.e[2] * v.e[0] - u.e[0] * v.e[2],
                        u.e[0] * v.e[1] - u.e[1] * v.e[0]);
    }

}
class Matrix3
{
    private float[] _data;

    public Matrix3(float[] data)
    {
        _data = data;
    }

    public static Vector3f operator *(Matrix3 m, Vector3f v)
    {
        return new Vector3f(
            m._data[0] * v.X + m._data[1] * v.Y + m._data[2] * v.Z,
            m._data[3] * v.X + m._data[4] * v.Y + m._data[5] * v.Z,
            m._data[6] * v.X + m._data[7] * v.Y + m._data[8] * v.Z
        );
    }
}
