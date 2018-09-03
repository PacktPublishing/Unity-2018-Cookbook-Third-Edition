using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadWithStream : MonoBehaviour 
{
    private string fileName = "cities.txt";

    private string textFileContents = "(file not found yet)";	
	private FileReadWriteManager fileReadWriteManager = new FileReadWriteManager();

	private void Start () {
	 	string filePath = Path.Combine(Application.dataPath, "Resources");
	 	filePath = Path.Combine(filePath, fileName);
		
		textFileContents = fileReadWriteManager.ReadTextFile( filePath );

        Text textOnScreen = GetComponent<Text>();
        textOnScreen.text = textFileContents;
    }	
}