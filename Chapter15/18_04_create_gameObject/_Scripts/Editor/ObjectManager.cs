using UnityEditor;
using UnityEngine;

namespace _Scripts.Editor
{
    public class ObjectManager : EditorWindow
    {
//        [MenuItem("GameObject/MyObjectManager/Create New Empty Game Object", false, 10)]
        [MenuItem("GameObject/MyObjectManager/Create New Empty Game Object")]
        static void CreateCustomEmptyGameObject(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("GameObject - custom - Empty");
            go.transform.position = RandomPosition(5);
            
            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
    
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    
        private static Vector3 RandomPosition(float limit)
        {
            float x = Random.Range(-limit, limit);
            float y = Random.Range(-limit, limit);
            float z = Random.Range(-limit, limit);
            return new Vector3(x,y,z);
        }
    }
}
