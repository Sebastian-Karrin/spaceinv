using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class Background : Entity
{
    public Vector2f direction = new Vector2f(0, 1);
    private float scrollOffsetX = 0f;
    private float scrollOffsetY = 0f;
    private float scrollSpeedX = 50.0f;
    private float scrollSpeedY = 50.0f;
    private Texture backgroundTexture;
    
    public Background() : base("darkPurple", "kenvector_future_thin")
    {
        sprite.TextureRect = new IntRect((int)scrollOffsetX,(int)scrollOffsetY, 900,1800);
        sprite.Origin = new Vector2f(0, 900);
    }
    
    public override void Create(Scene scene)
    {
        direction = new Vector2f(0, 0.1f);
        base.Create(scene);
        sprite.Position = new Vector2f(0,0);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        Position += new Vector2f(0, 0.1f);
        scrollOffsetX += scrollSpeedX * deltaTime;
        scrollOffsetX %= 512;
        scrollOffsetY += scrollSpeedY * deltaTime;
        scrollOffsetY %= 512;
        Loop(scene);
        base.Update(scene, deltaTime);
        
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
        
    }

    public void Loop(Scene scene)
    {
        if (sprite.Position.Y >= 500)
        {
            sprite.Position = new Vector2f(0,0);
        }
    }
}