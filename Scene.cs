using System.Data;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace spaceinv;

public class Scene
{
    public readonly AssetManager Assets;
    public readonly SceneLoader Loader;
    public List<Entity> entities;
    public bool gameOver;

    public Scene()
    {
        entities = new List<Entity>();
        Loader = new SceneLoader();
        Assets = new AssetManager();
        gameOver = false;
    }

    public void Spawn(Entity entity)
    {
        entities.Add(entity);
        entity.Create(this);
    }

    public void UpdateAll(float deltaTime)
    {
        
        for (int i = entities.Count - 1; i >= 0; i--)
        {
            Entity entity = entities[i];
            entity.Update(this, deltaTime);
        }
        
        for (int i = 0; i < entities.Count; i++)
        {
            Entity entity = entities[i];
            if (entity.isDead) entities.RemoveAt(i);
            else i++;
        }
    }

    public void RenderAll(RenderTarget target)
    {
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].Render(target);
        }
    }

    public void Clear()
    {
        for (int i = entities.Count - 1; i >= 0; i--)
        {
            Entity entity = entities[i];
            entities.RemoveAt(i);
            entity.Destroy(this);
        }
    }
    
    public IEnumerable<Entity> FindIntersects(FloatRect bounds) // letar efter collisions
    {
        int lastEntity = entities.Count - 1;
        for (int i = lastEntity; i >= 0; i--)
        {
            Entity entity = entities[i];
            if (entity.isDead) continue;
            if (entity.Bounds.Intersects(bounds))
            {
                yield return entity;
            }
        }
        
    }

    public bool FindByType<T>(out T found) where T : Entity
    {
        foreach (Entity entity in entities)
        {
            if (!entity.isDead && entity is T typed)
            {
                found = typed;
                return true;
            }
        }
        found = default(T);
        return false;
    }
}