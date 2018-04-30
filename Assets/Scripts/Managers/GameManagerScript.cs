using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pauses and unpauses game
/// </summary>
public class GameManagerScript : MonoBehaviour {

    GameObject[] pauseObjects;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        //finds objects that are only shown when the game is paused
        pauseObjects = GameObject.FindGameObjectsWithTag("OnPauseOnly");
        hidePaused();
    }
	
	// Update is called once per frame
	void Update () {
        //uses the space bar to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    //shows objects with OnPauseOnly tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with OnPauseOnly tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}
