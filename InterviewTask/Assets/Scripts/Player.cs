using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int _inventorySize;
    [SerializeField] private UI_Inventory _uiInventory;
    private KeyInventory _inventory;

    void Start()
    {
        _inventory = new KeyInventory(_uiInventory, _inventorySize);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            PickupKey();
        }
    }

    public KeyInventory GetInventory()
    {
        return _inventory;
    }

    private void PickupKey()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.tag.Equals("Key"))
            {
                if (!_inventory.IsFull())
                {
                    Key key = objectHit.parent.GetComponent<KeyWorld>().PickupKey();
                    _inventory.AddKey(key);
                }
            }
        }
    }
}
