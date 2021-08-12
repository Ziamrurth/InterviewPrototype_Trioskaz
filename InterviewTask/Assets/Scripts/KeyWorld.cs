using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyWorld : MonoBehaviour {
    [SerializeField] private KeyPreset _keyPreset;

    private Key _key;

    void Start()
    {
        if(_keyPreset != null)
        {
            _key = new Key(_keyPreset);

            SetMaterial();
            Instantiate(_keyPreset.prefab, transform);
        }
    }

    public void SetKeyPreset(KeyPreset keyPreset)
    {
        _keyPreset = keyPreset;
        _key = new Key(_keyPreset);

        SetMaterial();
        Instantiate(_keyPreset.prefab, transform);
    }

    public Key PickupKey()
    {
        Destroy(gameObject);
        return _key;
    }

    private void SetMaterial()
    {
        foreach (Transform item in _keyPreset.prefab.transform)
        {
            item.gameObject.GetComponent<Renderer>().material = _keyPreset.material;
        }
    }
}
