using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Writes Ranking on screen
/// </summary>
public class rankingText : MonoBehaviour {

    Ranking ranking;

	// Use this for initialization
	void Start () {
        ranking = RankingManager.LoadRanking();
        writeRanking();

    }

    public void ResetRanking()
    {
        ranking = RankingManager.LoadRanking();
        writeRanking();
    }

    void writeRanking()
    {
        int length = ranking.names.Length;
        GetComponent<UnityEngine.UI.Text>().text = "";

        for (int i=0; i<length; i++)
        {
            GetComponent<UnityEngine.UI.Text>().text += (i + 1) + ". " + ranking.names[i] + ": " + ranking.scores[i]+"\n";
        }
    }
}
