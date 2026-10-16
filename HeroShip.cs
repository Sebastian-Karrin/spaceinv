using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using static SFML.Window.Keyboard.Key;


namespace spaceinv;

public class HeroShip : Actor
{
    public HeroShip() : base()
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
    
    protected override int PickDirection(Scene scene) // Rör pacman så länge som den är free
    {
        int dir = direction;
        if (Keyboard.IsKeyPressed(Right))
        {
            dir = 0;
            isMoving = true;
        }
        else if (Keyboard.IsKeyPressed(Up))
        {
            dir = 1;
            isMoving = true;
        }
        else if (Keyboard.IsKeyPressed(Left))
        {
            dir = 2;
            isMoving = true;
        }
        else if (Keyboard.IsKeyPressed(Down))
        {
            dir = 3;
            isMoving = true;
        }
        return direction;
    }
}