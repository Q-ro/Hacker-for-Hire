using UnityEngine;
using System.Collections;

public class WaypointHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
     /*
    public void MoveToWaypoint()
    {

        if ((waypoints.Length != 0))
        {
            //Debug.Log("still on rail");

            // determine distance between waypoint and enemy
            var target = waypoints[_waypointIndex].transform.position;
            var moveDirection = target - _transform.position;

            // determine distance between waypoint and player
            var distanceX = waypoints[_waypointIndex].transform.position.x - _transform.position.x;
            var distanceZ = waypoints[_waypointIndex].transform.position.z - _transform.position.z;

            //Debug.Log(_waypointIndex);

            // if the player is close enough to waypoint, make it's new target the next waypoint
            if (Mathf.Abs(distanceX) <= 0.5f && Mathf.Abs(distanceZ) <= 0.5f)
            {
                //Debug.Log("here here");

                _waypointIndex++;


                if (_waypointIndex >= waypoints.Length)
                {
                    _playerOnRails = false;
                    _waypointIndex = 0;
                }
            }
            else
            {

                var railsMovement = moveDirection.normalized * (waypoints[_waypointIndex].GetComponent<Waypoint>().speedToWaypoint) * Time.deltaTime;
                myController.Move(railsMovement);
            }
        }
        else
        {
            _playerOnRails = false;
            _waypointIndex = 0;
        }

    }*/
}
