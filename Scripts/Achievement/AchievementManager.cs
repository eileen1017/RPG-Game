using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public AchievementTracker _achievementTracker;
    public PlayerInfoObjects playerInfo;

    [SerializeField] private GameObject achievementSlot;
    [SerializeField] private GameObject achievementBoard;

    public AchievementInfo[] allAchievement;


    public void MakeASlots()
    {
        for (int i = 0; i < allAchievement.Length; i++)
        {
            GameObject itemTemp = Instantiate(achievementSlot, achievementBoard.transform.position, Quaternion.identity);
            itemTemp.transform.SetParent(achievementBoard.transform);
            AchievementSlot newSlot = itemTemp.GetComponent<AchievementSlot>();
            if (newSlot)
            {
                newSlot.Setup(allAchievement[i], this);
            }

        }
        
    }

    public void ClearASlots()
    {
        for (int i = 0; i < achievementBoard.transform.childCount; i++)
        {
            Destroy(achievementBoard.transform.GetChild(i).gameObject);
        }
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearASlots();
        MakeASlots();
    }


}
