using UnityEngine;
using UnityEditor;

public class MyGUITextField : IMyGUI
{
    public string text = "";
    public GUIContent label = new GUIContent();
    
    public void OnGUI() {
        text = EditorGUILayout.TextField (label, text);
    }
}