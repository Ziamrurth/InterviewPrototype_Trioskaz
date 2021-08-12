using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory {
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

    private List<Key> _keysList;
    private int _inventorySize;
    private Key _activeKey;

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
        if (_activeKey == key)
            _activeKey = null;

        _keysList.Remove(key);
        onInventoryChangedCallback?.Invoke();
    }

    public void DeleteKey(Key key)
    {
        if (_activeKey == key)
            _activeKey = null;

        _keysList.Remove(key);
        _activeKey = null;
        onInventoryChangedCallback?.Invoke();
    }

    public void SetActiveKey(Key key)
    {
        _activeKey = key;
    }

    public Key GetActiveKey()
    {
        return _activeKey;
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
