using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace RaycasterEngine;

public class Window
{
    ExtraMethods exm = new ExtraMethods();
    public uint xWidth { get; set; } = 1280;
    public uint yHeight { get; set; } 
    public string Title { get; set; } = "Ray";


    public Image image { get; set; }
    public Texture texture { get; set; }
    public Sprite sprite { get; set; }
    public RenderWindow win { get; set; }
    public Window() {
        yHeight = (uint)(xWidth / exm.aspectRatio);
        image = new Image(xWidth, yHeight);
        texture = new Texture(image);
        sprite = new Sprite(texture);
        win = new RenderWindow(new SFML.Window.VideoMode(xWidth, yHeight), Title);
        win.Closed += (sender, e) => win.Close();
        

    }
    public void SetPixel(uint x, uint y,vec3 color)
    {
        double cx = color.x * 255.999;
        double cy = color.y * 255.999;
        double cz = color.z * 255.999;
        Color clr = new Color((byte)(cx), (byte)(cy), (byte)(cz));
        image.SetPixel(x,y,clr);
    }
    public void Refresh()
    {
        win.DispatchEvents();
        win.Clear();
        image= new Image(xWidth, yHeight);

        
    }
    public void Draw()
    {
        texture = new Texture(image);
        sprite = new Sprite(texture);
        win.Draw(sprite);
        win.Display();
    }
    public bool windOpen()
    {
        bool bl = true;
        bl = win.IsOpen;
        return bl;
    }

}
