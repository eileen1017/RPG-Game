using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Image itemImage;

    public InventoryItems thisItem;
    public ShopManager thisManager;

    public void Setup(InventoryItems item, ShopManager manager)
    {
        thisItem = item;
        thisManager = manager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemPrice.text = "" + thisItem.price;
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
