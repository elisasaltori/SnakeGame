using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Function for continue button on death screen.
/// Gets name from input and evokes UpdateRanking from RankingManager
/// </summary>
public class RankingContinueButton : MonoBehaviour {

    private Button btn;
    public InputField input;

    // Use this for initialization
    void Start () {
        btn = this.GetComponent<Button>(); //gets mcontinue button
        btn.onClick.AddListener(SaveRanking);
    }
	
	void SaveRanking()
    {
        string name = input.text;

        //player didnt enter name
        if(name.Length == 0)
        {
            name = "Cobra anônima"; //default name
        }
        RankingManager.UpdateRanking(name);
    }
}
