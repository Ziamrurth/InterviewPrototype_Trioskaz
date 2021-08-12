using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour {
    [SerializeField] private GameObject _uiGameEnd;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.onGameFinishedCallback += EndGame;
    }

    public void LoadMainScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ChangeControllerMode();
        _uiGameEnd.SetActive(true);
    }
}
