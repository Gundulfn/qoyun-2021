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
        if(this.enabled)
        {
            anim[anim.clip.name].speed = -1;
            anim [anim.clip.name].time = anim [anim.clip.name].length;
            anim.Play();

            this.enabled = false;
        }
        else
        {
            this.enabled = true;
            anim[anim.clip.name].speed = 1;
            anim.Play();
        }
    }

    public void ShowEndButtonOnly()
    {

    }
}