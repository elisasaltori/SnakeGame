using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScoreScript : MonoBehaviour {


    // Use this for initialization
    void Start () {
        this.GetComponent<UnityEngine.UI.Text>().text = "Pontos: " + GameOptions.finalScore;
    }
	
}
