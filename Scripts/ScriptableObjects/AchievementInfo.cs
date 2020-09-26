using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Achievement/AchievementItems")]

public class AchievementInfo : ScriptableObject
{
    public string itemName;
    public string itemDescription;

    public int reward;

    public bool isAchieved;
    public bool isCollected;

    public UnityEvent thisEvent;

    public void Collect()
    {
        thisEvent.Invoke();
    }

    public void ClickedOn()
    {
        if (isAchieved)
        {
            isCollected = true;
        }
    }
}