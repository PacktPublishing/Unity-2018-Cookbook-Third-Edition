using UnityEngine;
using System;
using System.Xml;
using System.IO;

public class ParseXML : MonoBehaviour {
	public TextAsset scoreDataTextFile;

    private PlayerScoreDate[] playerScores = new PlayerScoreDate[999]; 

    // get data / extract into object array / loop to print each object
	private void Start() {
		string textData = scoreDataTextFile.text;
        int numberObjects = ParseScoreXML( textData );

        for (int i = 0; i < numberObjects; i++)
            print(playerScores[i]);
	}
	
    // extract player score objects from XML and insert into array 'playerScores'
    private int ParseScoreXML(string xmlData) {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load( new StringReader(xmlData) );
		
		string xmlPathPattern = "//scoreRecordList/scoreRecord";
		XmlNodeList myNodeList = xmlDoc.SelectNodes( xmlPathPattern );

        int i = 0;
        foreach(XmlNode node in myNodeList){
            playerScores[i] = NodeToPlayerScoreObject(node);
            i++;
        }

        return i;
	}
	
    // given XML node, create and return a PlayerScore object
    private PlayerScoreDate NodeToPlayerScoreObject(XmlNode node) {
		XmlNode playerNode = node.FirstChild;
        string playerName = playerNode.InnerXml;

		XmlNode scoreNode = playerNode.NextSibling;
        string scoreString = scoreNode.InnerXml;
        int score = Int32.Parse(scoreString);

		XmlNode dateNode = scoreNode.NextSibling;
        string date = NodeToDateString(dateNode);
		
        PlayerScoreDate playerObject = new PlayerScoreDate();
        playerObject.SetPlayerName(playerName);
        playerObject.SetScore(score);
        playerObject.SetDate(date);

        return playerObject;

	}
	
    // return date as a string in form "DD/MM/YYYY"
	private string NodeToDateString(XmlNode dateNode) {
		XmlNode dayNode = dateNode.FirstChild;
		XmlNode monthNode = dayNode.NextSibling;
		XmlNode yearNode = monthNode.NextSibling;	
		
		return dayNode.InnerXml + "/" + monthNode.InnerXml + "/" + yearNode.InnerXml;
	}	
}
