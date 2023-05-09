using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AchievementData
{
    static bool healthAchievement = false;

    public static bool getHealthAchievement() {
        return healthAchievement;
    }

    public static void setHealthAchievement(bool complete) {
        healthAchievement = complete;
    }
}
