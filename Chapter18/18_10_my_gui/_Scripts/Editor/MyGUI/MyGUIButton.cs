using UnityEngine;

public class MyGUIButton : IMyGUI
{
    public GUIContent label = new GUIContent();
    public event System.Action OnClick;
    
    public void OnGUI() {
        // if button clicked, invoke methods registed with 'OnClick' event
        if (GUILayout.Button (label) && OnClick != null)
            OnClick ();
    }
}
