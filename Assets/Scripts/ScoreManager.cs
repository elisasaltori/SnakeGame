using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Controls the game score, updating the text on screen
/// </summary>
public class ScoreManager : MonoBehaviour
{

    private static int score = 0;
    private TextMesh scoreText;
    private static bool changed = false;

    public static int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    private void Awake()
    {
        changed = true;
        score = 0;
    }

    void Start()
    {
        scoreText = this.GetComponent<TextMesh>();
        scoreText.text = "Pontos: 0";
    }

    void Update()
    {
        if (changed)
        {
            scoreText.text = "Pontos: " + ScoreManager.Score; //updates text
            changed = false;
        }

    }

    //Increase score by the given points
    static public void IncreaseScore(int points)
    {
        Score += points;
        changed = true;
    }

    //Resets score to 0
    static public void ResetScore()
    {
        Score = 0;
        changed = true;
    }

  
}
