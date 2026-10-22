using System.Diagnostics;
using System.Security.Cryptography;
using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class Explosion : Entity
{
    private IntRect frame1 = new IntRect(0,0,64,64);
    private IntRect frame2 = new IntRect(64,0,64,64);
    private IntRect frame3 = new IntRect(128,0,64,64);
    private IntRect frame4 = new IntRect(192,0,64,64);
    private IntRect frame5 = new IntRect(256,0,64,64);
    private IntRect frame6 = new IntRect(320,0,64,64);
    private List<IntRect> frames;
    private int currentFrame = 0;
    private float aniTimer = 0.0f;
    private float delay = 1f;
    private Clock aniClock;
    
    public Explosion() : base("Explosion Medium", "")
    {
        frames = new List<IntRect>();
        frames.Add(frame1);
        frames.Add(frame2);
        frames.Add(frame3);
        frames.Add(frame4);
        frames.Add(frame5);
        frames.Add(frame6);
        sprite.Scale =  new Vector2f(5,5);
        aniClock = new Clock();
        sprite.TextureRect = frame3;
    }
    
    public override void Create(Scene scene)
    {
        base.Create(scene);
    }
    public override void Update(Scene scene, float deltaTime)
    {
        aniTimer = MathF.Max(aniTimer - deltaTime, 0.0f);
        /*if(frames.Count > 0)
        {
            if (aniTimer >= delay)
            {
                currentFrame++;
                aniTimer = 0.0f;
            }
            base.Update(scene, deltaTime);
        }*/
        base.Update(scene, deltaTime);
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
        /*if (frames.Count > 0)
        {
            sprite.TextureRect = frames[currentFrame];
            aniTimer = 0.2f;
        }
        target.Draw(sprite);*/
        
    }
    public override void Destroy(Scene scene)
    {
        base.Destroy(scene);
    }
    public void Animation()
    {
        if (delay < aniClock.ElapsedTime.AsSeconds())
        {
            sprite.TextureRect = frame1;
            aniTimer = aniClock.ElapsedTime.AsSeconds();
        }
        if (sprite.TextureRect == frame1 && delay < aniClock.ElapsedTime.AsSeconds())
        {
            sprite.TextureRect = frame2;
            aniTimer = aniClock.ElapsedTime.AsSeconds();
        }
        if (sprite.TextureRect == frame2 && delay < aniClock.ElapsedTime.AsSeconds())
        {
            sprite.TextureRect = frame3;
            aniTimer = aniClock.ElapsedTime.AsSeconds();
        }
        if (sprite.TextureRect == frame3 && delay < aniClock.ElapsedTime.AsSeconds())
        {
            sprite.TextureRect = frame4;
            aniTimer = aniClock.ElapsedTime.AsSeconds();
        }
        if (sprite.TextureRect == frame4 && delay < aniClock.ElapsedTime.AsSeconds())
        {
            sprite.TextureRect = frame5;
            aniTimer = aniClock.ElapsedTime.AsSeconds();
        }
        if (sprite.TextureRect == frame5 && delay < aniClock.ElapsedTime.AsSeconds())
        {
            sprite.TextureRect = frame6;
            aniTimer = aniClock.ElapsedTime.AsSeconds();
        }
    }

    public void Explode(Scene scene, EnemyShip enemyShip)
    {
        aniTimer = 1.5f;
        if (aniTimer > 1.0f)
        {
            scene.Spawn(this);
            sprite.Position = new Vector2f(enemyShip.Position.X - 150, enemyShip.Position.Y - 140);
        }
    }
}