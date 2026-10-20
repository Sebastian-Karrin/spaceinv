using SFML.Graphics;
using System.Collections.Generic;
using SFML.System;
using SFML.Window;
using spaceinv;

namespace spaceinv;

public delegate void ValueChangeEvent(int value);

public class EventHandler
{
    public event ValueChangeEvent LoseHealth;
    public int lostHealth;
    public void PublishLostHealth(int amount) => lostHealth += amount;

    public void InvokeEvent(Scene scene)
    {
        if (lostHealth != 0)
        {
            LoseHealth?.Invoke(lostHealth);
            lostHealth = 0;
        }
    }
}

