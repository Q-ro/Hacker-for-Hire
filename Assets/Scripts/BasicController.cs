using UnityEngine;
using System.Collections;

public class BasicController : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
    {
        //Prints to console the current value of the horizontal axis
        Debug.Log("Horizontal Input = " + Input.GetAxis("Horizontal"));
	
	}
}
