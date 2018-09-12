using UnityEngine;

public class ColorModel
{
    private Color color;

    public delegate void ColorChangeHandler(Color newColor);
    public static event ColorChangeHandler OnChangeColor;

    private void PublishColorEvent()
    {
        // if there is at least one listener to this delegate
        if (OnChangeColor != null)
            // broadcast change colour event 
            OnChangeColor(this.color);
    }

	public void SetColor(Color newColor)
	{
		this.color = newColor;
        PublishColorEvent();
	}
}