using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Loads, updates and saves ranking
/// </summary>
public static class RankingManager{

    private static string gameDataProjectFilePath = "ranking.json";
    static Ranking ranking;

    //Load ranking from file (if file is missing, default ranking is loaded)
    //returns loaded ranking objected
    public static Ranking LoadRanking()
    {
        string path = Application.dataPath;
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, gameDataProjectFilePath);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            ranking = JsonUtility.FromJson<Ranking>(dataAsJson);
        }
        else
        {
            //default ranking
            ranking = new Ranking();
            ranking.names = new string[] { "Mamba negra", "Naja", "Sucuri", "Cobra do Milho", "Minhoca" }; ;
            ranking.scores = new int[] { 200, 100, 50, 20, 10 }; ;
        }

        return ranking;
    }

    //Saves current ranking to file
    public static void SaveRanking()
    {
        if (ranking == null)
            LoadRanking();

        string dataAsJson = JsonUtility.ToJson(ranking);

        //create Folder
        if (!Directory.Exists(Application.dataPath))
        {

            Directory.CreateDirectory(Application.dataPath);
        }

        string path = Application.dataPath;
    
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, gameDataProjectFilePath);
        File.WriteAllText(filePath, dataAsJson);
    }

    //Updates ranking using finalScore and the name given
    public static void UpdateRanking(string name)
    {
        int newScore = GameOptions.finalScore;

        int pos = GetPosition(newScore);
        int length = ranking.names.Length;

        if (pos != -1)
        {
            for(int i = length-1; i>pos ; i++)
            {
                ranking.scores[i] = ranking.scores[i - 1];
                ranking.names[i] = ranking.names[i - 1];
            }

            ranking.scores[pos] = newScore;
            ranking.names[pos] = name;
            SaveRanking();

        }

        GameOptions.rankingPos = pos;
    }

    //Finds where the score given would be placed in the ranking
    //Ranking isn't updated
    public static int GetPosition(int score)
    {
        int pos = -1;

        if (ranking == null)
            LoadRanking();

        int length = ranking.names.Length;

        for (int i = 0; i < length; i++)
        {
            if (ranking.scores[i] < score)
            {
                pos = i;
                break;
            }
        }

        return pos;
    }
}
