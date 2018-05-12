using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls audio player responsible for the timer sound during the Food Extravaganza
/// </summary>
public class ExtravaganzaTimer : MonoBehaviour {

    private AudioSource soundPlayer;
    private int currentAudio=0;
    private SpawnFood foodScript;
    private double extravaganzaDuration;
    private bool extravaganza = false;


    void Start()
    {
        //Mutes sound according to sound preference
        soundPlayer = this.GetComponent<AudioSource>();
        if (!GameOptions.soundOn)
        {
            SwitchSound();
        }

        //gets script that controls food
        foodScript = this.GetComponent<SpawnFood>();
        extravaganzaDuration = foodScript.extravaganzaDuration;
    }

    void Update()
    {
        //if extravaganza is going on
        if (foodScript.extravaganza)
        {
            //extravaganza just started
            //sets local extravaganza variable to true and starts music
            if(extravaganza == false)
            {
                extravaganza = true;
                StarTimerSound();
            }
            else //music is already playing
            {
                soundPlayer.pitch = (float)(extravaganzaDuration+1) / (float)(foodScript.extravaganzaTimer+1);
                if (foodScript.extravaganzaTimer <= 0.5*extravaganzaDuration && currentAudio==0)
                {
                    SpeedUp();
                    

                }
                else
                {
                    if(foodScript.extravaganzaTimer <= 0.2 * extravaganzaDuration && currentAudio == 1)
                    {
                        SpeedUp();
                      
                    }
                    
                }
            }

        }
        else
        {
            if (extravaganza)
            {
                StopTimerSound();
            }
        }
    }

    //Switches sound on and off
    public void SwitchSound()
    {
        soundPlayer.mute = !soundPlayer.mute;
    }

    public void SpeedUp()
    {
        currentAudio = (currentAudio + 1) % 3;
 
        
    }

    public void StarTimerSound()
    {
        currentAudio = 0;
        soundPlayer.Play();
    }

    public void StopTimerSound()
    {
        soundPlayer.Stop();
        extravaganza = false;
    }
}
