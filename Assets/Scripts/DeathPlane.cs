using UnityEngine;
using System.Collections;

public class DeathPlane : MonoBehaviour {

	// Use this for initialization
    void OnCollisionEnter(Collision Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            GameManager.gm.RespawnPlayer();
        }
    }
}
