using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;



namespace spaceinv;

public class HeroShip : Actor
{
    public readonly Bullet bullet;
    private float bulletTimer;
    public HeroShip() : base()
    {
        sprite.TextureRect = new IntRect(112, 792, 112, 76);
        sprite.Origin = new Vector2f(56, 38);
        bullet = new Bullet();
    }
    
    public override void Create(Scene scene)
    {
        sprite.Position = new Vector2f(450, 450);
        speed = 300.0f;
        base.Create(scene);    
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        bulletTimer = MathF.Max(bulletTimer - deltaTime, 0.0f);
        base.Update(scene, deltaTime);
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && bulletTimer < 0.5)
        {
            bulletTimer = 1.0f;
            bullet.HeroBullet(scene,this);
        }

    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
        
    }
    
    protected override int PickDirectionX(Scene scene) // Rör pacman så länge som den är free
    {
        int dirX = directionX;
        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        {
            dirX = 1;
            isMoving = true;
        }
       
        else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
        {
            dirX = -1;
            isMoving = true;
        }
        else if (!Keyboard.IsKeyPressed(Keyboard.Key.D) || !Keyboard.IsKeyPressed(Keyboard.Key.A))
        {
            dirX = 0;
            isMoving = false;
        }
        
        return dirX;
    }
    protected override int PickDirectionY(Scene scene) // Rör pacman så länge som den är free
    {
        int dirY = directionY;
        if (Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            dirY = -1;
            isMoving = true;
        }
       
        else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            dirY = 1;
            isMoving = true;
        }
        else if (!Keyboard.IsKeyPressed(Keyboard.Key.S) || !Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            dirY = 0;
            isMoving = false;
        }
        return dirY;
    }

    protected virtual void CollideWith(Scene scene, Entity e)
    {
        
    }

}