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
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            using (var window = new RenderWindow(new VideoMode(900,900), "spaceinv"))
            {
                window.Closed += (o, e) => window.Close();
                Clock clock = new Clock();
                Scene scene = new Scene();
                window.SetView(new View(
                    new Vector2f(400,400),
                    new Vector2f(800,800)
                ));
                scene.Loader.LoadScene(scene);
                while (window.IsOpen)
                {
                    window.DispatchEvents();
                    float deltatime = clock.Restart().AsSeconds();
                    deltatime = MathF.Min(deltatime, 0.01f);
                    scene.UpdateAll(deltatime);
                    window.Clear(new Color(10,10,50));
                    scene.RenderAll(window);
                    window.Display();
                }
            }
        }
    }
}