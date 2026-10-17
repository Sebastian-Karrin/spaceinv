using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class EnemyShip : Actor
{
    public EnemyShip() : base()
    {
        sprite.TextureRect = new IntRect(144, 156, 104, 84);
    }
    
    public override void Create(Scene scene)
    {
        sprite.Position = new Vector2f(450, 450);
        speed = 100.0f;
        base.Create(scene);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        Position += ToVector(direction) * (speed * deltaTime);
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }
}