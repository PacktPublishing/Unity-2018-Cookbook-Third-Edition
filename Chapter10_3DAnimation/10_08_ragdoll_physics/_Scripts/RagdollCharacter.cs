using UnityEngine;
using System.Collections;

/* ----------------------------------------
 * class to demonstrate how to apply Ragdoll physics 
 * to a character previously set up with Ragdoll Wizard
 */ 
public class RagdollCharacter : MonoBehaviour
{
	private Transform spawnPoint;
	
	void Start () {
		// locate GameObject tagged "Respawn"
		spawnPoint = GameObject.FindWithTag("Respawn").transform;
		
		// deactive the ragdoll, and respawn player
	    DeactivateRagdoll();
    }

	/**
	 * turn on ragdoll physics
	 */
	public void ActivateRagdoll()
	{
		// Disable Character Controller component
		gameObject.GetComponent<CharacterController> ().enabled = false;

		// turn on rag roll
		SetActiveRagdoll(true);
		
		// Start coroutine to restore character after a few seconds
		StartCoroutine (Restore ());
	}

	/**
	 * turn off ragdoll, and respawn player
	 */
	public void DeactivateRagdoll()
	{
		// turn off ragdoll
		SetActiveRagdoll(false);

		// respawn player to start position
		RespawnPlayer();
		
		// Enable character's Basic Controller component 
		gameObject.GetComponent<CharacterController>().enabled = true;

	}

	/**
	 * after 5 seconds, turn off ragdoll and respawn player
	 */
	IEnumerator Restore()
	{
		// Wait for five seconds
		yield return new WaitForSeconds(5);

		// Deactivate Ragdoll 
		DeactivateRagdoll();
	}
	
	
	/* ----------------------------------------
	 * A function to activate all components that allow for ragdoll physics
	 */
	public void SetActiveRagdoll(bool isActive)
	{
		// enable/disable Character Controller component
		gameObject.GetComponent<CharacterController> ().enabled = !isActive;

		//  enable/disable character's Basic Controller component (a C# script that controls Mecanim system)
		gameObject.GetComponent<BasicController> ().enabled = !isActive;

		//  enable/disable Animator component 
		gameObject.GetComponent<Animator> ().enabled = !isActive;
		

		// Find every Rigidbody in character's hierarchy
		foreach (Rigidbody bone in GetComponentsInChildren<Rigidbody>()) {
			// Set bone's rigidbody component as not kinematic
			bone.isKinematic = !isActive;
				
			//enable/disable collision detection for rigidbody component 
			bone.detectCollisions = isActive;
		}

		// Find every CharacterJoint in character's hierarchy
		foreach (CharacterJoint joint in GetComponentsInChildren<CharacterJoint>()) {
			// Set CharacterJoint's Enable Projection as True/False
			joint.enableProjection = isActive;
		}

		// Find every Collider in character's hierarchy
		foreach (Collider col in GetComponentsInChildren<Collider>()) {
			// enable/disable Collider
			col.enabled = isActive;
		}
	}

	/**
	 * move player back to respawn point, with its rotation too
	 */
	private void RespawnPlayer()
	{
		transform.position = spawnPoint.position;
		transform.rotation = spawnPoint.rotation;	
	}
}
