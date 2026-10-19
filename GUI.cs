using SFML.Graphics;
using SFML.Window;
using SFML.Graphics;

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
        base.Create(scene);
    }
    
    public override void Update(Scene scene, float deltaTime)
    {
        base.Update(scene, deltaTime);
    }
    public override void Render(RenderTarget target)
    {
        base.Render(target);
    }
}