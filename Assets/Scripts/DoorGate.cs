using UnityEngine;
using System.Collections;

public class DoorGate : MonoBehaviour {
    public GameObject TrapDoor;
    //public GameObject KeyDoor;
    public GameObject Trap;
    public float WaitforActivation = 0.5f;
    public GameObject MoveAfterClosed;
    public GameObject PreviousRailway;
    public GameObject Checkpoint;

    //Vector3 _position;

    //Transform _transform;

    void Awake()
    {
        // get a reference to the components we are going to be changing and store a reference for efficiency purposes
        //_transform = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.gm.SetCheckpoint(Checkpoint);

            if (PreviousRailway != null)
                PreviousRailway.SetActive(false);

            //Debug.Log("im hit");
            if(TrapDoor != null)
            {
                //Debug.Log("here" + TrapDoor.transform.position.x + ", " + _transform.position.y + ", " + TrapDoor.transform.position.z);
                
               // _position = new Vector3(TrapDoor.transform.position.x, 9, TrapDoor.transform.position.z);
                Invoke("WaitToSetTrap", WaitforActivation);
                
 
            }
        }

    }

    void WaitToSetTrap()
    {
        TrapDoor.transform.position = MoveAfterClosed.transform.position;
        //Set the trap
        if (Trap != null)
        {
            Trap.SetActive(true);
            
        }
        KillSelf();
    }

    public void KillSelf()
    {
        Destroy(gameObject);
    }
}
