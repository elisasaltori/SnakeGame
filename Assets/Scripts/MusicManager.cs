using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Controls the main music, turning it off and on.
/// </summary>
public class MusicManager : MonoBehaviour {

    private AudioSource musicPlayer;
    private bool musicOn = true;


	void Start () {
        musicPlayer = this.GetComponent<AudioSource>();
		
	}
	
    //Switches music on and off
	public void SwitchMusic()
    {
        if (musicOn)
        {
            musicPlayer.Pause();
            musicOn = false;
        }
        else
        {
            musicPlayer.UnPause();
            musicOn = true;
        }
         
    }
}
