using UnityEngine;

public class FromJson : MonoBehaviour 
{
    private void Start()
    {
        JsonToObject();
        JsonToList();
    }

    public void JsonToObject()
    {
        string playerScoreAsString = "{ \"name\":\"matt\", \"score\":201}";
        PlayerScore playerScore = PlayerScore.FromJSON(playerScoreAsString);

        print(playerScore.name + ", " + playerScore.score);
    }

    public void JsonToList()
    {
        string playerScorelistAsString = "";

        playerScorelistAsString += "{";
        playerScorelistAsString += "\"list\": [";
        playerScorelistAsString += "        {";
        playerScorelistAsString += "            \"name\": \"matt\",";
        playerScorelistAsString += "            \"score\": 800";
        playerScorelistAsString += "        },";
        playerScorelistAsString += "        {";
        playerScorelistAsString += "            \"name\": \"joelle\",";
        playerScorelistAsString += "            \"score\": 901";
        playerScorelistAsString += "        }";
        playerScorelistAsString += "    ]";
        playerScorelistAsString += "}";

        PlayerScoreList playerScoreList = PlayerScoreList.FromJSON(playerScorelistAsString);


        foreach (var playerScore in playerScoreList.list) {
            print("from list :: " + playerScore.name + ", " + playerScore.score);
        }
    }

}