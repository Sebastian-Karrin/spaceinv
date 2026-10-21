using System.Diagnostics;
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
    private float animationTimer;
    private Clock animationClock;
    
    
    private const float Diameter = 15.0f;
    private Vector2f size;
    
    public Explosion() : base("Explosion Medium", "")
    {
        animationClock = new Clock();
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
        base.Update(scene, deltaTime);
    }
    
    public override void Render(RenderTarget target)
    {
        base.Render(target);
        if (sprite.TextureRect != frame1 && sprite.TextureRect != frame6 && animationClock.ElapsedTime.AsSeconds() > animationTimer + 0.25f)
        {
            animationClock.Restart();
            animationTimer = animationClock.ElapsedTime.AsSeconds();
            sprite.TextureRect = frame1;
        }
        else if (sprite.TextureRect != frame1 && animationClock.ElapsedTime.AsSeconds() > animationTimer + 0.25f)
        {
            animationClock.Restart();
            animationTimer = animationClock.ElapsedTime.AsSeconds();
            sprite.TextureRect = frame2;
        }
        else if (sprite.TextureRect != frame2 && animationClock.ElapsedTime.AsSeconds() > animationTimer + 0.25f)
        {
            animationClock.Restart();
            animationTimer = animationClock.ElapsedTime.AsSeconds();
            sprite.TextureRect = frame3;
        }
        else if (sprite.TextureRect != frame3 && animationClock.ElapsedTime.AsSeconds() > animationTimer + 0.25f)
        {
            animationClock.Restart();
            animationTimer = animationClock.ElapsedTime.AsSeconds();
            sprite.TextureRect = frame4;
        }
        else if (sprite.TextureRect != frame4 && animationClock.ElapsedTime.AsSeconds() > animationTimer + 0.25f)
        {
            animationClock.Restart();
            animationTimer = animationClock.ElapsedTime.AsSeconds();
            sprite.TextureRect = frame5;
        }
        else if (sprite.TextureRect != frame5 && animationClock.ElapsedTime.AsSeconds() > animationTimer + 0.25f)
        {
            animationClock.Restart();
            animationTimer = animationClock.ElapsedTime.AsSeconds();
            sprite.TextureRect = frame6;
        }
        
        /*if (animationClock.ElapsedTime.AsSeconds() > animationTimer + 0.25f)
        {
            animationClock.Restart();
            animationTimer = animationClock.ElapsedTime.AsSeconds();
            foreach (IntRect frame in frames)
            {
                sprite.TextureRect = frame;
            }
        }*/
    }
    public override void Destroy(Scene scene)
    {
        base.Destroy(scene);
    }

    public void Location(Scene scene, EnemyShip enemyShip)
    {
        sprite.Position = new Vector2f(enemyShip.Position.X / 5.0f, enemyShip.Position.Y / 5.0f);
    }
}