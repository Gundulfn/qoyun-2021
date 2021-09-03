using UnityEngine;

public class UIHandler: MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // private void SetCursorState()
    // {
    //     Cursor.visible = isAnyUIActive();

    //     if (Cursor.visible)
    //     {
    //         Cursor.lockState = CursorLockMode.None;
    //     }
    //     else
    //     {
    //         Cursor.lockState = CursorLockMode.Locked;
    //     }
    // }
}