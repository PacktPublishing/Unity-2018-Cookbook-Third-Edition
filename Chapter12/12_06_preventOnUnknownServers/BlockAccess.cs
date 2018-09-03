using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
	
/* ----------------------------------------
 * class to demonstrate how to prevent a webgame made with unity 
 * from running on unknown servers
 */ 
public class BlockAccess : MonoBehaviour
{
	// UI text - to show warning if bad domain
	public Text textUI;

	// String variable for entering the message to be displayed when blocking access to the game
	public string warning;

	// Boolean variable. Set as 'true' if using the game's full URL, from "http:" to ".unity3d) 
	public bool fullURL = true;

	// String Array for entering valid URLs for the game to be located at  
	public string[] domainList;

	/**
	 * test domain when Scene first loads...
	 */
	private void Start()
	{
		// Text component from the UI Text game object
		Text scoreText = GetComponent<Text>();

		// IF game runs on browser and checkDomain is set as 'true', THEN run 'for' loop through list of valid URLs
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{

			string url = Application.absoluteURL;
			if (LegalCopy(url))
				LoadNextScene();
			else
				// show warning - and do NOT proceed to next Scene 
				textUI.text = warning;

		}
	}

	/**
	 * return TRUE if running in Editor or the URL matches one in the domain list array
	 */
	private bool LegalCopy(string Url)
	{
        // not illegal if running in the Unity editor
        if (Application.isEditor)
	        return true;
	
		// search each domain in array for given Url string
		for (int i = 0; i < domainList.Length; i++){
			// full string match - found
			if (Application.absoluteURL == domainList[i])
				return true;

			// within URl and not need full match
			if (Application.absoluteURL.Contains(domainList[i]) && !fullURL)
				return true;
		}
		
		// if get here, we didn't find the URL
		return false;
	}
	
	/**
	 * load the next Scene in the Build sequence
	 */		
	private void LoadNextScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		int nextSceneIndex = currentSceneIndex + 1;
		SceneManager.LoadScene(nextSceneIndex);
	}

}
