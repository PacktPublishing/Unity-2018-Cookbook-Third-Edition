using UnityEngine;
public class XmlReader : MonoBehaviour 
{
    public TextAsset dataAsXmlString;

    private void Start()
    {
        PlayerScoreCollection objectCollection = PlayerScoreCollection.LoadFromString(dataAsXmlString.text);

        foreach(PlayerScore playerScore in objectCollection.playerScores){
            print("name = " + playerScore.name + ", score = " + playerScore.score + ", version = " + playerScore.version); 
        }
    }

}