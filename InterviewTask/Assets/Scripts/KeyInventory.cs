using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory {
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

    private List<Key> _keysList;
    private int _inventorySize;

    public KeyInventory(UI_Inventory uiInventory, int InventorySize)
    {
        _keysList = new List<Key>();
        _inventorySize = InventorySize;
        uiInventory.SetInventory(this);
        onInventoryChangedCallback?.Invoke();
    }

    public void AddKey(Key key)
    {
        _keysList.Add(key);

        onInventoryChangedCallback?.Invoke();
    }

    public void RemoveKey(Key key)
    {
        _keysList.Remove(key);

        onInventoryChangedCallback?.Invoke();
    }

    public List<Key> GetKeyList()
    {
        return _keysList;
    }

    public bool IsFull()
    {
        if (_keysList.Count < _inventorySize)
            return false;
        else
            return true;

    }
}
