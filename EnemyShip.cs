using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class EnemyShip : Actor
{
    public readonly Bullet bullet;
    private float bulletTimer;
    private Vector2f originalPosition;

    public EnemyShip() : base()
    {
        sprite.TextureRect = new IntRect(144, 156, 104, 84);
        sprite.Origin = new Vector2f(52,42);
        bullet = new Bullet();
        originalPosition = new Vector2f(new Random().Next(10,890), -50);
    }
    
    public override void Create(Scene scene)
    {
        sprite.Position = originalPosition;
        speed = 100.0f;
        base.Create(scene);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        bulletTimer = MathF.Max(bulletTimer - deltaTime, 0.0f);

        base.Update(scene, deltaTime);
        if (!isDead)
        {
            Position += ToVectorX(directionX) * (speed * deltaTime) + ToVectorY(directionY) * ((speed / 5) * deltaTime);
            if (bulletTimer < 0.3)
            {
                bulletTimer = 1.0f;
                bullet.EnemyBullet(scene,this);
            }
        }
        else
        {
            sprite.Position = originalPosition;
            isDead = false;
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

    protected override void CollideWith(Scene scene, Entity e)
    {
        if (e is HeroShip)
        {
            isDead = true;
            Destroy(scene);
            return;
        }

        if (e is Bullet)
        {
            if (bullet.IsFromHero)
            {
                isDead = true;
                Destroy(scene);
                return;
            }
        }
        /*if (e is Bullet)
        {
            isDead = true;
            Destroy(scene);
        }*/
    }

}