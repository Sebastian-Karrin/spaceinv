using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace spaceinv;

public class Actor : Entity
{
    protected float speed;
    protected int direction;
    public bool shooting;
    public bool isMoving;
    protected Vector2f originalPosition;
    protected static Vector2f ToVector(int dir)
    {
        if (dir==0) return new Vector2f(1, 0); //Höger
        if (dir==1) return new Vector2f(0, -1); //Upp
        if (dir==2) return new Vector2f(-1, 0); //Vänster
        if (dir == 3) return new Vector2f(0,1); //Ner
        return new Vector2f(0, 0); //Stilla, om nåt går fel.
    }
    protected virtual int PickDirection(Scene scene) { return 0;}
    
    public Actor() : base("sheet")
    {
        Position = new Vector2f();
    }

    public override void Create(Scene scene)
    {
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