using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private int _inventorySize;
    [SerializeField] private float _interactDistance;
    [SerializeField] private UI_Inventory _uiInventory;
    private KeyInventory _inventory;

    void Start()
    {
        _inventory = new KeyInventory(_uiInventory, _inventorySize);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    public KeyInventory GetInventory()
    {
        return _inventory;
    }

    private void InteractWithObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (Vector3.Distance(transform.position, objectHit.position) < _interactDistance)
            {
                if (objectHit.tag.Equals("Key"))
                {
                    if (!_inventory.IsFull())
                    {
                        Key key = objectHit.parent.GetComponent<KeyWorld>().PickupKey();
                        _inventory.AddKey(key);
                    }
                }

                if (objectHit.tag.Equals("Door"))
                {
                    if (_inventory.GetActiveKey() != null)
                    {
                        if (objectHit.GetComponent<Door>().TryToOpen(_inventory.GetActiveKey()))
                            _inventory.DeleteKey(_inventory.GetActiveKey());
                    }
                }
            }
        }
    }
}
