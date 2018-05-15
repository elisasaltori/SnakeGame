using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Contains functions for loading scenes for use in buttons
/// </summary>
public class MenuManagerScript : MonoBehaviour {

    public void loadGame()
    {
        SceneManager.LoadScene("mainGame");
    }

    public void loadRanking()
    {
        SceneManager.LoadScene("RankingScreen");
    }

    public void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void loadInstructions()
    {
        SceneManager.LoadScene("instructions");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
  

}
