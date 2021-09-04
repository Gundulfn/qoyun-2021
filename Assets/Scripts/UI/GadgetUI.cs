using UnityEngine;

public class GadgetUI: MonoBehaviour
{
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void SetGadgetActivity()
    {
        //this.enabled = !this.enabled;
    }

    public void ShowEndButtonOnly()
    {
        
    }
}