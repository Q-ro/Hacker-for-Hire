using UnityEngine;
using System.Collections;

public class RailGate : MonoBehaviour {

    public GameObject[] waypoints;
    public GameObject RailwayTargets;
    public GameObject Checkpoint;
    //public bool GravityWay = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void  OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.gm.SetCheckpoint(Checkpoint);

            if(RailwayTargets != null)
                RailwayTargets.SetActive(true);

            if (waypoints.Length > 0)
            {
                //Debug.Log("im hit");
                other.GetComponent<Controller>().waypoints = waypoints;
                other.GetComponent<Controller>()._playerOnRails = true;
            }
        }

    }
}
