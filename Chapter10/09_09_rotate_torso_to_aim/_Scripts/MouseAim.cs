using UnityEngine;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to procedurally rotate 
 * a character's bone depending on user's input
 */ 
public class MouseAim: MonoBehaviour 
{
	// Character's transform bone that should be rotated
	public Transform spine;

	// character's weapon
	public Transform weapon;

	// UI Image for the crosshair
	public GameObject crosshairImage;

	// minimum and maximum values for rotation around Z-Axis
	public Vector2 xLimit = new Vector2(-30f, 30f);

	// minimum and maximum values for rotation around Y-Axis
	public Vector2 yLimit= new Vector2(-30f, 30f);

	// amount to rotate spine around its Z-Axis
	private float xAxis = 0f;

	// amount to rotate spine around its Y-Axis
	private float yAxis = 0f;

	/* ----------------------------------------
	 * AFTER any animations have played (hence LateUpdate)
	 * rotate spine then show aim image it rayhast hits something
	 */
	public void LateUpdate()
	{
		RotateSpine();
		ShowCrosshairIfRaycastHit();
	}

	/**
	 * rotate Spine of model based on location of mouse pointer
	 */
	private void RotateSpine()
	{
		// Add horizontal mouse speed to yAxis rotation
		yAxis += Input.GetAxis("Mouse X");

		// Clamp yAxis roation to specified values, avoiding impossible twists in character's bone structure
		yAxis = Mathf.Clamp(yAxis, yLimit.x, yLimit.y);

		// Add horizontal mouse speed to yAxis rotation
		xAxis -= Input.GetAxis("Mouse Y");

		// Clamp yAxis roation to specified values, avoiding impossible twists in character's bone structure
		xAxis = Mathf.Clamp(xAxis, xLimit.x, xLimit.y);

		// Create 3D Vector for character's spine new transform rotation
		Vector3 newSpineRotation = new Vector3(xAxis, yAxis, spine.localEulerAngles.z);

		// Apply new rotation to character's spine
		spine.localEulerAngles = newSpineRotation;
	}
	
	/**
	 * IF a Raycast for direction of weapon hits something
	 * THEN display aim image at that location
	 */
	private void ShowCrosshairIfRaycastHit()
	{
		// weapon's forward direction 
		Vector3 weaponForwardDirection = weapon.TransformDirection(Vector3.forward);
		
		// our Raycasthit variable - to be updated when we fire a Raycasxt
		RaycastHit hit; 
		
		// start casting 1 unit ahead of weapon position 
		Vector3 fromPosition = weapon.position + Vector3.one;

		// IF Raycast from weapon hits someting
		if (Physics.Raycast (fromPosition, weaponForwardDirection, out hit)) {
			// THEN convert hit point to screen coordinates
			Vector3 hitLocation =  Camera.main.WorldToScreenPoint(hit.point);
			
			// move aim image there and reveal it
			DisplayPointerImage(hitLocation);
		} else
			// hide aim image
			crosshairImage.SetActive(false);
		
		//------ debug ------- Scene panel
		// draw a ray from the weapon to its forward direction 
		Debug.DrawRay (weapon.position, weaponForwardDirection * 1000, Color.green);
	}

	/**
	 * move aim image to given position on screen
	 * and reveal it (make it active)
	 */
	private void DisplayPointerImage(Vector3 hitLocation)
	{
		// AND set the UI crosshair's position to aimloc (which is the hit point position converted to screen coordinates) 
		crosshairImage.transform.position = hitLocation;

		// AND set UI crosshair as active...
		crosshairImage.SetActive(true);
	}
}
