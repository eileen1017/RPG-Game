using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AReaction : MonoBehaviour
{
    public PlayerInfoObjects playerInfo;
    public SignalScript rewardSignal;

    public void Collect()
    {
        playerInfo.amountMoney += 100;
        rewardSignal.Raise();
    }
}
