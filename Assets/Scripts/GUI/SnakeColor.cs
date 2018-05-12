using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lets the user choose the color of the snake in the main menu
/// </summary>
public class SnakeColor : MonoBehaviour {

    public Sprite[] snakeColors;
    public GameObject[] snake;
	private int currentPos = 0;

    void Start()
    {
        currentPos = GameOptions.snakeColor;

        ColorSnake();

    }

    //function for right button when choosing the color of the snake
    public void ClickRight()
    {
        currentPos = (currentPos + 1) % snakeColors.Length;

        GameOptions.snakeColor = currentPos;

        ColorSnake();
    }

    //function for left button when choosing the color of the snake
    public void ClickLeft()
    {
        currentPos = (currentPos - 1) % snakeColors.Length;
        if (currentPos < 0)
            currentPos = snakeColors.Length + currentPos;

        GameOptions.snakeColor = currentPos;

        ColorSnake();
    }

    //changes color of snake on main menu
    private void ColorSnake()
    {
        Image aux;

        for (int i = 0; i < snake.Length; i++)
        {
            aux = snake[i].GetComponent<Image>();
            aux.sprite = snakeColors[currentPos];
        }
    }
}
