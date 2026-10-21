using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class GUI : Entity
{
    private Text scoreText;
    private int maxHealth;
    private int currentHealth;
    private int currentScore;
    
    public GUI() : base("sheet", "kenvector_future_thin")
    {
        sprite.TextureRect = new IntRect(482, 358, 33, 25);
        maxHealth = 3;
    }
    
    public override void Create(Scene scene)
    {
        currentHealth = maxHealth;
        scene.LoseHealth += OnLoseHealth;
        base.Create(scene);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
    }
    public override void Render(RenderTarget target)
    {
        base.Render(target);
        sprite.Position = new Vector2f(450, 850);
        for (int i = 0; i < maxHealth; i++)
        {
            sprite.TextureRect = i < currentHealth
                ? new IntRect(482, 358, 33, 25)
                : new IntRect(797, 174, 30, 32);
            base.Render(target);
            sprite.Position += new Vector2f(33, 0);
        }
    }

    private void OnLoseHealth(Scene scene, int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            scene.gameOver = true;
            scene.LoseHealth -= OnLoseHealth;
        }
    }
}