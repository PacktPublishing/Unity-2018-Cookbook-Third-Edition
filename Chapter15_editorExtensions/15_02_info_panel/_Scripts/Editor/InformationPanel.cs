using UnityEditor;
using UnityEngine;

public class InformationPanel : EditorWindow
{
    [MenuItem("My Game/Info Panel")]
    public static void ShowWindow()
    {
        GetWindow<InformationPanel>(false, "My Game", true);
    }
   
    private void OnGUI()
    {
        GUILayout.Label("Hello editor world");
        GUILayout.FlexibleSpace();
        GUILayout.Label("Here is some important information");
        GUILayout.FlexibleSpace();
    }   
    
//    private void OnGUI()
//    {
//        GUILayout.Label("Hello editor world");
//        GUILayout.FlexibleSpace();
//
//        GUILayout.BeginHorizontal();
//        GUILayout.FlexibleSpace();
//        
//            GUILayout.Label("I am in the center !!!");
//        
//        GUILayout.FlexibleSpace();
//        GUILayout.EndHorizontal();
//
//        GUILayout.FlexibleSpace();
//    }
}
