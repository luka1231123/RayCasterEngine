using SFML;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using static RaycasterEngine.ExtraMethods;

namespace RaycasterEngine;
public class Program
{
    
    static public vec3 rayColor(Ray ray,vec3 camerPos)
    {
        camerPos = new vec3(camerPos.x, camerPos.y, camerPos.z-1);
        if (hitSphere(new vec3(0, 0, -1), 0.5, ray))
        {
            return new vec3(1, 0, 0);
        }


        vec3 unitDirection = unitVector(ray.direction());
        var t = 0.5 * (unitDirection.y + 1.0);
        return (1.0 - t) * new vec3(1.0, 1.0, 1.0) + t * new vec3(0.5, 0.7, 1.0);


    }
    static public bool hitSphere(vec3 center, double radius,  Ray r) 
    {
        vec3 oc = r.origin()-(center);
        var a = Dot(r.direction(), r.direction());
        var b = 2.0 * Dot(oc, r.direction());
        var c = Dot(oc, oc) - (radius * radius);
        var discriminant = b * b - 4 * a * c;
        return (discriminant > 0);
    }

    static void Main()
    {
        Window wnd = new Window();
        Camera cam = new Camera();

        while (wnd.windOpen())
        {
            wnd.Refresh();

            cam.cameraEvents();

            for (int j = (int)wnd.yHeight - 1; j >= 0; --j)
            {
                for (int i = 0; i < (int)wnd.xWidth; ++i)
                {
                    var u = (double)i / (wnd.xWidth - 1);
                    var v = (double)j / (wnd.yHeight - 1);
                    Ray ray = new Ray(cam.Position, cam.lowerLeftCorner+cam.horizontal*u+cam.horizontal*v-cam.Position);
                    vec3 color = rayColor(ray,cam.Position);

                    
                    
                    wnd.SetPixel((uint)i, (uint)j, color);
                }
                

                Console.WriteLine($"{Math.Round(cam.Position.x, 0)} {Math.Round(cam.Position.y,0)} {Math.Round(cam.Position.z, 0)} {Math.Round(cam.momentumX,0)} {Math.Round(cam.momentumY, 0)} {Math.Round(cam.momentumZ,0)}");

            }

            wnd.Draw();

        }
        
    }

}
