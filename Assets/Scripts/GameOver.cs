﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text roundsText;
    public SceneFader sceneFader;
    public string menuScene = "MainMenu";
    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        sceneFader.FadeTo(menuScene);
    }
}
