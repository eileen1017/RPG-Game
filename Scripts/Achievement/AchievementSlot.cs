using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reward;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private Button collectBtn;

    //[SerializeField] private bool collected;
    public AchievementInfo thisItem;
    public AchievementManager thisManager;
    public AchievementTracker _achievementTracker;

    //public SignalScript achievementSignal;

    public void Setup(AchievementInfo item, AchievementManager manager)
    {
        thisItem = item;
        thisManager = manager;
        if (thisItem)
        {
            itemName.text = thisItem.itemName;
            itemText.text = thisItem.itemDescription;
            reward.text = "" + thisItem.reward;
            
            if (thisItem.isAchieved)
            {
                if (!_achievementTracker._myAchievement.Contains(thisItem))
                {
                    _achievementTracker._myAchievement.Add(thisItem);
                }
                if (thisItem.isCollected)
                {
                    ColorBlock colorBlock = collectBtn.colors;
                    colorBlock.disabledColor = Color.clear;
                    collectBtn.colors = colorBlock;
                    collectBtn.interactable = false;
                    
                }
                else
                {
                    collectBtn.interactable = true;
                    
                }
            }
            else
            {
                collectBtn.interactable = false;
            }
            
        }
    }

    public void ClickedOn()
    {
        if (thisItem)
        {
            if (thisItem.isAchieved)
            {
                thisItem.isCollected = true;
                collectBtn.interactable = false;
                
                if (thisManager)
                {
                    thisManager.ClearASlots();
                    thisManager.MakeASlots();
                }
                
                thisItem.Collect();

            }
        }
    }

}
