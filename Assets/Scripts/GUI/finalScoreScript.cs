using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shows final score on death screen
/// </summary>
public class finalScoreScript : MonoBehaviour {


    // Use this for initialization
    void Start () {
        this.GetComponent<UnityEngine.UI.Text>().text = "Pontos: " + GameOptions.finalScore;
    }
	
}
