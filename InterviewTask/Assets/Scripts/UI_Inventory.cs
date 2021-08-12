using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour {
    private KeyInventory _inventory;
    private Transform _inventorySlotContainer;
    private InventorySlot[] _inventorySlots;

    public void SetInventory(KeyInventory inventory)
    {
        _inventory = inventory;
        _inventory.onInventoryChangedCallback += UpdateInventory;

        _inventorySlotContainer = transform.Find("InventorySlotContainer");
        _inventorySlots = _inventorySlotContainer.GetComponentsInChildren<InventorySlot>();
    }

    private void UpdateInventory()
    {
        for (int slotInex = 0; slotInex < _inventorySlots.Length; slotInex++)
        {
            if(slotInex < _inventory.GetKeyList().Count)
            {
                _inventorySlots[slotInex].AddKey(_inventory.GetKeyList()[slotInex]);
            }
            else
            {
                _inventorySlots[slotInex].ClearSlot();
            }
        }
    }
}
