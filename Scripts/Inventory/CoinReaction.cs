using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinReaction : MonoBehaviour
{
    public PlayerInfoObjects playerInfo;
    public SignalScript coinSignal;
    public void Use()
    {
        playerInfo.amountMoney += 50;
        coinSignal.Raise();
    }
}
