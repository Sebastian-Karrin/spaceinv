using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace spaceinv;

public class Entity
{
    private readonly string textureName;
    private readonly string fontName;
    protected readonly Sprite sprite;
    public bool isDead = false;
    public FloatRect Bounds =>sprite.GetGlobalBounds();
    public Vector2f Position { get => sprite.Position; set => sprite.Position = value; }
    public virtual bool Solid => false;
    public int RenderOrder { get; set; } = 0;

    protected Entity(string textureName, string fontName)
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
        foreach (Entity found in scene.FindIntersects(Bounds))
        {
            CollideWith(scene, found);
        }
    }

    public virtual void Render(RenderTarget target)
    {
        target.Draw(sprite);
    }

    public virtual void Destroy(Scene scene)
    {
        
    }
    
    protected virtual void CollideWith(Scene scene, Entity other){}

    
    
}