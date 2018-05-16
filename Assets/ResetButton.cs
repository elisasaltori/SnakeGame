using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for reset ranking button
/// Asks for confirmation before erasing ranking
/// </summary>
public class ResetButton : MonoBehaviour {

    bool clickedOnce = false;
    Button btn;

    public GameObject rankingTextContainer;
    public GameObject buttonText;


	// Use this for initialization
	void Start () {
        btn = this.GetComponent<Button>(); //gets mcontinue button

        btn.onClick.AddListener(ResetRankingButton);
    }
	
	void ResetRankingButton()
    {
        //first click
        //asks for confirmation
        if (!clickedOnce) 
        {
            buttonText.GetComponent<UnityEngine.UI.Text>().text = "Certeza?";
            clickedOnce = true;
        }
        else //second click -> erases ranking
        {
            buttonText.GetComponent<UnityEngine.UI.Text>().text = "Resetar";
            RankingManager.ResetRanking();
            rankingTextContainer.GetComponent<rankingText>().ResetRanking();
            clickedOnce = false;
           
        }

    }
}
