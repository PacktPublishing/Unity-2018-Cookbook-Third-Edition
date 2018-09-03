using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class ReadImageFromWebUnityWebRequest : MonoBehaviour 
{
	// URL of image
	public string url = "http://www.packtpub.com/sites/default/files/packt_logo.png";

	/*-----------------------------------------------
	 * load image from web and display in scene
	 */
	IEnumerator Start()
	{
		using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
		{
			yield return uwr.SendWebRequest();

			if (uwr.isNetworkError || uwr.isHttpError)
				Debug.Log(uwr.error);
			else {
 				// extract image contents from 'www'
				Texture2D texture = DownloadHandlerTexture.GetContent(uwr);

				// use texture to update UI Raw Image
				UpdateUIRawImage(texture);
			}
		}
	}
	
	private void UpdateUIRawImage(Texture2D texture)
	{
		// display image, by getting reference to sibling UI RawImage component
		// and setting the 'texture' property of that component to the loaded texture image
		GetComponent<RawImage>().texture = texture;		
	}
}