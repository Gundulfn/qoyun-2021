using UnityEngine;

public class Box : MonoBehaviour, Interactable
{
    private GameObject catObj;
    private Animation anim;

    private SoundController soundController;

    void Start()
    {
        catObj = transform.GetChild(0).gameObject;
        catObj.SetActive(false);

        anim = GetComponent<Animation>();
        soundController = GetComponent<SoundController>();
    }

    public void Interact(object obj = null)
    {
        anim.Play();
        soundController.Play();
        
        catObj.SetActive(true);
        catObj.transform.parent = null;
    }

    public bool IsInteractable()
    {
        return true;
    }

    public string GetInteractableText()
    {
        return InteractableText.boxText;
    }
}