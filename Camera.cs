using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using static RaycasterEngine.ExtraMethods;

namespace RaycasterEngine;

internal class Camera
{
    ExtraMethods exm = new ExtraMethods();
    public vec3 Position = new vec3();
    public vec3 horizontal;
    public vec3 vertical;
    public vec3 lowerLeftCorner = new vec3();
    public double viewportHeight = 2.0;
    public double viewportWidth;
    public double focalLength = 1.0;

    public double rotationX;
    public double rotationY;

    public double momentumX;
    public double momentumY;
    public double momentumZ;

    public Camera() {
        momentumX=0;
        momentumY=0;
        momentumZ=0;
        viewportWidth = viewportHeight * exm.aspectRatio;
        horizontal = new vec3(viewportWidth,0,0);
        vertical = new vec3(0, viewportHeight, 0);
        lowerLeftCorner = new vec3(Position.x-viewportHeight/2, Position.y-viewportWidth/2, Position.z-focalLength);
    }

    public void cameraEvents()
    {
        if(ikp(SFML.Window.Keyboard.Key.W))
        {
            momentumZ += 0.5;
        }
        if(ikp(SFML.Window.Keyboard.Key.S))
        {
            momentumZ -= 0.5;
        }
        if(ikp(SFML.Window.Keyboard.Key.A))
        {
            momentumX += 0.5;
        }
        if(ikp(SFML.Window.Keyboard.Key.D))
        {
            momentumX -= 0.5;
        }
        if (ikp(Keyboard.Key.E))
        {
            momentumY += 0.5;
        }
        if (ikp(Keyboard.Key.Q))
        {
            momentumY -= 0.5;
        }
        if(momentumX > 0) { momentumX -= 0.25; }
        if (momentumY > 0) { momentumY -= 0.25; }
        if (momentumZ > 0) { momentumZ -= 0.25; }
        if (momentumX < 0) { momentumX += 0.25; }
        if (momentumY < 0) { momentumY += 0.25; }
        if (momentumZ < 0) { momentumZ += 0.25; }
        Position.x+=momentumX;
        Position.y+=momentumY;
        Position.z+=momentumZ;
    }
}
