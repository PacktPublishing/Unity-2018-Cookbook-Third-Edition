using UnityEditor;
using UnityEngine;

public class ObjectManagerPrimitives : EditorWindow
{
    [MenuItem("GameObject/MyObjectManager/Create New RandomShape GameObject")]
    static void CreateCustomPrimitiveGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = BuildGameObjectRandomPrimitive();
        go.transform.position = RandomPosition(5);
        go.GetComponent<Renderer>().sharedMaterial = RandomMaterialColor();

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }

    private static Material RandomMaterialColor()
    {
        Shader shaderSpecular = Shader.Find("Specular");
        Material material = new Material(shaderSpecular);
        material.color = Random.ColorHSV();

        return material;
    }
    private static Vector3 RandomPosition(float limit)
    {
        float x = Random.Range(-limit, limit);
        float y = Random.Range(-limit, limit);
        float z = Random.Range(-limit, limit);
        return new Vector3(x,y,z);
    }

    private static GameObject BuildGameObjectRandomPrimitive()
    {
        GameObject go;
        PrimitiveType primitiveType = PrimitiveType.Cube;
        int type = Random.Range(0, 4);

        switch (type)
        {
            case 0:
                primitiveType = PrimitiveType.Sphere;
                break;
            
            case 1:
                primitiveType = PrimitiveType.Capsule;
                break;
            
            case 2:
                primitiveType = PrimitiveType.Cylinder;
                break;                
        }

        go = GameObject.CreatePrimitive(primitiveType);
        go.name = "GameObject - custom - " + primitiveType.ToString();
        return go;
    }
}
