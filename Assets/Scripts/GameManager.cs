using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CurrentLevel;

    public GameObject Player;
    public static GameManager instance;

    public bool isGameOver;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void GameOver()
    {
        isGameOver = true;

        DisablePlayer();

        CanvasScript.instance.ShowGameOver();
    }

    private void DisablePlayer()
    {
    }

    public void NextLevel()
    {
        CurrentLevel++;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void RestartLevel()
    {
        isGameOver = false;

        CanvasScript.instance.HideGameOver();
        SceneManager.LoadScene(0);
    }
}