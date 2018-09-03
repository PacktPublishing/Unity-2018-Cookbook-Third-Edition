using UnityEngine;
using UnityEngine.UI;

public class ColorChangeListenerText : MonoBehaviour
{
	void OnEnable() {
		ColorModel.OnChangeColor += ChangeColorEvent;
	}
	
    void OnDisable(){
		ColorModel.OnChangeColor -= ChangeColorEvent;
	}

    void ChangeColorEvent(Color newColor)
    {
		GetComponent<Text>().color = newColor;
	}
}
