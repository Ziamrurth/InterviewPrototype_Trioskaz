using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public delegate void OnGameFinished();
    public OnGameFinished onGameFinishedCallback;

    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Gamemanager found!");
            return;
        }
        instance = this;
    }
    #endregion

    private GameObject[] _doorsList;
    private int _doorsToOpen;

    void Start()
    {
        _doorsList = GameObject.FindGameObjectsWithTag("Door");
        _doorsToOpen = _doorsList.Length;
        foreach (var door in _doorsList)
        {
            door.GetComponent<Door>().onDoorOpenCallback += DoorsCheck;
        }
    }

    private void DoorsCheck()
    {
        _doorsToOpen--;
        if(_doorsToOpen == 0)
        {
            onGameFinishedCallback?.Invoke();
        }
    }
}
