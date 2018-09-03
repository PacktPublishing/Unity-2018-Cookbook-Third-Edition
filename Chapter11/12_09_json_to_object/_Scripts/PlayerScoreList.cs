using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerScoreList
{
    public List<PlayerScore> list = new List<PlayerScore>();

    public static PlayerScoreList FromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerScoreList>(jsonString);
    }
}