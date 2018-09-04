using UnityEngine; 
using System.IO; 

public class SaveTextFile : MonoBehaviour {
	public string fileName = "hello.txt";
	public string folderName = "Data";
	private string filePath = "(no file path yet)";
	private FileReadWriteManager fileManager;
	
	void Start () {
        string textData = "hello \n and goodbye";
        fileManager = new FileReadWriteManager();
	 	filePath = Path.Combine(Application.dataPath, folderName);
	 	filePath = Path.Combine(filePath, fileName);		
		fileManager.WriteTextFile( filePath, textData ); 
	} 
} 