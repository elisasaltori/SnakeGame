using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Controls the spawning of food on screen
/// </summary>
public class SpawnFood : MonoBehaviour {

    //food prefab
    public GameObject foodPrefab;

    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public static bool foodOnScreen = false; //is there food already on screen?
    private int width; //image width for the food

  
    void Start () {

        //gets food width
        //+1 because collider is kept at .9 so snake doesn't collect it from adjacent squares
        width = (int)foodPrefab.GetComponent<BoxCollider2D>().size.x + 1;

    }

    //Spawns one bit of food
    void Update () {

        //Only spawns food if no food is already on screen
        if (!foodOnScreen)
        {
            //generates position randomly in the space delimited by the borders

            //x
            int x = (int)Random.Range(borderLeft.position.x + 2, borderRight.position.x - 2);
            x = x - x % width; //making sure it stays on the grid

            //y
            int y = (int)Random.Range(borderBottom.position.y+2, borderTop.position.y-2);
            y = y - y % width; //making sure it stays on the grid

            //new food object on screen
            Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
            foodOnScreen = true;
        }
    }
}
