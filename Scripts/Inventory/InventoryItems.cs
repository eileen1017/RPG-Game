using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]

public class InventoryItems : ScriptableObject
{
    public string itemName;
    public string itemDescription;

    public Sprite itemImage;
    public int numberHad;

    public int price;

    public UnityEvent thisEvent;

    public void Use()
    {
        thisEvent.Invoke();
    }

    public void DecreaseItem()
    {
        numberHad--;
        if (numberHad < 0)
        {
            numberHad = 0;
        }
    }
}
