using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the sound effects for the game.
/// </summary>
public class SoundManager : MonoBehaviour {

    private AudioSource soundPlayer;


    void Start()
    {
        soundPlayer = this.GetComponent<AudioSource>();
        if (!GameOptions.soundOn)
        {
            SwitchSound();
        }

    }
 
    //Switches sound on and off
    public void SwitchSound()
    {
        soundPlayer.mute = !soundPlayer.mute;
    }
}
