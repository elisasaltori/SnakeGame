using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the snake (the player)
/// </summary>
public class Snake : MonoBehaviour {

    //Initial speed factor
    public float speed = 1;
    
    // Tail Prefab
    public GameObject tailPrefab;

    //Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    //Food values
    public int basicFoodPoints;
    public int greenFoodPoints;
    public int goldFoodPoints;

    public GameObject gameManager;

    //Direction to which the snake is moving
    Vector2 dir = Vector2.zero;
    List<Transform> tail = new List<Transform>();
    bool ate = false; //has food been eaten?
    private float period = 0.0f;
    private SpawnFood foodScript;
    private bool paused = false;
    private Vector2 savedDir = Vector2.right;
    private float baseSpeed = 0.15F;
    private AudioSource eatSound;
    private int width; //snake width
    private double waitAfterPause;

 
    void Start () {
        //component that plays a sound effect when food is eaten
        eatSound = GetComponent<AudioSource>(); 

        //snake width
        width = (int)GetComponent<BoxCollider2D>().size.x;
        waitAfterPause = baseSpeed;
        foodScript = gameManager.GetComponent<SpawnFood>();
    }
	

	void Update () {

        //Player input

        //Pauses or unpauses game
        if (Input.GetKeyDown(KeyCode.Space))
        {

            PauseGame();
        }
        else
        {
            if (!paused) //if the game is unpaused
            {
                /*waitAfterPause is a delay timer.
                 * 
                 * waitAfterPause makes sure that the player has to wait a bit
                after unpausing, so that they can't use the pause option to 
                control the snake with unfair precision
                */
                if (waitAfterPause <= 0) //delay done
                {
                    MoveInput(); //gets player input for movement
                   
                }
                else //delay ongoing
                {
                    //decreases time left for delay
                    waitAfterPause -= UnityEngine.Time.deltaTime; 
                }

                //Moves snake in the current direction
                if (period > baseSpeed / speed)
                {
                    Move();
                    period = 0;
                }
                period += UnityEngine.Time.deltaTime;

            }
        }

       

      

    }

    //Pauses or unpauses game
    void PauseGame()
    {
        if (paused)
        {
            //TO DO UNPAUSE GAME
            dir = savedDir;
            paused = false;
        }
        else
        {
            //TO DO PAUSE GAME
            savedDir = dir;
            dir = Vector2.zero;
            paused = true;
            waitAfterPause = baseSpeed / speed;
        }
    }

    //Gets player input for movement and changes snake's movement direction
    //Accepts both arrow keys and AWSD for movement
    void MoveInput()
    {
        //All dir vectors are multiplies by the snake width to make sure the snake stays on grid
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (dir != width*Vector2.left)
                dir = width * Vector2.right;
        }
        else
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (dir != width * Vector2.up)
                    dir = -width * Vector2.up;    // '-up' means 'down'
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    if (dir != width * Vector2.right)
                        dir = -width * Vector2.right; // '-right' means 'left'
                }
                else
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                    {
                        if (dir != width * Vector2.down)
                            dir = width * Vector2.up;
                    }



                }
            }
        }
    }

    //Moves the snake on screen
    void Move()
    {

        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction 
        transform.Translate(dir);

        // Ate something? Then insert new Element into gap
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab,
                                                  v,
                                                  Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
            if (speed <= 10)
                speed += 0.05F; 
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    //Snake collided with something
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("FoodPrefab"))
        {
            // Get longer in next Move call
            ate = true;

            int points = 1;
            if(coll.name.Equals("FoodPrefabBlue"))
            {
                points = basicFoodPoints;
           
            }
            else
            {
                if(coll.name.StartsWith("FoodPrefabGreen"))
                {
                    points = greenFoodPoints;
     
                }
                else
                {
                    if(coll.name.StartsWith("FoodPrefabGold"))
                    {
                        points = goldFoodPoints;
                    }
                    else
                    {
                        if (coll.name.StartsWith("FoodPrefabRainbow"))
                        {
                            points = basicFoodPoints;
                            //begin food extravaganza
                            foodScript.BeginExtravaganza();
                            

                        }
                    
                    }
                }
            }
            ScoreManager.IncreaseScore(points); //increases score
            // Remove the Food
            Destroy(coll.gameObject);

            SpawnFood.foodOnScreen = false;
            eatSound.Play(); //plays "eating" sound



        }
        // Collided with Tail or Border
        else
        {
            //Collided with border
            //makes snake appear on opposite side of the screen 
            if (coll.CompareTag("Border"))
            {

                var pos = transform.position;

                if (dir == width * Vector2.up)
                {
                    pos.y = borderBottom.position.y + width;
                    transform.position = pos;
                }
                else
                {
                    if (dir == width * Vector2.down)
                    {
                        pos.y = borderTop.position.y - width;
                        transform.position = pos;
                    }
                    else
                    {
                        if (dir == width * Vector2.left)
                        {
                            pos.x = borderRight.position.x - width;
                            transform.position = pos;
                        }
                        else
                        {
                            pos.x = borderLeft.position.x + width;
                            transform.position = pos;
                        }

                    }
                }

            }
            else
            {
                GameOptions.finalScore = ScoreManager.Score;
                SceneManager.LoadScene("deathScreen");
            }

        }
    }


}
