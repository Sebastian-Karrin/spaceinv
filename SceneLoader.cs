using System.ComponentModel.Design.Serialization;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace spaceinv;

public class SceneLoader
{
    private readonly Dictionary<char, Func<Entity>> loaders;
    private string currentScene = "", nextScene = "";
    
    public SceneLoader()
    {
        loaders = new Dictionary<char, Func<Entity>>();
    }

    public void Create(Scene scene)
    {
        Entity entity = new EnemyShip();
        Entity entity2 = new HeroShip();
        Entity entity3 = new Background();
    }
    
}