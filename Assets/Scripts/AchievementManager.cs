using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    private Image check;
    
    void Start()
    {
        check = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        check.enabled = AchievementData.getHealthAchievement();
    }
}
