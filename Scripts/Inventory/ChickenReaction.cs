using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenReaction : MonoBehaviour
{
    public PlayerInfoObjects playerInfo;
    public SignalScript playerHealthSignal;


    public void Use()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerInfo.maxHealth += 100;
        playerHealthSignal.Raise();
    }
}
