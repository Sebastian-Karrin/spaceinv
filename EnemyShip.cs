using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;

namespace spaceinv;

public class EnemyShip : Actor
{
    public EnemyShip() : base()
    {
        
    }
    
    public override void Create(Scene scene)
    {
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