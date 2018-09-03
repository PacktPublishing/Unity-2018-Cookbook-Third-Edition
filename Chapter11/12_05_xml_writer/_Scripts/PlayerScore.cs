using System.Collections.Generic;
using System.Xml;
using System.IO;

public class PlayerScore {	
	private string _name;
	private int _score;
	
	public PlayerScore(string name, int score) {
		_name = name;
		_score = score;
	}

	// class method
	static public string ListToXML(List<PlayerScore> playerList) {
		StringWriter str = new StringWriter();
		XmlTextWriter xml = new XmlTextWriter(str);
		
		// start doc and root el.
		xml.WriteStartDocument();
		xml.WriteWhitespace("\n  ");
		xml.WriteStartElement("playerScoreList");
		xml.WriteWhitespace("\n  ");

		// add elements for each object in list
		foreach (PlayerScore playerScoreObject in playerList) {
			playerScoreObject.ObjectToElement( xml );
		}
	
		// end root and document
		xml.WriteEndElement();
		xml.WriteWhitespace("\n  ");
		xml.WriteEndDocument();

		return str.ToString();
	}

	private void ObjectToElement(XmlTextWriter xml) {
		// data element
		xml.WriteStartElement("player");
        xml.WriteWhitespace("\n  ");
		xml.WriteElementString("name", _name);
        xml.WriteWhitespace("\n  ");
		string scoreString = "" + _score; // make _score a string
	    xml.WriteElementString("score", scoreString);
        xml.WriteWhitespace("\n  ");
		xml.WriteEndElement();		
        xml.WriteWhitespace("\n  ");
	}	
}
