using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Button that allows player to switch sound on and off
/// </summary>
public class SoundButtonScript : MonoBehaviour {

    private SoundManager soundManager;
    private ExtravaganzaTimer soundManagerTimer;
    public Sprite OffSprite;
    public Sprite OnSprite;
    private Button btn;


    // Use this for initialization
    void Start()
    {
        //initializes button
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(SwitchSound);

        //gets audio source from snake (bips when eating)
        GameObject head = GameObject.Find("Head");
        if(head != null)
        {
            soundManager = head.GetComponent<SoundManager>();
        }

        //gets audio source from GameManager(Extravaganza timer)
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            soundManagerTimer = gameManager.GetComponent<ExtravaganzaTimer>();
        }

        if (!GameOptions.soundOn)
        {
            ChangeImage();
        }

    }

    //Switches sound on and off
    void SwitchSound()
    {
        if(soundManager!= null)
        {
            soundManager.SwitchSound();
            soundManagerTimer.SwitchSound();
        }
      
        GameOptions.soundOn = !GameOptions.soundOn;
        
        
        ChangeImage();

    }

    //Changes between on and off button img
    public void ChangeImage()
    {
        if (btn.image.sprite == OnSprite)
            btn.image.sprite = OffSprite;
        else
        {
            btn.image.sprite = OnSprite;
        }
    }

}
