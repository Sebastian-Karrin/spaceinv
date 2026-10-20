using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class Bullet : Entity
{
    private Vector2f herodirection = new Vector2f(0, -1);
    private Vector2f enemydirection = new Vector2f(0, 1);
    public enum CreatorType { HerosShip, EnemyShip }
    public CreatorType creator;
    /*public Sprite heroShot;
    public Sprite enemyShot;*/
    
    public Bullet() : base("sheet", "kenvector_future_thin")
    {
        sprite.TextureRect = new IntRect(856, 421, 9, 54);
        /*heroShot.TextureRect = new IntRect(856, 421, 9, 54);
        enemyShot.TextureRect = new IntRect(856, 421, 9, 54);*/
        sprite.Position = new Vector2f(450, 450);
       /* heroShot.Position = new Vector2f(300, 300);
        enemyShot.Position = new Vector2f(600, 600);*/
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        
    }
    public override void Update(Scene scene, float deltaTime)
    {
        
        base.Update(scene, deltaTime);
        if (creator == CreatorType.HerosShip)
        {
            var newHPos = sprite.Position;
            newHPos += new Vector2f(0,-1) * deltaTime * 300.0f;
            sprite.Position = newHPos;
        }
        if (creator == CreatorType.EnemyShip)
        {
            var newHPos = sprite.Position;
            newHPos += new Vector2f(0,1) * deltaTime * 300.0f;
            sprite.Position = newHPos;
        }
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }
    
    public override void Destroy(Scene scene)
    {
        if (Position.Y < 50)
        {
            base.Destroy(scene);
            isDead = true;
            scene.Clear();
        }
    }

    public void HeroBullet(Scene scene,HeroShip heroShip)
    {
        this.creator = CreatorType.HerosShip;
        Bullet heroBullet1 = new Bullet();
        Bullet heroBullet2 = new Bullet();
        scene.Spawn(heroBullet1);
        scene.Spawn(heroBullet2);
        heroBullet1.Position = new Vector2f(heroShip.Position.X - 20, heroShip.Position.Y);
        heroBullet2.Position = new Vector2f(heroShip.Position.X + 20, heroShip.Position.Y);
    }

    public void EnemyBullet(Scene scene, EnemyShip enemyShip)
    {
        this.creator = CreatorType.EnemyShip;
        Bullet enemyBullet1 =  new Bullet();
        Bullet enemyBullet2 = new Bullet();
        scene.Spawn(enemyBullet1);
        
        enemyBullet1.Position = new Vector2f(enemyShip.Position.X, enemyShip.Position.Y);
    }
}