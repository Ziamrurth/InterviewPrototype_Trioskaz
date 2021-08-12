using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key {
    public enum KeyType {
        None,
        Red,
        Green,
        Blue
    }

    private KeyPreset _preset;

    public Key(KeyPreset preset)
    {
        _preset = preset;
    }

    public KeyPreset GetKeyPreset()
    {
        return _preset;
    }
}
