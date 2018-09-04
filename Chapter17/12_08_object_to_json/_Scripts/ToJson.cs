using UnityEngine;

public class ToJson : MonoBehaviour 
{
    private PlayerScore playerScore1 = new PlayerScore();
    private PlayerScore playerScore2 = new PlayerScore();
    private PlayerScoreList playerScoreList = new PlayerScoreList();

    private void Awake()
    {
        playerScore1.name = "matt";
        playerScore1.score = 800;

        playerScore2.name = "joelle";
        playerScore2.score = 901;

        playerScoreList.list.Add(playerScore1);
        playerScoreList.list.Add(playerScore2);
    }

    void Start()
    {
        ObjectToJson();
        CollectionToJson();
    }

    public void ObjectToJson()
    {
        string objectAsString = playerScore1.ToJson();
        print("1: Object to JSON \n" + objectAsString);
    }

    public void CollectionToJson()
    {
        string objectListAsString = playerScoreList.ToJson();
        print("2: List of objects to JSON \n" + objectListAsString);
    }
}