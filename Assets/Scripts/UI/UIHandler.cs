using UnityEngine;

public class UIHandler: MonoBehaviour
{
    public static UIHandler instance;
    public GameObject crosshairObj;

    [SerializeField]
    private GadgetUI gadgetUI;

    void Start()
    {
        instance = this;
        gadgetUI.enabled = false;

        SetCursorState(false);
    }

    public void OnGadgetUIKeyDown()
    {
        gadgetUI.SetGadgetActivity();
    }

    public void SetScanText()
    {
        OnGadgetUIKeyDown();
        gadgetUI.ShowScanText();
    }

    public void NotifyGameEnd()
    {
        OnGadgetUIKeyDown();
        gadgetUI.ShowEndButton();
    }

    public bool isGadgetActive()
    {
        return gadgetUI.enabled;
    }

    public void SetCursorState(bool isUIActive)
    {
        Cursor.visible = isUIActive;
        crosshairObj.SetActive(!isUIActive);

        if (Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}