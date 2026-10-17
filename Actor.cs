using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace spaceinv;

public class Actor : Entity
{
    protected float speed;
    protected int directionX;
    protected int directionY;
    public bool shooting;
    public bool isMoving;
    protected Vector2f originalPosition;
    protected Vector2f Velocity;
    protected static Vector2f ToVectorX(int dirX)
    {
        if(dirX == 1) return new Vector2f(1, 0); //Höger
        if (dirX == -1) return new Vector2f(-1, 0); //Vänster
        return new Vector2f(0, 0); //Stilla, om nåt går fel.
    }
    protected static Vector2f ToVectorY(int dirY)
    {
        if (dirY == 1) return new Vector2f(0, 1); //Ner
        if (dirY ==-1) return new Vector2f(0, -1); // Upp
        return new Vector2f(0, 0);
    }
    protected virtual int PickDirectionX(Scene scene) { return 0;}
    protected virtual int PickDirectionY(Scene scene) { return 0;}
    
    public Actor() : base("sheet", "kenvector_future_thin")
    {
        RenderOrder = 50;
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
    }

    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        directionX = PickDirectionX(scene);
        directionY = PickDirectionY(scene);
        Position += ToVectorX(directionX) * (speed * deltaTime) + ToVectorY(directionY) * (speed * deltaTime);
        /*Position = MathF.Floor(Position.X) switch // om du åker till höger av bannan i tunneln sätts nya positionen till vänster och vice versa
        {
            < 0 => new Vector2f(432, Position.Y),
            > 432 => new Vector2f(0, Position.Y),
            _ => Position
        };*/
    }

    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }
}