using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls border option gui on main menu
/// </summary>
public class BorderOption : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameOptions.bordersKill)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Bordas Fatais";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Teletransporte";
        }
    }

    public void SwitchBorders()
    {
        //switch from false to true or vice versa
        bool bordersKill = !GameOptions.bordersKill;
        GameOptions.bordersKill = bordersKill;

        //update text on main menu
        if (bordersKill)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Bordas Fatais";
        }
        else
        {
           this.GetComponent<UnityEngine.UI.Text>().text = "Teletransporte";
        }

    }
}
