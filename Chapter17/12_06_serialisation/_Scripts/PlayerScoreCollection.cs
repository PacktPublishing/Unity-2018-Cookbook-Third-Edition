using System.Xml.Serialization;
using System.IO;


// adapted from:
// http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer

[XmlRoot("PlayerScoreCollection")]
public class PlayerScoreCollection
{
    [XmlArray("PlayerScores"), XmlArrayItem("PlayerScore")]
    public PlayerScore[] playerScores;

    // save data as XML to text file for given path
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(PlayerScoreCollection));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    // Loads XML from a file path
    public static PlayerScoreCollection Load(string path)
    {
        var serializer = new XmlSerializer(typeof(PlayerScoreCollection));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as PlayerScoreCollection;
        }
    }

    // Loads XML from a string
    public static PlayerScoreCollection LoadFromString(string text)
    {
        var serializer = new XmlSerializer(typeof(PlayerScoreCollection));
        return serializer.Deserialize(new StringReader(text)) as PlayerScoreCollection;
    }
}