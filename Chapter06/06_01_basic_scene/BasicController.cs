using UnityEngine;
using System.Collections;
/* ----------------------------------------
 * class to demonstrate how to control a 
 * character using Character Controller and the Mecanim system
 */ 
public class BasicController: MonoBehaviour {
	// Variable for the character's Animator component
	private Animator anim;

	// Variable for the character's Character Controller component
	private CharacterController controller;
	
	// float variable for dampening speed values
	public float transitionTime = .25f;
	
	// float variable for speed limit
	private float speedLimit = 1.0f;

	
	//float variable for the vertical speed of the character
	private float verticalSpeed = 0f;
	
	// float variable for character's velocity on X-axis
	private float xVelocity = 0f;
	
	// float variable for character's velocity on X-axis
	private float zVelocity = 0f;
	
	/* ----------------------------------------
	 * At Start, get character's Animator and Character Controller components
	 */
	void Start () {
		// Assign character's Controller to 'controller' variable
		controller = GetComponent<CharacterController>();
		
		// Assign character's Animator to 'anim' variable
		anim = GetComponent<Animator>();
	}
	
	/* ----------------------------------------
	 * Whenever Directional controls are used, update variables from the Animator
	 */
	void Update () {
		
		// IF Character Controller is grounded...
		if (controller.isGrounded) {



						// IF 'Q' key is being pressed, THEN...
						if (Input.GetKey (KeyCode.Q)) {
				
								//... set 'TurnLeft' bool variable of the Animator as true
								anim.SetBool ("TurnLeft", true);
				
								// ... and rotate character to its left
								transform.Rotate (Vector3.up * (Time.deltaTime * -45.0f), Space.World);
				
								// ELSE, if 'Q' key is NOT being pressed, THEN...
						} else {
				
								//... set 'TurnLeft' bool variable of the Animator as false
								anim.SetBool ("TurnLeft", false);	
						}
			
						// IF 'E' key is being pressed, THEN...
						if (Input.GetKey (KeyCode.E)) {
				
								//... set 'TurnRight' bool variable of the Animator as true
								anim.SetBool ("TurnRight", true);
				
								// ... and rotate character to its right
								transform.Rotate (Vector3.up * (Time.deltaTime * 45.0f), Space.World);
				
								// ELSE, if 'E' key is NOT being pressed, THEN...
						} else {
								//... set 'TurnRight' bool variable of the Animator as false
								anim.SetBool ("TurnRight", false);	
						}
			
			
			
						if (Input.GetKey (KeyCode.RightShift) || Input.GetKey (KeyCode.LeftShift))
				// IF Shift key is pressed, THEN set speed limit to 0.5, slowing down the character
								speedLimit = 0.5f;
						else 
				// ELSE, set speed limit to full speed (1.0)
								speedLimit = 1.0f;	
			
						// a float variable to get Horizontal Axis input (left/right)
						float h = Input.GetAxis ("Horizontal");
			
						// a float variable to get Vertical Axis input (forward/backwards)
						float v = Input.GetAxis ("Vertical");
			
						// float variable for horizontal speed and direction, obtained by multiplying Horizontal Axis by the speed limit
						float xSpeed = h * speedLimit;	
			
						// float variable for vertical speed and direction, obtained by multiplying Vertical Axis by the speed limit
						float zSpeed = v * speedLimit;	
			
						// float variable for absolute speed 
						float speed = Mathf.Sqrt (h * h + v * v);
			
						if (v != 0 )
				// IF Vertical Axis input is different than 0 AND moveDiagonally boolean is set to false, THEN set horizontal speed as 0 
								xSpeed = 0;
			
						if (v != 0)
				// IF Vertical Axis input is different than 0 AND keyboardRotate boolean is set to true, THEN rotate character according to Horizontal Axis input
								this.transform.Rotate (Vector3.up * h, Space.World);

			
						// Set zSpeed float as 'zSpeed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
						anim.SetFloat ("zSpeed", zSpeed, transitionTime, Time.deltaTime);
			
						// Set xSpeed float as 'xSpeed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
						anim.SetFloat ("xSpeed", xSpeed, transitionTime, Time.deltaTime);
			
						// Set speed float as 'Speed' variable of the Animator, dampening it for the amount of time in 'transitionTime' 
						anim.SetFloat ("Speed", speed, transitionTime, Time.deltaTime);
			}
		
	}

	/* ----------------------------------------
	 * A function for whenever the Animator moves. If the character is grounded, get its X and Z-axis velocities.
	 * If not grounded, move character based on previous X and Z velocities, also using gravity to calculate its 
	 * vertical speed (on the Y-axis). 
	 */
	void OnAnimatorMove(){
		// Vector 3 variable for getting the Animator's position
		Vector3 deltaPosition = anim.deltaPosition;
		
		if (controller.isGrounded) {
			// IF character is grounded, THEN set xVelocity variable as its current x-axis velocity... 
			xVelocity = controller.velocity.x;

			// ... AND set zVelocity variable as its current z-axis velocity
			zVelocity = controller.velocity.z;
		} else {
			// ELSE, if not grounded, THEN change deltaPosition.x to last obtained xVelocity...  
			deltaPosition.x = xVelocity * Time.deltaTime;

			// ... AND change deltaPosition.x to last obtained xVelocity... 
			deltaPosition.z = zVelocity * Time.deltaTime;	

		}

		// deltaPosition.x to 'verticalSpeed'
		deltaPosition.y = verticalSpeed * Time.deltaTime;

		// Move the character controler to deltaPosition
		controller.Move (deltaPosition);

		// update verticalSpeed, adding up the force of gravity
		verticalSpeed += Physics.gravity.y * Time.deltaTime;	

		if ((controller.collisionFlags & CollisionFlags.Below) != 0) {
			// IF the character collides with something below, THEN set verticalSpeed as 0
			verticalSpeed = 0;	
		}
	}

}
