using UnityEngine;
using System.IO;

public class CreateXMLTextFile : MonoBehaviour 
{
	public string fileName = "playerData.xml";
	public string folderName = "Data";
	
	private void Start() 
    {
        // Documents
		string filePath = Path.Combine( Application.dataPath, folderName);
		filePath = Path.Combine( filePath, fileName);

		PlayerXMLWriter playerXMLWriter = new PlayerXMLWriter(filePath);
        playerXMLWriter.AddXMLElement("matt", "55");
        playerXMLWriter.AddXMLElement("jane", "99");
        playerXMLWriter.AddXMLElement("fred", "101");
        playerXMLWriter.SaveXMLFile();
		
		print( "XML file should now have been created at: " + filePath);
	}
}