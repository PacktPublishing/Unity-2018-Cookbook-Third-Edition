using UnityEngine;

public class MyGUIFlexibleSpace : IMyGUI
{
	public void OnGUI()
	{
		GUILayout.FlexibleSpace();
	}
}
