using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PlayerScoreList
{
    public List<PlayerScore> list = new List<PlayerScore>();

    public string ToJson()
    {
        bool prettyPrint = true;
        return JsonUtility.ToJson(this, prettyPrint);
    }
}