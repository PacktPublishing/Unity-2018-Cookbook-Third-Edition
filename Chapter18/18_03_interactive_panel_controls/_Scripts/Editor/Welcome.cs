using UnityEditor;
using UnityEngine;

public class Welcome : EditorWindow
{
    private string playerName = "";
    private string tempName = "";


    [MenuItem("Welcome/Hello Player")]
    public static void ShowWindow()
    {
		GetWindow<Welcome>("Welcome", true);
    }

    private void OnFocus()
    {
        if (EditorPrefs.HasKey("PlayerName"))
            playerName = EditorPrefs.GetString("PlayerName");
    }


    private void OnGUI()
    {
        // hello
        string helloMessage = "Hello (no name)";
        if (playerName.Length > 0){
            helloMessage = "Hello " + playerName;
        }        
        GUILayout.Label(helloMessage);        
        GUILayout.FlexibleSpace();

        // text input
        tempName = EditorGUILayout.TextField("Player name:", tempName);

        // button
        if (GUILayout.Button("Update")){
            playerName = tempName;
        }
    }

    // automatic save when panel loses focus
    private void OnLostFocus()
    {
        SavePrefs();
    }

    // automatic save when panel closed/destroyed
    private void OnDestroy()
    {
        SavePrefs();
    }

    private void SavePrefs()
    {
        EditorPrefs.SetString("PlayerName", playerName);
    }

}
