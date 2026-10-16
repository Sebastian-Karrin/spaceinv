using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class Background : Entity
{
    public Vector2f direction = new Vector2f(0, 1);
    
    public Background() : base("darkPurple")
    {
        sprite.Position = new Vector2f(0,0);
    }
    
    public override void Create(Scene scene)
    {
        base.Create(scene);
        sprite.Position = new Vector2f(0,0);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        Loop(scene);
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }

    public void Loop(Scene scene)
    {
        if (sprite.Position.Y >= 900)
        {
            sprite.Position = new Vector2f(0,0);
        }
    }
}