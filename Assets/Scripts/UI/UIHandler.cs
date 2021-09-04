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

        SetCursorState();
    }

    public void OnGadgetUIKeyDown()
    {
        gadgetUI.SetGadgetActivity();
        crosshairObj.SetActive(!gadgetUI.enabled);

        SetCursorState();
    }

    public void OnMenuUIKeyDown()
    {
        OnGadgetUIKeyDown();
        //open menuUi from gadgetUI
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

    private void SetCursorState()
    {
        Cursor.visible = gadgetUI.enabled;

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