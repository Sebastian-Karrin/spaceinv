using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace spaceinv;

public class GUI : Entity
{
    private int maxHealth;
    private int currentHealth;
    
    private Text scoreText;
    private int currentScore;
    
    public GUI() : base("sheet", "kenvector_future_thin")
    {
        sprite.TextureRect = new IntRect(482, 358, 33, 25);
        maxHealth = 3;
        scoreText = new Text();
        scoreText.Color = Color.White;
    }
    
    public override void Create(Scene scene)
    {
        
        currentHealth = maxHealth;
        scene.LoseHealth += OnLoseHealth;
        scene.ScoreGained += OnGainScore;
        
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
        if (currentHealth <= 0)
        {
            scoreText.DisplayedString = $"Score: {currentScore}";
            scoreText.Position = new Vector2f(450, 450);
            target.Draw(scoreText);
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
    
    private void OnGainScore(Scene scene, int score)
    {
        currentScore += score;
        if (currentHealth <= 0)
        {
            scene.ScoreGained -= OnGainScore;
        }
    }
}