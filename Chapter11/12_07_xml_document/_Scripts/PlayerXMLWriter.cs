using System.Xml;
using System.IO;

public class PlayerXMLWriter 
{
	private string filePath;
	private XmlDocument xmlDoc;
	private XmlElement elRoot;
	
	public PlayerXMLWriter(string filePath) 
    {
		this.filePath = filePath;
		xmlDoc = new XmlDocument();
		
		if(File.Exists (filePath)) {
			xmlDoc.Load(filePath);
			elRoot = xmlDoc.DocumentElement;
			elRoot.RemoveAll();
		}
		else {
			elRoot  = xmlDoc.CreateElement("playerScoreList");
			xmlDoc.AppendChild(elRoot);			
		}
	}

	public void AddXMLElement(string playerName, string playerScore) 
    {
		XmlElement elPlayer = xmlDoc.CreateElement("playerScore");
		elRoot.AppendChild(elPlayer);

		XmlElement elName = xmlDoc.CreateElement("name");
		elName.InnerText = playerName;
		elPlayer.AppendChild(elName);

		XmlElement elScore = xmlDoc.CreateElement("score");
		elScore.InnerText = playerScore;
		elPlayer.AppendChild(elScore);
	}

    public void SaveXMLFile() 
    {
        xmlDoc.Save(filePath);
    }
}