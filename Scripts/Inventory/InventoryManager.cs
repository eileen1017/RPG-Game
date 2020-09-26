using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public PlayerInventory _pInventory;
    public PlayerInfoObjects playerInfo;
    [SerializeField] private GameObject blankItemSlot;
    [SerializeField] private GameObject contentScroll;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;

    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerDamage;
    [SerializeField] private TextMeshProUGUI moneyAmount;
    [SerializeField] private Image playerImage;

    public InventoryItems currentItem;


    public void SetTextBtn(string itemDescription, bool btnActive)
    {
        descriptionText.text = itemDescription;

        if (btnActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeItemSlots()
    {
        if (_pInventory)
        {
            for (int i = 0; i < _pInventory._myInventory.Count; i++)
            {
                if (_pInventory._myInventory[i].numberHad > 0 )
                {
                    GameObject itemTemp = Instantiate(blankItemSlot, contentScroll.transform.position, Quaternion.identity);
                    itemTemp.transform.SetParent(contentScroll.transform);
                    ItemSlot newSlot = itemTemp.GetComponent<ItemSlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(_pInventory._myInventory[i], this);
                    }
                }
            }
        }
    }

    public void preparePlayer()
    {
        playerNameText.text = playerInfo.playerName;
        playerImage.sprite = playerInfo.playerSprite;
        playerDamage.text = "" + playerInfo.damage;
        moneyAmount.text = "" + playerInfo.amountMoney;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        ClearItemSlots();
        preparePlayer();
        MakeItemSlots();
        SetTextBtn("", false);
       

    }

    void ClearItemSlots()
    {
        for (int i = 0; i < contentScroll.transform.childCount; i++)
        {
            Destroy(contentScroll.transform.GetChild(i).gameObject);
        }
    }

    public void SetupDescriptionBtn(string newItemDescription, InventoryItems newItem)
    {
        currentItem = newItem;
        descriptionText.text = newItemDescription;
        useButton.SetActive(true);

    }
    
    void RemoveFromPI()
    {
        for (int i = 0; i < _pInventory._myInventory.Count; i++)
        {
            if (_pInventory._myInventory[i].itemName == currentItem.itemName)
            {
                _pInventory._myInventory.Remove(currentItem);
            }
        }
    }

    public void itemUsed()
    {
        if (currentItem)
        {
            currentItem.Use();
            ClearItemSlots();
            MakeItemSlots();
            if (currentItem.numberHad == 0)
            {
                SetTextBtn("", false);
                RemoveFromPI();

            }
        }
    }
}
