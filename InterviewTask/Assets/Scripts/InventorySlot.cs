using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image icon;
    public Button removeButton;

    private Key _key;
    
    public void AddKey(Key key)
    {
        _key = key;
        icon.sprite = _key.GetKeyPreset().sprite;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        _key = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        KeyInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetInventory();

        CreateKeyWorld();
        inventory.RemoveKey(_key);
    }

    private void CreateKeyWorld()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject key = new GameObject("Key");
        key.transform.position = player.position;
        key.transform.rotation = player.rotation;
        key.AddComponent<KeyWorld>();
        key.GetComponent<KeyWorld>().SetKeyPreset(_key.GetKeyPreset());
    }

}
