using UnityEngine;
using UnityEngine.UI;

public class ColorChangeListenerImage : MonoBehaviour
{
	void OnEnable() {
		ColorModel.OnChangeColor += ChangeColorEvent;
	}
	
	void OnDisable(){
		ColorModel.OnChangeColor -= ChangeColorEvent;
	}

    void ChangeColorEvent(Color newColor)
    {
		GetComponent<Image>().color = newColor;
	}
}