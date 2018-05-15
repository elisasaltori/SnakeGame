using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls text about the player's position in ranking in the death screen
/// </summary>
public class RankingPositionText : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //gets position in ranking
        int pos = RankingManager.GetPosition(GameOptions.finalScore);
        

        if (pos != -1) //qualified for ranking
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Posição no ranking: "
            + (RankingManager.GetPosition(GameOptions.finalScore) + 1);

           

        }
        else //didnt qualify for ranking
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "Posição no ranking: --";
            GameObject[] inputObjects = GameObject.FindGameObjectsWithTag("RankingInput");
            foreach (GameObject g in inputObjects)
            {
                g.SetActive(false);
            }
        }
        
    }
	
}
