using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKey", menuName = "SciptableObjects/Key")]
public class KeyPreset : ScriptableObject {
    public string keyName;
    public Key.KeyType type;
    public Sprite sprite;
    public Material material;
    public GameObject prefab;
}
