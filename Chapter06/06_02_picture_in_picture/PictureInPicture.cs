using UnityEngine;

/* ----------------------------------------
 * class to demonstrate how to create a Picture-in-Picture effect
 * using two cameras. This script should be attached to a secondary camera
 * featuring a higher Depth level than the main camera.
 */
public class PictureInPicture : MonoBehaviour
{
	// Posssible values for Horizontal Alignment
	public enum HorizontalAlignment
	{
		Left, Center, Right
	};

	// possible values for Vertical Alignment
	public enum VerticalAlignment
	{
		Top, Center, Bottom
	};

	// Set initial value for Horizontal Alignment as 'left' 
	public HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;

	// Set initial value for Vertical Alignment as 'top' 
	public VerticalAlignment verticalAlignment = VerticalAlignment.Top;

	// width of viewport as percentage of screen
	public float widthPercentage = 0.5f;
	
	// height of viewport as percentage of screen
	public float heightPercentage = 0.5f;

	// reference to the Camera component
	private Camera camera;

	// when scene starts get reference to Camera component
	void Start()
	{
		camera = GetComponent<Camera>();
	}

	// every frame update Camera properties
	void Update()	
	{
		Vector2 origin = CalcOrigin();
		Vector2 size = new Vector2(widthPercentage, heightPercentage);
		Rect newCameraRect = new Rect(origin, size);
		camera.rect = newCameraRect;
	}
	

	// based on horizontal and vertical alignment
	// create and returrn a 2D (x,y) bottom left origin for Camera's viewport 
	private Vector2 CalcOrigin()
	{
		float originX = 0;
		float originY = 0;

		switch (horizontalAlignment)
		{
			case HorizontalAlignment.Right:
				originX = 1 - widthPercentage;
				break;
			
			case HorizontalAlignment.Center:
				originX = 0.5f - (0.5f * widthPercentage);
				break;
			
			case HorizontalAlignment.Left:
			default:
				originX = 0;
				break;
		}
		
		switch (verticalAlignment)
		{
			case VerticalAlignment.Top:
				originY = 1 - heightPercentage;
				break;
			
			case VerticalAlignment.Center:
				originY = 0.5f - (0.5f * heightPercentage);
				break;
			
			case VerticalAlignment.Bottom:
			default:
				originY = 0;
				break;
		}

		return  new Vector2(originX, originY);
	}
}
