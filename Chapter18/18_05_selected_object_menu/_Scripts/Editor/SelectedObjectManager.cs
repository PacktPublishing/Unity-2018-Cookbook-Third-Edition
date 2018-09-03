using UnityEditor;
using UnityEngine;

public class SelectedObjectManager : EditorWindow
{
    [MenuItem("MyMenu/MoveToOrigin")]
    static void ZeroPosition()
    {
        GameObject selectedGameObject = Selection.activeTransform.gameObject;
        
        Undo.RecordObject (selectedGameObject.transform, "Zero Transform Position");
        selectedGameObject.transform.position = Vector3.zero;          
    }
    
    [MenuItem("MyMenu/MoveToOrigin", true)]
    static bool ValidateZeroPosition()
    {
        // Return false if no transform is selected.
        return Selection.activeTransform != null;
    }
}

