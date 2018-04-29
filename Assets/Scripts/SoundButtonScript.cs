using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Button that allows player to switch sound on and off
/// </summary>
public class SoundButtonScript : MonoBehaviour {

    private SoundManager soundManager;
    public Sprite OffSprite;
    public Sprite OnSprite;
    private Button btn;


    // Use this for initialization
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(SwitchSound);
        GameObject head = GameObject.Find("Head");
        if(head != null)
        {
            soundManager = head.GetComponent<SoundManager>();
        }

        if (!GameOptions.soundOn)
        {
            ChangeImage();
        }

    }

    void SwitchSound()
    {
        if(soundManager!= null)
        {
            soundManager.SwitchSound();
        }
        else
        {
            GameOptions.soundOn = !GameOptions.soundOn;
        }
        
        ChangeImage();

    }

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
