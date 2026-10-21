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
    private float delay = 0.1f;
    
    public Explosion() : base("Explosion Medium", "")
    {
        frames = new List<IntRect>();
        frames.Add(frame1);
        frames.Add(frame2);
        frames.Add(frame3);
        frames.Add(frame4);
        frames.Add(frame5);
        frames.Add(frame6);
        
        sprite.Scale = new Vector2f(5.0f, 5.0f);
    }
    
    public override void Create(Scene scene)
    {
        base.Create(scene);
       
    }
    public override void Update(Scene scene, float deltaTime)
    {
        aniTimer = MathF.Max(aniTimer - deltaTime, 0.0f);
            if (aniTimer >= delay)
            {
                currentFrame++;
                aniTimer = 0.0f;
            }
         base.Update(scene, deltaTime);

    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);

        if (frames.Count > 0)
        {
            sprite.TextureRect = frames[currentFrame];
        }

        foreach (var frame in frames)
        {
            if (aniTimer < 0.1f)
            {
                Console.WriteLine($"{frame}");
                sprite.TextureRect = frame;
                aniTimer = 0.15f;
            }
        }
        
        
    }
    public override void Destroy(Scene scene)
    {
        base.Destroy(scene);
    }

    public void Location(Scene scene, EnemyShip enemyShip)
    {
        sprite.Position = new Vector2f(enemyShip.Position.X / 5.0f, enemyShip.Position.Y / 5.0f);
    }

    public void Animation()
    {
        
    }
}