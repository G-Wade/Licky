using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishData 
{
    public bool fish0Collected;
    public bool fish1Collected;
    public bool fish2Collected;
    public bool fish3Collected;
    public bool fish4Collected;
    public bool fish5Collected;
    public bool fish6Collected;
    public bool fish7Collected;

    public FishData (Interactions interactions) {
        fish0Collected = interactions.getFish0Collected;
        fish1Collected = interactions.getFish1Collected;
        fish2Collected = interactions.getFish2Collected;
        fish3Collected = interactions.getFish3Collected;
        fish4Collected = interactions.getFish4Collected;
        fish5Collected = interactions.getFish5Collected;
        fish6Collected = interactions.getFish6Collected;
        fish7Collected = interactions.getFish7Collected;
    }

    public bool getFish0Collected {
        get { return fish0Collected; }
        set { fish0Collected = value; }
    }

    public bool getFish1Collected {
        get { return fish1Collected; }
        set { fish1Collected = value; }
    }

    public bool getFish2Collected {
        get { return fish2Collected; }
        set { fish2Collected = value; }
    }

    public bool getFish3Collected {
        get { return fish3Collected; }
        set { fish3Collected = value; }
    }

    public bool getFish4Collected {
        get { return fish4Collected; }
        set { fish4Collected = value; }
    }

    public bool getFish5Collected {
        get { return fish5Collected; }
        set { fish5Collected = value; }
    }

    public bool getFish6Collected {
        get { return fish6Collected; }
        set { fish6Collected = value; }
    }

    public bool getFish7Collected {
        get { return fish7Collected; }
        set { fish7Collected = value; }
    }
}