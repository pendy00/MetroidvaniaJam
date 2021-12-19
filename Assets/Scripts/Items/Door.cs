using UnityEngine;
public class Door : GameItemInterfaces.Interactable
{
    private Animator anim;
    public Transform target;
    public bool locked;
    private Vector3 target_position;
    private bool door_opened;
    private bool transiction_end;
    private const string opne_door = "open door";

    public Animator Anim { get => anim; set => anim = value; }
    public bool Door_opened { get => door_opened; set => door_opened = value; }
    public bool Transiction_end { get => transiction_end; set => transiction_end = value; }

    public Vector3 Target_position { get => target_position; set => target_position = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        target_position = new Vector3(target.position.x, target.position.y - 1, target.position.z);
        target = null;
    }

    public override void Action()
    {
        if (!locked)
        {
            anim.SetTrigger(opne_door);
            FindObjectOfType<DoorController>().StartCoroutine("DoorTransiction", (this));
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

    public void ResetControlValues()
    {
        door_opened = transiction_end = false;
    }
}