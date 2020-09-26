using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInventoryItems : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private InventoryItems _inventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddItemToPI();
            Destroy(this.gameObject);
            SoundManager.instance.InventoryUptake(); 
        }
    }

    void AddItemToPI()
    {
        if (_playerInventory && _inventoryItems)
        {
            if (_playerInventory._myInventory.Contains(_inventoryItems))
            {
                _inventoryItems.numberHad++;
            }
            else
            {
                _playerInventory._myInventory.Add(_inventoryItems);
                _inventoryItems.numberHad++;
            }
        }
    }
}
