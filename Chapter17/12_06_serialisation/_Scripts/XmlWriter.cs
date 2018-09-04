using UnityEngine;
using System.IO;

// adapted from:
// http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer
public class XmlWriter : MonoBehaviour 
{
    public string fileName = "playerData.xml";
    public string folderName = "Data";

    private void Start()
    {
        string filePath = Path.Combine(Application.dataPath, folderName);
        filePath = Path.Combine(filePath, fileName);

        PlayerScoreCollection psc = CreatePlayScoreCollection();
        psc.Save(filePath);
        print("XML file should now have been created at: " + filePath);
    }

    private PlayerScoreCollection CreatePlayScoreCollection()
    {
        PlayerScoreCollection playerScoreCollection = new PlayerScoreCollection();

        // make 2 slot array
        playerScoreCollection.playerScores = new PlayerScore[2];

        playerScoreCollection.playerScores[0] = new PlayerScore();
        playerScoreCollection.playerScores[0].name = "matt";
        playerScoreCollection.playerScores[0].score = 22;
        playerScoreCollection.playerScores[0].version = "v0.5";

        playerScoreCollection.playerScores[1] = new PlayerScore();
        playerScoreCollection.playerScores[1].name = "joelle";
        playerScoreCollection.playerScores[1].score = 5;
        playerScoreCollection.playerScores[1].version = "v0.9";

        return playerScoreCollection;
    }
}