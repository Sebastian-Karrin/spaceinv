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
        HeroShip heroShip = new HeroShip();
        EnemyShip enemyShip = new EnemyShip();
        Bullet bullet = new Bullet();
        GUI gui = new GUI();
        Background background = new Background();

            
        scene.Spawn(background);
        scene.Spawn(heroShip);
        scene.Spawn(enemyShip);
    }

    public void Create()
    {
       
    }
    
}