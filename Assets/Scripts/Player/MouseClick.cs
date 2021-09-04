using UnityEngine;

public class MouseClick: MonoBehaviour
{
    [SerializeField]
    private GameObject teleportDevicePrefab, deviceLaunchPlaceObj;

    private GameObject spawnedTeleportDeviceObj;
    private Vector3 teleportPos;

    public void ThrowTeleportDevice()
    {
        if(spawnedTeleportDeviceObj)
        {
            Destroy(spawnedTeleportDeviceObj);
        }

        spawnedTeleportDeviceObj = Instantiate(teleportDevicePrefab, deviceLaunchPlaceObj.transform.position, deviceLaunchPlaceObj.transform.rotation);
    }

    public void TeleportToDevice()
    {
        if(spawnedTeleportDeviceObj)
        {
            teleportPos = spawnedTeleportDeviceObj.transform.position + Vector3.up;
            Teleportation.instance.TeleportToLocation(teleportPos, transform);
            
            spawnedTeleportDeviceObj.GetComponent<TeleportDevice>().DestroyDevice();
            spawnedTeleportDeviceObj = null;
        }
    }
}