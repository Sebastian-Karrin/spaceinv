using System.ComponentModel.Design.Serialization;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace spaceinv;

public class SceneLoader
{
    private Clock enemyClock;
    private float stopper = 8.0f;
    
    public SceneLoader()
    {
        enemyClock = new Clock();
    }
    
    public void CreateScene(Scene scene)
    {
        if (!scene.FindByType<Background>(out _))
        {
            scene.Spawn(new Background());
        }

        if (!scene.FindByType<HeroShip>(out _))
        {
            scene.Spawn(new HeroShip());
        }
        
        if (!scene.FindByType<EnemyShip>(out _))
        {
            scene.Spawn(new EnemyShip());
        }

        if (!scene.FindByType<GUI>(out _))
        {
            scene.Spawn(new GUI());
        }
    }

    public void Reload(Scene scene)
    {
        scene.Clear();
        CreateScene(scene);
        EnemyShipSpawner(scene);
    }

    public void EnemyShipSpawner(Scene scene)
    {
        if (stopper < enemyClock.ElapsedTime.AsSeconds())
        {
            if (stopper > 3.0f)
            {
                stopper -= 0.5f;
            }
            enemyClock.Restart();
            EnemySpawner(scene);
        }
    }

    public void EnemySpawner(Scene scene)
    {
        EnemyShip enemyShip = new EnemyShip();
        scene.Spawn(enemyShip);
    }
    
}