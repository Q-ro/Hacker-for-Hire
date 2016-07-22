using UnityEngine;
using System.Collections;

public class LockedDoors : MonoBehaviour {


    public int LocksToOpen = 1;
    public float SpeedToOpen = 1.0f;
    public GameObject MoveAfterOpen;
    public bool IsOpen = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(LocksToOpen <1)
        {
            IsOpen = true;

            this.transform.position = MoveAfterOpen.transform.position;
        }
    }

    public void RemoveLock()
    {
        LocksToOpen--;
    }
}
