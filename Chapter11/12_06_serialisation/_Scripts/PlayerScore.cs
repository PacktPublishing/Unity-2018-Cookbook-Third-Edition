using System.Xml.Serialization;

[System.Serializable]
public class PlayerScore 
{
    [XmlElement("Name")]
    public string name; 

    [XmlElement("Score")]
    public int score;

    [XmlElement("Version")]
    public string version;	
}