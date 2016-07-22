using UnityEngine;
using System.Collections;

public class BasicTargetMover : MonoBehaviour
{
    
    //How fast the object will spin
    public float spinSpeed = 180.0f;
    //How fast the object will move
    public float motionMagnitude = 0.1f;

    public bool doSpin = true;
    public bool doMove = false;



	// Update is called once per frame
	void Update () 
    {
        if (doSpin)
        {
            // Rotates the gameObject around it's up axis
            gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }

        if (doMove)
        {
            // Move up and down over time
            gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
        }
	}
}
