using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNumText;
    [SerializeField] private Image itemImage;

    public InventoryItems thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItems item, InventoryManager manager)
    {
        thisItem = item;
        thisManager = manager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumText.text = "" + thisItem.numberHad;
        }
    }

    public void ClickOn()
    {
        if (thisItem)
        {
            thisManager.SetupDescriptionBtn(thisItem.itemDescription, thisItem);

        }
    }
}
