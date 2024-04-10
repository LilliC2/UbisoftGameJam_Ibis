using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Singleton<MainMenu>
{

    public GameObject mainMenuCanvas;
    public Sprite player1;
    public Sprite player2;
    public Sprite player3;
    public Sprite player4;
    
    // Start is called before the first frame update
    void Start()
    {
        mainMenuCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //checked if player is connected, change icon
    }

    public void PlayGame()
    {
        //change game state to play here
    }

    public void OnQuitGame()
    {
        _GM.QuitGame();
    }
}
