using UnityEngine;

public class UIHandler: MonoBehaviour
{
    public static UIHandler instance;

    [SerializeField]
    private GadgetUI gadgetUI;

    void Start()
    {
        instance = this;
        gadgetUI.enabled = false;

        SetCursorState();
    }

    public void OnUIKeyDown(bool affectTime = false)
    {
        gadgetUI.enabled = !gadgetUI.enabled;
        gadgetUI.SetGadgetActivity();

        //if gadgetUI is active, stop time
        //else, continue time
        if(affectTime)
        {
            Time.timeScale = (gadgetUI.enabled) ? 0 : 1;
        }

        SetCursorState();
    }

    public void ShowEndButton()
    {
        gadgetUI.enabled = true;
        SetCursorState();

        gadgetUI.ShowEndButtonOnly();
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