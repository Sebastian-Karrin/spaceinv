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
        HeroShip heroShip = new HeroShip();
        GUI gui = new GUI();
        Background background = new Background();

            
        scene.Spawn(background);
        scene.Spawn(gui);
        scene.Spawn(heroShip);
    }

    public void EnemyShipSpawner(Scene scene)
    {
        EnemyShip enemyShip = new EnemyShip();
        scene.Spawn(enemyShip);
        /*if (scene.spawnTimer < 1.0f)
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
        }*/
    }
    
}