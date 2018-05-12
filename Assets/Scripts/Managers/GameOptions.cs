using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps game parameters between scenes.
/// </summary>
public static class GameOptions {

    public static bool soundOn = true; //is the sound on?
    public static int finalScore = 0; //final score of the game
    public static int rankingPos = -1; //position of the player on ranking
    public static int snakeColor = 0; //color use for snake sprite
    public static bool bordersKill = false; //do borders kill or does the snake go through them?


}
