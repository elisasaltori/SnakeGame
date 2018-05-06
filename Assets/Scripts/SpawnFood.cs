using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Controls the spawning of food on screen
/// </summary>
public class SpawnFood : MonoBehaviour {

    //food prefabs
    public GameObject foodPrefab;
    public GameObject foodPrefabGreen;
    public GameObject foodPrefabGold;
    public GameObject foodPrefabRainbow;

    //bomb prefab
    public GameObject bombPrefab;

    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    //the sum of FoodChances must be between 0 and 1
    public double greenFoodChance;
    public double goldFoodChance;
    public double rainbowFoodChance;

    //bomb chance is unrelated to FoodChances
    public double bombChance;

    public double extravaganzaDuration;
    public double speedUpTime;
    public static bool foodOnScreen = false; //is there food already on screen?

    private int width; //image width for the food
    private bool extravaganza = false;
    private int extravaganzaCount = 0;
    private double extravaganzaTimer;
    private GameObject[] extravaganzaFruit;

    private void Awake()
    {
        foodOnScreen = false;
    }

    void Start () {

        //gets food width
        //+1 because collider is kept at .9 so snake doesn't collect it from adjacent squares
        width = (int)foodPrefab.GetComponent<BoxCollider2D>().size.x + 1;

    }

    //Spawns one bit of food
    void Update () {

        if (extravaganza)
        {

            
           

            //if timer has run out or all food has been eaten
            if (extravaganzaTimer <= 0 || extravaganzaCount == 0) 
            {
                //extravaganza is done
                extravaganza = false;

                //delete all food on screen
                //GameObject[] food = GameObject.FindGameObjectsWithTag("Food");
                int n = extravaganzaFruit.Length;
                for(int i=0; i<n; i++)
                {
                    Destroy(extravaganzaFruit[i]);
                }


            }
            else //extravanza isnt done
            {
                //reduce timer
                extravaganzaTimer -= UnityEngine.Time.deltaTime;

                //if timer is running out
                if (extravaganzaTimer <= speedUpTime)
                {
                    //speed up song
                    //TODO!!!
                }



            }
        }
        //no extravaganza
        else //spawns food regularly
        {
            //Only spawns food if no food is already on screen
            if (!foodOnScreen)
            {

                InstantiateFood();

                //has the chance of instantiating a bomb alongside the food
                InstantiateBomb();

                foodOnScreen = true;
            }
        }

       
    }

    //Begins Food Extravaganza event
    //lots of food is instatiated in the screen for a limited ammount of time
    public void BeginExtravaganza()
    {
        //food extravaganza is on
        extravaganza = true;

        //random number of fruits on screen
        extravaganzaCount = (int)Random.Range(5, 15);

        extravaganzaFruit = new GameObject[extravaganzaCount];

        //spawns food on screen and saves their references for destroying them later
        for (int i = extravaganzaCount-1; i>=0; i--)
        {
            extravaganzaFruit[i] = InstantiateFood();
        }

        //initiates timer
        extravaganzaTimer = extravaganzaDuration;
    
        //music
        //TODO!!!!!

    }

    //Instantiates a piece of food on screen
    GameObject InstantiateFood()
    {
        int x, y;

        //generates position randomly in the space delimited by the borders
        //loop checks if there isn't already another object in the desired position
        do
        {
            //x
            x = (int)Random.Range(borderLeft.position.x + 2, borderRight.position.x - 2);
            x = x - x % width; //making sure it stays on the grid

            //y
            y = (int)Random.Range(borderBottom.position.y + 2, borderTop.position.y - 2);
            y = y - y % width; //making sure it stays on the grid

        } while (Physics2D.OverlapBox(new Vector2(x, y), new Vector2(3, 3), 0));

        //new food object on screen
        double chance = Random.Range(0.0f, 1.0f);

        if (chance <= greenFoodChance)
        {
            return Instantiate(foodPrefabGreen, new Vector2(x, y), Quaternion.identity);
        }
        else
        {
            if (chance > greenFoodChance && chance <= (greenFoodChance + goldFoodChance))
            {
                return Instantiate(foodPrefabGold, new Vector2(x, y), Quaternion.identity);
            }
            else
            {
                if (chance > (greenFoodChance + goldFoodChance)
                    && chance < (greenFoodChance + goldFoodChance + rainbowFoodChance)
                    && !extravaganza) 
                {
                    return Instantiate(foodPrefabRainbow, new Vector2(x, y), Quaternion.identity);
                }
                else
                {
                    return Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
                }


            }
        }
    }

    //Has the chance of instantiating a bomb on screen
    GameObject InstantiateBomb()
    {
        double chance = Random.Range(0.0f, 1.0f);
        int x, y;

        if (chance <= bombChance)
        {
            //generates position randomly in the space delimited by the borders
            //loop checks if there isn't already another object in the desired position
            do
            {
                //x
                x = (int)Random.Range(borderLeft.position.x + 2, borderRight.position.x - 2);
                x = x - x % width; //making sure it stays on the grid

                //y
                y = (int)Random.Range(borderBottom.position.y + 2, borderTop.position.y - 2);
                y = y - y % width; //making sure it stays on the grid

            } while (Physics2D.OverlapBox(new Vector2(x, y), new Vector2(3,3) , 0));

            return Instantiate(bombPrefab, new Vector2(x, y), Quaternion.identity);
        }

        return null;

      
    }
}

