using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class EnemyShip : Actor
{
    public readonly Bullet bullet;
    private float bulletTimer;

    public EnemyShip() : base()
    {
        sprite.TextureRect = new IntRect(144, 156, 104, 84);
        sprite.Origin = new Vector2f(52,42);
        bullet = new Bullet();
    }
    
    public override void Create(Scene scene)
    {
        sprite.Position = new Vector2f(new Random().Next(10,890), 0);
        speed = 100.0f;
        base.Create(scene);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        bulletTimer = MathF.Max(bulletTimer - deltaTime, 0.0f);

        base.Update(scene, deltaTime);
        Position += ToVectorX(directionX) * (speed * deltaTime) + ToVectorY(directionY) * ((speed / 5) * deltaTime);
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && bulletTimer < 0.5)
        {
            bulletTimer = 1.0f;
            bullet.EnemyBullet(scene,this);
        }
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }

    protected override int PickDirectionX(Scene scene)
    {
        int dirX = directionX;
        if (dirX == 0)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 10) >= 6) dirX = -1;
            else dirX = 1;
        }
        if (dirX == 1 && sprite.Position.X >= 848)
        {
            dirX = -1;
            isMoving = true;
        }

        if (dirX == -1 && sprite.Position.X <= 52)
        {
            dirX = 1;
            isMoving = true;
        }
        return dirX;
    }
    protected override int PickDirectionY(Scene scene)
    {
        int dirY = directionY;
        if (!isDead)
        {
            dirY = 1;
            isMoving = true;
        }
        return dirY;
    }

    protected virtual void CollideWith(Scene scene, Entity e)
    {
        if (e is HeroShip)
        {
            sprite.Position = new Vector2f(100, 100);
        }
    }

}