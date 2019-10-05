using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CurrentLevel;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void GameOver()
    {
        CanvasScript.instance.gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        CurrentLevel++;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void RestartLevel()
    {
        CanvasScript.instance.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}