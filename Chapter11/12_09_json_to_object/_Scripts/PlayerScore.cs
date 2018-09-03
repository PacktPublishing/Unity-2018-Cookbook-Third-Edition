using UnityEngine;

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;

    public static PlayerScore FromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerScore>(jsonString);
    }
}