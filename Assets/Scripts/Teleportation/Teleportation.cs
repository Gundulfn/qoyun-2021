using UnityEngine;

public class Teleportation: MonoBehaviour
{
    public static Teleportation instance;

    void Start()
    {
        instance = this;
    }

    public void TeleportToLocation(Vector3 pos, Transform teleporter)
    {
        teleporter.position = pos;
    }
}