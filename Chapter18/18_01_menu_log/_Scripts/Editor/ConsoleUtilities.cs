using UnityEditor;
using UnityEngine;
using System.Reflection;

public class ConsoleUtilities : EditorWindow
{
//    [MenuItem("My Utilities/Clear Console %k")] // CTRL-CMD + K
    [MenuItem("My Utilities/Clear Console")]
    public static void ClearLogConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    
//    [MenuItem("My Utilities/Log a message %l")] // CTRL-CMD + L
    [MenuItem("My Utilities/Log a message")] 
    public static void LogHello()
    {
        Debug.Log("Hello from my console utilties");
    }
}
