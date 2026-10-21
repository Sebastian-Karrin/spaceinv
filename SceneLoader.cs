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

    public void LoadScene(Scene scene)
    {
        scene.Clear();
        GUI gui = new GUI();
        HeroShip heroShip = new HeroShip();
        EnemyShip enemyShip = new EnemyShip();
        Background background = new Background();

            
        scene.Spawn(background);
        scene.Spawn(enemyShip);
        scene.Spawn(heroShip);
        scene.Spawn(gui);
        
    }

    public void Reload(Scene scene)
    {
        LoadScene(scene);
    }

    public void EnemyShipSpawner(Scene scene)
    {
        if (scene.spawnTimer < 1.0f)
        {
            scene.spawnTimer = 10.0f;
            for (float i = scene.spawnTimer; i >= 2; i--)
            {
                scene.spawnTimer += i;
                if(!scene.FindByType<EnemyShip>(out _))
                {
                    EnemyShip enemyShip = new EnemyShip();
                    scene.Spawn(enemyShip);
                }
               
            }
        }
    }

    public void EnemySpawner(Scene scene)
    {
        EnemyShip enemyShip = new EnemyShip();
        scene.Spawn(enemyShip);
    }
    
}