using UnityEngine;
using UnityEditor;

public class MyGreatGameEditor : MonoBehaviour
{
	// max/min range for X and Y values
	const float X_MAX = 10f;
	const float Y_MAX = 10f;

	// reference to prefab object, of which we are going to make 100 instances in Scene
	static GameObject starPrefab;
	
	static GameObject starContainerGO;

	/*---------------------------------------------------------
	 * create a parent GameObject 'Star-containier'
	 * that will be the parent for all the generated star prefab clones
	 */
	private static void CreateStarContainerGo() 
	{
		string containerName = "Star-container";
		starContainerGO = GameObject.Find(containerName);
		if (null != starContainerGO)
			DestroyImmediate(starContainerGO);

		starContainerGO = new GameObject(containerName);
	}

	/*---------------------------------------------------------
	 * display menu "My-Great-Game"
	 * with one menu item "Make 100 stars"
	 * and when that menu item is chosen the next method will execute - i.e. PlacePrefabs()
	 */
	[MenuItem("My-Great-Game/Make 100 stars")]
	static void PlacePrefabs()
	{
		CreateStarContainerGo();

		// path to our prefab object
		string assetPath = "Assets/Prefabs/prefab_star.prefab";

		// load the prefab into 'starPrefab;
		starPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath(assetPath);

		// loop 100 times, creating an instance in a random location each time
		int total = 100;
		for(int i = 0; i < total; i++){
			CreateRandomInstance();
			EditorUtility.DisplayProgressBar("Creating your starfield", i + "%", i/100f);
		}
		
		EditorUtility.ClearProgressBar();
	}
	
	/*---------------------------------------------------------
	 * create a randomly placed instance of 'starPrefab'
	 * in the range (-X_MAX, -Y_MAX) - (X_MAX, Y_MAX)
	 */
	static void CreateRandomInstance()
	{
		Vector3 randomPosition = RandomPosition();		
//		Instantiate(starPrefab, randomPosition, Quaternion.identity);
		
		GameObject newStarGo = (GameObject)Instantiate(starPrefab, randomPosition, Quaternion.identity);
		newStarGo.transform.parent = starContainerGO.transform;
	}
	
	/*---------------------------------------------------------
	* create a randomly placed instance of 'starPrefab'
	* in the range (-X_MAX, -Y_MAX) - (X_MAX, Y_MAX)
	*/
	private static Vector3 RandomPosition()
	{
		float x = Random.Range(-X_MAX, X_MAX);
		float y = Random.Range(-Y_MAX, Y_MAX);
		float z = 0;
		return new Vector3(x,y,z);
	}
}
