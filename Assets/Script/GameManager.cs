using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : GenericSingle<GameManager>
{
    public GameObject endCanvas;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win(string winText)
    {
        endCanvas.SetActive(true);
        text.text = winText;
    }
    public void Failure(string failText)
    {
        endCanvas.SetActive(true);
        text.text = failText;
    }
    public void RenewsGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnMainMunes()
    {
        SceneManager.LoadScene(0);
    }
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OnExitGame()
    {
        Application.Quit();
    }
}
