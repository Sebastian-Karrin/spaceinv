using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace spaceinv
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(900,900), "spaceinv"))
            {
                window.Closed += (o, e) => window.Close();
                Clock clock = new Clock();
                while (window.IsOpen)
                {
                    window.DispatchEvents();
                }
            }
        }
    }
}