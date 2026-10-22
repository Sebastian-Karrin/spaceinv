using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class Bullet : Actor
{
    public Vector2f direction {get; set;}
    private float bulletSpeed = 200.0f;
    private string ownerTag;
    
    public Bullet(string ownertag) : base()
    {
        sprite.TextureRect = new IntRect(856, 421, 9, 54);
        ownerTag = ownertag;
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        
    }
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        if (ownerTag == "playerBullet")
        {
            var newHPos = sprite.Position;
            sprite.Position += new Vector2f(0,-1) * deltaTime * bulletSpeed;
            newHPos = sprite.Position;
        }

        if (ownerTag == "enemyBullet")
        {
            var newEPos = sprite.Position;
            sprite.Position += new Vector2f(0,1) * deltaTime * bulletSpeed;
            newEPos = sprite.Position;
            sprite.Rotation = 180.0f;
        }
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }
    
    public override void Destroy(Scene scene)
    {
       base.Destroy(scene);
    }

    public void HeroBullet(Scene scene,HeroShip heroShip, string tag)
    {
        ownerTag = tag;
        Bullet hbullet1 = new Bullet("playerBullet");
        Bullet hbullet2 = new Bullet("playerBullet");
        scene.Spawn(hbullet1);
        scene.Spawn(hbullet2);
        hbullet1.Position = new Vector2f(heroShip.Position.X - 30, heroShip.Position.Y + 10);
        hbullet2.Position = new Vector2f(heroShip.Position.X + 30, heroShip.Position.Y + 10);
        
    }
    public void EnemyBullet(Scene scene, EnemyShip enemyShip, string tag)
    {
        ownerTag = tag;
        Bullet ebullet = new Bullet("enemyBullet");
        scene.Spawn(ebullet);
        ebullet.Position = new Vector2f(enemyShip.Position.X, enemyShip.Position.Y);
        
    }
    protected override void CollideWith(Scene scene, Entity e)
    {
        if (e is HeroShip)
        {
            if (ownerTag != "playerBullet")
            {
                scene.PublishLostHealth(1);
            }
        }

        if (e is EnemyShip)
        {
            e.isDead = true;
        }
    }
}