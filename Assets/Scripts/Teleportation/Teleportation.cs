using UnityEngine;

public class Teleportation: MonoBehaviour
{
    public static Teleportation instance;
    
    public bool canTeleport
    {
        get;
        private set;
    }

    private Animation teleportEffectAnim;

    private Transform teleporter;
    private Vector3 pos;

    void Start()
    {
        instance = this;
        teleportEffectAnim = GetComponent<Animation>();
        canTeleport = true;
    }

    public void TeleportToLocation(Vector3 pos, Transform teleporter)
    {
        if(canTeleport)
        {
            teleportEffectAnim.Play();
            this.teleporter = teleporter;
            this.pos = pos;

            DisableTeleport();
        }
    }
    
    public void Teleport()
    {
        teleporter.position = pos;
    }

    public void AllowTeleport()
    {
        canTeleport = true;
    }

    public void DisableTeleport()
    {
        canTeleport = false;
    }
}