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

    public void Load(Scene scene)
    {
        Create();
    }

    public void LoadScene(Scene scene)
    {
        scene.Clear();
        Background background = new Background();
        HeroShip heroShip = new HeroShip();
        
        scene.Spawn(heroShip);
        scene.Spawn(background);
    }

    public void Create()
    {
       
    }
    
}