using UnityEngine;

public class GadgetUI: MonoBehaviour
{
    [SerializeField]
    private GameObject uiObj, gateButtonsPanel, endButtonPanel;
    
    [SerializeField]
    private Scan scan;
    private bool activateScan;

    private Animation anim;

    private GameObject[] panels = new GameObject[3];

    void Start()
    {
        anim = GetComponent<Animation>();
        
        panels[0] = gateButtonsPanel;
        panels[1] = endButtonPanel;
        panels[2] = scan.gameObject;
    }

    public void SetGadgetActivity()
    {
        if(this.enabled)
        {
            anim[anim.clip.name].speed = -1;
            anim[anim.clip.name].time = anim[anim.clip.name].length;
            anim.Play();
        }
        else
        {
            this.enabled = true;
            anim[anim.clip.name].speed = 1;
            anim.Play();
        }
    }

    //Panel functions
    public void ShowEndButton()
    {
        ClosePanels();
        endButtonPanel.SetActive(true);
    }

    public void ShowGateButtons()
    {
        ClosePanels();
        gateButtonsPanel.SetActive(true);
    }

    public void ShowScanText()
    {
        ClosePanels();
        scan.gameObject.SetActive(true);
        activateScan = true;
    }

    private void ClosePanels()
    {
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    //This function is used by Animation
    public void SetUIActivity()
    {
        if(anim[anim.clip.name].speed == 1)
        {
            uiObj.SetActive(true);
            this.enabled = true;
        }
        else
        {
            uiObj.SetActive(false);
            this.enabled = false;
        }

        UIHandler.instance.SetCursorState(this.enabled);

        if(activateScan)
        {
            StartCoroutine(scan.WriteScanResult());
            activateScan = false;
        }
    }

}