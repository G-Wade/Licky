using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int health;
    public int fish;
    public float[] position;

    public PlayerData (Interactions interactions, PlayerMovementController player) {
        health = interactions.getHealth;
        fish = interactions.getFish;

        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }

    public int getHealth {
        get { return health; }
        set { health = value; }
    }

    public int getFish {
        get { return fish; }
        set { fish = value; }
    }
}
