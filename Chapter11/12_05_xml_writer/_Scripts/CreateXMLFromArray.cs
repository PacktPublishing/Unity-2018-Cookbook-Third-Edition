using UnityEngine;
using System.Collections.Generic;

public class CreateXMLFromArray : MonoBehaviour {
	private List<PlayerScore> playerScoreList;

	private void Start () {
		playerScoreList = new List<PlayerScore>();
        playerScoreList.Add (new PlayerScore("matt", 200) );
        playerScoreList.Add (new PlayerScore("jane", 150) );

		string output = PlayerScore.ListToXML( playerScoreList );
        print(output); 
	}
}