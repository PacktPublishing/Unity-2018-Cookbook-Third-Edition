using UnityEngine;

public class ColorChangeListenerConsole
{
    public ColorChangeListenerConsole() 
    {
		ColorModel.OnChangeColor += ChangeColorEvent;
	}
	
    ~ColorChangeListenerConsole()
    {
		ColorModel.OnChangeColor -= ChangeColorEvent;
	}

	void ChangeColorEvent(Color newColor){
        Debug.Log("new color = " + newColor); 
	}
}
