using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerInfoObjects playerInfo;
    public SignalScript playerHealthSignal;

    public void Use()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth.playerHealth = playerInfo.maxHealth;
        playerHealthSignal.Raise();
    }
}
