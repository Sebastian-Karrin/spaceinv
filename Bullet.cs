using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class Bullet : Entity
{
    private Vector2f herodirection = new Vector2f(0, -1);
    private Vector2f enemydirection = new Vector2f(0, 1);

    private List<Bullet> hBullets;
    private List<Bullet> eBullets;
    private Sprite _sprite;
    
    public bool IsFromHero { get; set; } = false;
    public bool isFromEnemy { get; set; } = false;
    
    
    public Bullet() : base("sheet", "kenvector_future_thin")
    {
        _sprite = new Sprite(sprite);
        _sprite.Texture = new Texture("assets/sheet.png");
        _sprite.TextureRect = new IntRect(856, 984, 9, 54);
        sprite.TextureRect = new IntRect(856, 421, 9, 54);
        sprite.Position = new Vector2f(450, 450);
       hBullets = new List<Bullet>();
       eBullets = new List<Bullet>();
    }

    public override void Create(Scene scene)
    {
        base.Create(scene);
        
    }
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
        foreach (var hBullet in hBullets)
        {
            if(IsFromHero)
            {
                var newEPos = sprite.Position;
                newEPos += new Vector2f(0,-1) * deltaTime * 300.0f;
                sprite.Position = newEPos;
                return;
            }
        }

        foreach (var eBullet in eBullets)
        {
            if (isFromEnemy = true)
            {
                var newEPos = _sprite.Position;
                newEPos += new Vector2f(0, 1) * deltaTime * 300.0f;
                _sprite.Position = newEPos;
                return;
            }
        }

    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }
    
    public override void Destroy(Scene scene)
    {
        if (sprite.Position.Y < 50)
        {
            base.Destroy(scene);
            isDead = true;
            scene.Clear();
        }
    }

    public void HeroBullet(Scene scene,HeroShip heroShip)
    {
        
        IsFromHero = true;
        Bullet heroBullet1 = new Bullet();
        Bullet heroBullet2 = new Bullet();
        scene.Spawn(heroBullet1);
        scene.Spawn(heroBullet2);
        hBullets.Add(heroBullet1);
        hBullets.Add(heroBullet2);
        heroBullet1.Position = new Vector2f(heroShip.Position.X - 20, heroShip.Position.Y);
        heroBullet2.Position = new Vector2f(heroShip.Position.X + 20, heroShip.Position.Y);
    }

    public void EnemyBullet(Scene scene, EnemyShip enemyShip)
    {
        isFromEnemy = true;
        Bullet enemyBullet =  new Bullet(); 
        
        scene.Spawn(enemyBullet);
        eBullets.Add(enemyBullet);
        enemyBullet.Position = new Vector2f(enemyShip.Position.X, enemyShip.Position.Y);
    }

    protected override void CollideWith(Scene scene, Entity other)
    {
        if (other is HeroShip)
        {
            
        }
        
    }
    
}