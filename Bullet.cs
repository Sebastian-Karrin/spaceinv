using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class Bullet : Entity
{
    public Vector2f bulletDirection;
    public Vector2f UP = new Vector2f(0, -1);
    public Vector2f DOWN = new Vector2f(0, 1);
    public List<Bullet> EBullets;
    public List<Bullet> HBullets;

    public Bullet() : base("sheet", "kenvector_future_thin")
    {
        sprite.TextureRect = new IntRect(856, 421, 9, 54);
        HBullets = new List<Bullet>();
        EBullets = new List<Bullet>();
       
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        
    }
    public override void Update(Scene scene, float deltaTime)
    {
        var newPos = sprite.Position;
        sprite.Position += bulletDirection * deltaTime * 300.0f; 
        sprite.Position = newPos;
        
        
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

    public void HeroBullet(Scene scene,HeroShip heroShip, Vector2f direction)
    {
        Bullet hbullet = new Bullet();
        scene.Spawn(hbullet);
        HBullets.Add(hbullet);
        hbullet.Position = heroShip.Position;
        bulletDirection = direction;
    }

    public void EnemyBullet(Scene scene, EnemyShip enemyShip, Vector2f direction)
    {
        Bullet ebullet = new Bullet();
        scene.Spawn(ebullet);
        EBullets.Add(ebullet);
        ebullet.Position = new Vector2f(enemyShip.Position.X, enemyShip.Position.Y);
        bulletDirection = direction;
        
    }

    protected override void CollideWith(Scene scene, Entity e)
    {
    }
    
}