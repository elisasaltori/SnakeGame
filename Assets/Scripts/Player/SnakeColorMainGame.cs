using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the color of the snake for the main game
/// </summary>
public class SnakeColorMainGame : MonoBehaviour {

    public GameObject[] tailPrefabs;
    public GameObject snake;
	// Use this for initialization
	void Start () {
        int colorPos = GameOptions.snakeColor;

        //check if colorPos is withing bounds
        if (colorPos < 0 || colorPos > tailPrefabs.Length)
            colorPos = 0;

        snake.GetComponent<Snake>().tailPrefab = tailPrefabs[colorPos];

        snake.GetComponent<SpriteRenderer>().sprite = tailPrefabs[colorPos].GetComponent<SpriteRenderer>().sprite;
	}
	
	
}
