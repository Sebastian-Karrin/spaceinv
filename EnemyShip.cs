using System.Diagnostics;
using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class EnemyShip : Actor
{
    private readonly Bullet Bullet;
    private readonly Explosion Explosions;
    private float bulletTimer;
    private float expoTimer;
    public EnemyShip() : base()
    {
        sprite.TextureRect = new IntRect(144, 156, 104, 84);
        sprite.Origin = new Vector2f(52,42);
        Explosions = new Explosion();
        Bullet = new Bullet("enemyBullet");
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
        expoTimer = MathF.Max(expoTimer - deltaTime, 0.0f);
        
        
        if (!isDead)
        {
            Position += ToVectorX(directionX) * (speed * deltaTime) + ToVectorY(directionY) * ((speed / 5) * deltaTime);
            if (bulletTimer < 0.3)
            {
                bulletTimer = 1.0f;
                Random random = new Random();
                if (random.Next(0, 100) < 60)
                {
                    Bullet.EnemyBullet(scene,this, "enemyBullet");
                }
            }
            Position = MathF.Floor(Position.Y) switch
            {
                > 942 => new Vector2f(Position.X, -42),
                _ => Position
            }; 
        }
        else
        {
            Explosions.Explode(scene, this);

            /*if (expoTimer > 0.0f)
            {
                scene.Spawn(Explosion);
                Explosion.Location(scene, this);
            }*/
        }
        base.Update(scene, deltaTime);

    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }

    public override void Destroy(Scene scene)
    {
        base.Destroy(scene);
    }

    protected override int PickDirectionX(Scene scene)
    {
        int dirX = directionX;
        if (dirX == 0)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 10) >= 6)
            {
                dirX = -1;
                sprite.Rotation = 45.0f;
            }
            else
            {
                dirX = 1;
                sprite.Rotation = 45.0f;
            }
        }
        if (dirX == 1 && sprite.Position.X >= 848)
        {
            dirX = -1;
            sprite.Rotation = 45.0f;
            isMoving = true;
        }

        if (dirX == -1 && sprite.Position.X <= 52)
        {
            dirX = 1;
            sprite.Rotation = -45.0f;
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
            expoTimer = 1.0f;
            Explosions.Explode(scene , this);
            scene.PublishLostHealth(1);
        }
    }
}