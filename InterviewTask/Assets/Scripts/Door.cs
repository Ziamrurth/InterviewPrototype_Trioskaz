using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    [SerializeField] private Key.KeyType _keyType;
    [SerializeField] private Material _openedMaterial;
    [SerializeField] private Material _wrongKeyMaterial;
    private Material _defaultMaterial;
    private Transform _door;
    private float _wrongKeyMaterialTime = 0.5f;
    private bool _doorOpen;

    private void Start()
    {
        _door = transform.Find("Door");
        _defaultMaterial = _door.GetComponent<MeshRenderer>().material;
        _doorOpen = false;
    }

    public bool TryToOpen(Key key)
    {
        if (!_doorOpen)
        {
            if (key.GetKeyPreset().type == _keyType)
                OpenDoor();
            else StartCoroutine(WrongKey());

            return _doorOpen;
        }
        else return false;
    }

    private void OpenDoor()
    {
        _door.GetComponent<MeshRenderer>().material = _openedMaterial;
        _doorOpen = true;
    }

    private IEnumerator WrongKey()
    {
        _door.GetComponent<MeshRenderer>().material = _wrongKeyMaterial;

        yield return new WaitForSeconds(_wrongKeyMaterialTime);

        if (!_doorOpen)
            _door.GetComponent<MeshRenderer>().material = _defaultMaterial;
    }
}
