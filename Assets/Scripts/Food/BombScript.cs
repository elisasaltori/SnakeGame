using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bomb behavior
/// Explodes after a few seconds
/// </summary>
public class BombScript : MonoBehaviour
{
    double bombDuration = 15; //how many seconds a bomb lasts
    public double timeLeft;
    Animator animator;

    void Start()
    {
        timeLeft = bombDuration;
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        timeLeft -= UnityEngine.Time.deltaTime;
        
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if (timeLeft <= 3)
            {
                animator.speed = 2.5f;
            }
            else
            {
                if (timeLeft <= 7)
                {
                    animator.speed = 1.5f;
                }
            }
        }
       
        
    }

    //Avoids bomb being in the same square as food
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("FoodPrefab"))
        {
            Destroy(this);
        }
    }
}
