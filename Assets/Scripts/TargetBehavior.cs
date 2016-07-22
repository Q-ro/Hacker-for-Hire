using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{

	// target impact on game
	public int scoreAmount = 0;
	public float timeAmount = 0.0f;
    public bool isKey = false;
    public GameObject DoorToUnlock;

	// explosion when hit?
	public GameObject explosionPrefab;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}

		// only do stuff if hit by a projectile
        if (newCollision.gameObject.tag == "Projectile" || newCollision.gameObject.tag == "BombProjectile")
        {
			if (explosionPrefab) {
				// Instantiate an explosion effect at the gameObjects position and rotation
				Instantiate (explosionPrefab, transform.position, transform.rotation);
			}

			// if game manager exists, make adjustments based on target properties
            if (GameManager.gm && !isKey)
            {
				GameManager.gm.targetHit (scoreAmount, timeAmount);
			}

            if(isKey)
            {
                DoorToUnlock.GetComponent<LockedDoors>().RemoveLock();
            }
				
			// destroy the projectile
			Destroy (newCollision.gameObject);            
				
			// destroy self
			Destroy (gameObject);
		}
	}

}
