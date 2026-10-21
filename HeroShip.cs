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
        originalPosition = new Vector2f(450, 450);
        speed = 300.0f;

    }
    
    public override void Create(Scene scene)
    {
        sprite.Position = originalPosition;
        base.Create(scene);
        scene.LoseHealth += OnLoseHealth;
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        if (!scene.gameOver)
        {
            bulletTimer = MathF.Max(bulletTimer - deltaTime, 0.0f);
        
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && bulletTimer < 0.25)
            {
                bulletTimer = 0.5f;
                bullet.HeroBullet(scene,this);
                bullet.isFromEnemy = false;
                bullet.IsFromHero = true;
            }
            
            base.Update(scene, deltaTime);
        }
        
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }
    
    public override void Destroy(Scene scene)
    {
        base.Destroy(scene);
        scene.LoseHealth -= OnLoseHealth;
    }
    
    protected override int PickDirectionX(Scene scene)
    {
        int dirX = directionX;
        if (Keyboard.IsKeyPressed(Keyboard.Key.D) && sprite.Position.X < 844)
        {
            dirX = 1;
            isMoving = true;
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.A)  && sprite.Position.X > 56)
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
    protected override int PickDirectionY(Scene scene)
    {
        int dirY = directionY;
        if (Keyboard.IsKeyPressed(Keyboard.Key.W) && sprite.Position.Y > 38)
        {
            dirY = -1;
            isMoving = true;
        }
        else if (Keyboard.IsKeyPressed(Keyboard.Key.S) && sprite.Position.Y < 862)
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

    protected override void CollideWith(Scene scene, Entity e)
    {
        if (e is EnemyShip)
        {
            scene.PublishLostHealth(1);
            e.isDead = true;
        }
    }
    
    private void OnLoseHealth(Scene scene, int amount)
    {
        Reset();
    }

}