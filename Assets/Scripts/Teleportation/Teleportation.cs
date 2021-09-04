using UnityEngine;

public class Teleportation: MonoBehaviour
{
    public static Teleportation instance;
    private bool isTeleportAllowed = true;

    void Start()
    {
        instance = this;
    }

    public void TeleportToLocation(Vector3 pos, Transform teleporter)
    {
        if(isTeleportAllowed)
        {
            teleporter.position = pos;
        }
    }

    public void DisableTeleport()
    {
        isTeleportAllowed = false;
    }
}