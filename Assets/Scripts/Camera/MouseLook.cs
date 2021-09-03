using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerTransform;
    private float xRotation = 0f;

    void Update()
    {
        if (playerTransform == null) //GameUIHandler.instance.isAnyUIActive()
            return;

        // for player's rotation(turn left-right)
        if(Input.GetAxis("Mouse X") != 0)
        {
            float mouseX = Input.GetAxis("Mouse X") * Settings.GetAnalogValue(AnalogValue.MouseSensivity);
            playerTransform.Rotate(Vector3.up * mouseX);
        }
        
        // for camera's rotation(turn up-down)
        if(Input.GetAxis("Mouse Y") != 0)
        {
            float mouseY = Input.GetAxis("Mouse Y") * Settings.GetAnalogValue(AnalogValue.MouseSensivity);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}