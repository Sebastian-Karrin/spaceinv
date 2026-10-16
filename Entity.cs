using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace spaceinv;

public class Entity
{
    private readonly string textureName;
    private readonly string fontName;
    protected readonly Sprite sprite;
    public bool isDead;
    public FloatRect Bounds =>sprite.GetGlobalBounds();
    public Vector2f Position { get => sprite.Position; set => sprite.Position = value; }
    public virtual bool Solid => false;

    protected Entity(string textureName)
    {
        this.textureName = textureName;
        this.fontName = fontName;
        sprite = new Sprite();
        isDead = false;
    }

    public virtual void Create(Scene scene)
    {
        sprite.Texture = scene.Assets.LoadTexture(textureName);
    }

    public virtual void Update(Scene scene, float deltaTime)
    {
        
    }

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }

    public virtual void Destroy(Scene scene)
    {
        
    }
    
    
}