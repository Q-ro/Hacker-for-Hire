using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

    // public variables
    public float moveSpeed = 3.0f;
    public float gravity = 9.81f;
    public bool _playerOnRails = false;

    Vector3 movementZ;
    Vector3 movementX;

    public GameObject[] waypoints;
    int _waypointIndex = 0;
    Transform _transform;
    Rigidbody _rigidbody;

    private CharacterController myController;

    // Use this for initialization
    void Start()
    {
        _transform = GetComponent<Transform>();
        //_rigidbody = GetComponent<Rigidbody>();

        // store a reference to the CharacterController component on this gameObject
        // it is much more efficient to use GetComponent() once in Start and store
        // the result rather than continually use etComponent() in the Update function
        myController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerOnRails)
        {
            // Determine how much should move in the z-direction
            movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

            // Determine how much should move in the x-direction
            movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

            // Convert combined Vector3 from local space to world space based on the position of the current gameobject (player)
            Vector3 movement = transform.TransformDirection(movementZ + movementX);

            // Apply gravity (so the object will fall if not grounded)
            movement.y -= gravity * Time.deltaTime;

            //Debug.Log ("Movement Vector = " + movement);

            // Actually move the character controller in the movement direction
            myController.Move(movement);
        }

        else
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
                //var distanceY = waypoints[_waypointIndex].transform.position.y - _transform.position.y;

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


        }
    }
}
