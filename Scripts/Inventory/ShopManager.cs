using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEditor;

public class ShopManager : MonoBehaviour
{
    public PlayerInventory _playerInventory;
    public PlayerInfoObjects playerInfo;

    [SerializeField] private GameObject shopSlot;
    [SerializeField] private GameObject ShopBoard;

    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject buyButton;

    public InventoryItems currentItem;

    public InventoryItems HealthItem;
    public InventoryItems ChickenItem;
    public InventoryItems SwordItem;

    public GameObject errorWindow;


    public void SetTextBtn(string itemDescription, bool btnaAtive)
    {
        descriptionText.text = itemDescription;
        if (btnaAtive)
        {
            buyButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);
        }
    }

    void MakeShopSlots(InventoryItems itemName)
    {
        GameObject itemTemp = Instantiate(shopSlot, ShopBoard.transform.position, Quaternion.identity);
        itemTemp.transform.SetParent(ShopBoard.transform);
        ShopSlot newSlot = itemTemp.GetComponent<ShopSlot>();
        if (newSlot)
        {
            newSlot.Setup(itemName, this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTextBtn("", false);
        MakeShopSlots(HealthItem);
        MakeShopSlots(ChickenItem);
        MakeShopSlots(SwordItem);
    }
    public void SetupDescriptionBtn(string newItemDescription, InventoryItems newItem)
    {
        currentItem = newItem;
        descriptionText.text = newItemDescription;
        buyButton.SetActive(true);

    }

    void AddItemToPI()
    {
        if (_playerInventory && currentItem)
        {
            if (_playerInventory._myInventory.Contains(currentItem))
            {
                currentItem.numberHad++;
            }
            else
            {
                _playerInventory._myInventory.Add(currentItem);
                currentItem.numberHad++;
            }
        }
    }

    public void itemBought()
    {
        if (currentItem && playerInfo.amountMoney >= currentItem.price)
        {
            AddItemToPI();
            playerInfo.amountMoney -= currentItem.price;
        } 
        else
        {
            errorWindow.SetActive(true);
        }
    }
}
