using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingContinueButton : MonoBehaviour {

    private Button btn;
    public InputField input;

    // Use this for initialization
    void Start () {
        btn = this.GetComponent<Button>(); //gets music button
        btn.onClick.AddListener(saveRanking);
    }
	
	void saveRanking()
    {
        string name = input.text;
        RankingManager.UpdateRanking(name);
    }
}
