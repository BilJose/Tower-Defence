using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    public GameObject gameOverUI;

    public static bool gameIsOver;

    void Stats()
    {
        gameIsOver = false;
    }
    
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }
       
        if(PlayerStats.Lives<= 0)
        {

            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);

    }
}
