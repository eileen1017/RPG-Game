using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    public PlayerInfoObjects playerInfo;
    public PlayerHealth playerHealth;
    public SignalScript healthSignal;
    public SignalScript damageSignal;
    public SignalScript moneySignal;

    public PlayerInventory _playerInventory;
    public InventoryItems healthitem;
    public InventoryItems sworditem;
    public InventoryItems moneyitem;
    public InventoryItems chickenitem;

    public GameObject mainMenu;
    public GameObject achievementsMenu;
    public GameObject resetMenu;

    public AchievementTracker ATracker;
    public MapTravelTracker MTT;
    public NPCTracker npcs;
    public GhostKilled gKilled;

    public GameObject errorWindow;

    void OnEnable()
    {
        SwitchMainMenu();
    }
    
    void SwitchMenu(GameObject someMenu)
    {
        mainMenu.SetActive(false);
        achievementsMenu.SetActive(false);
        resetMenu.SetActive(false);

        someMenu.SetActive(true);
    }

    public void SwitchMainMenu()
    {
        SwitchMenu(mainMenu);
    }

    public void SwitchAchievementsMenu()
    {
        SwitchMenu(achievementsMenu);
    }

    public void SwitchResetMenu()
    {
        SwitchMenu(resetMenu);
    }

    public void ResetAchievement()
    {
        if (ATracker._myAchievement.Count < 7)
        {
            errorWindow.SetActive(true);
        } 
        else
        {
            if (ATracker._myAchievement.Count != 0)
            {
                ResetAchievementTracker();
            }
        }
    }

    void ResetAchievementTracker()
    {
        gKilled.ghostKilled = 0;
        foreach (AchievementInfo achievement in ATracker._myAchievement)
        {
            if (achievement.isAchieved)
            {
                achievement.isAchieved = false;
                if (achievement.isCollected)
                {
                    achievement.isCollected = false;
                }
            }
        }
        MTT.Church = false;
        MTT.Desert = false;
        MTT.Island = false;
        MTT.Village = false;
        MTT.Lava = false;
        MTT.Underground = false;
        MTT.Undersea = false;

        npcs.Desert = false;
        npcs.Island = false;
        npcs.Village = false;
        npcs.Lava = false;
        npcs.Underground = false;

        ATracker._myAchievement.Clear();
    }

    public void ResetPlayerInfo()
    {
        playerInfo.amountMoney = 1000;
        playerInfo.damage = 10;
        playerInfo.maxHealth = 100;
        playerHealth.playerHealth = playerInfo.maxHealth;
        healthSignal.Raise();
        damageSignal.Raise();
        moneySignal.Raise();
    }

    public void ResetInventory()
    {
        _playerInventory._myInventory.Clear();
        healthitem.numberHad = 0;
        sworditem.numberHad = 0;
        moneyitem.numberHad = 0;
        chickenitem.numberHad = 0;

    }


}
