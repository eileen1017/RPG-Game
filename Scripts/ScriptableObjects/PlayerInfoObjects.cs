using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInfoObjects : ScriptableObject
{
    public string playerName;
    public Sprite playerSprite;
    public int maxHealth;
    public int damage;
    public int amountMoney;
}
