using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public static CanvasScript instance;
    public GameObject gameOverText;
    public GameObject gameOverButton;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
        gameOverButton.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverText.SetActive(false);
        gameOverButton.SetActive(false);
    }
}
