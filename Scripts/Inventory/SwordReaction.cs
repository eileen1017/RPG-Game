using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordReaction : MonoBehaviour
{
    public PlayerInfoObjects playerInfo;
    public SignalScript damageSignal;
    public void Use()
    {
        playerInfo.damage += 10;
        damageSignal.Raise();
    }
}
