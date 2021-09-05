using UnityEngine;

public class MouseClick: MonoBehaviour
{
    [SerializeField]
    private GameObject teleportDevicePrefab, deviceLaunchPlaceObj;

    private GameObject spawnedTeleportDeviceObj;
    private Vector3 teleportPos;

    [SerializeField]
    private AudioClip throwSound, deviceTeleportSound;

    private SoundController soundController;

    void Start()
    {
        soundController = GetComponent<SoundController>();
    }

    public void ThrowTeleportDevice()
    {
        if(Teleportation.instance.canTeleport)
        {
            if(spawnedTeleportDeviceObj)
            {
                Destroy(spawnedTeleportDeviceObj);
            }

            soundController.PlayImmediately(throwSound);
            spawnedTeleportDeviceObj = Instantiate(teleportDevicePrefab, deviceLaunchPlaceObj.transform.position, deviceLaunchPlaceObj.transform.rotation);
        }
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

        soundController.PlayImmediately(deviceTeleportSound);
    }
}