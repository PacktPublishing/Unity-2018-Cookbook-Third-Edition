using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectBuilderScript))]
public class ObjectBuilderEditor : Editor{
	private Texture iconStar;
	private Texture iconHeart;
	private Texture iconKey;
	
	private GameObject prefabHeart;
	private GameObject prefabStar;
	private GameObject prefabKey;
	
	void OnEnable () {
		iconStar = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_star_32.png", typeof(Texture)) as Texture;
		iconHeart = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_heart_32.png", typeof(Texture)) as Texture;
		iconKey = AssetDatabase.LoadAssetAtPath("Assets/EditorSprites/icon_key_green_32.png", typeof(Texture)) as Texture;
		
		prefabStar = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/star.prefab", typeof(GameObject)) as GameObject;
		prefabHeart = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/heart.prefab", typeof(GameObject)) as GameObject;
		prefabKey = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/key.prefab", typeof(GameObject)) as GameObject;
	}
	
	public override void OnInspectorGUI()
	{	
		GUILayout.Label("");
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label("Click button to create instance of prefab");
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.Label("");
		
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if(GUILayout.Button(iconStar)) AddObjectToScene(prefabStar);
		GUILayout.FlexibleSpace();
		if(GUILayout.Button(iconHeart)) AddObjectToScene(prefabHeart);
		GUILayout.FlexibleSpace();
		if(GUILayout.Button(iconKey)) AddObjectToScene(prefabKey);
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
	}
	
	private void AddObjectToScene(GameObject prefabToCreateInScene)
	{
		ObjectBuilderScript myScript = (ObjectBuilderScript)target;
		GameObject newGo = Instantiate(prefabToCreateInScene, myScript.gameObject.transform.position, Quaternion.identity);
		newGo.name = prefabToCreateInScene.name;
	}
}
