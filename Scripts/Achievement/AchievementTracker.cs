using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement/Achievement Tracker")]
public class AchievementTracker : ScriptableObject
{
    public List<AchievementInfo> _myAchievement = new List<AchievementInfo>();


}
