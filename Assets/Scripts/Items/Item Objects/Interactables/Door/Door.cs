using UnityEngine;

// manage level's doors
public class Door : Interactable
{
    
    public Transform target_door;   // exit door 
    public bool locked; // check if it is locked

    private Animator anim;
    private Vector3 target_position; // set player exit door spawning position with an offset
    private bool door_opened; // check if door is open in the animation timeline
    private bool transiction_end; // check if the player went through the door

    private const string opne_door = "open door"; // animator condition value

    public bool Door_opened { get => door_opened; set => door_opened = value; }
    public bool Transiction_end { get => transiction_end; set => transiction_end = value; }
    public Vector3 Target_position { get => target_position; set => target_position = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();

        target_position = new Vector3(target_door.position.x, target_door.position.y - 1, target_door.position.z); // set player spawn point offset
        target_door = null; // remove target door reference from memory to free some space

    }

    public override void Action()
    {
        // allow interaction if the door is not locked
        if (!locked)
        {
            anim.SetTrigger(opne_door);
            FindObjectOfType<DoorController>().StartCoroutine("DoorTransiction", (this)); // find door controller and allow player transiction
        }
    }

    public void DoorOpen()
    {
        door_opened = true;
    }

    public void TransictionEnd()
    {
        transiction_end = true;
    }

    // reset animation value to close the door and allow interaction again
    public void ResetControlValues()
    {
        door_opened = transiction_end = false;
    }
}