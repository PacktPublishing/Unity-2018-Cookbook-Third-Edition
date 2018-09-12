using UnityEngine;

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;

    public string ToJson()
    {
        bool prettyPrintJson = true;
        return JsonUtility.ToJson(this, prettyPrintJson);
    }
}