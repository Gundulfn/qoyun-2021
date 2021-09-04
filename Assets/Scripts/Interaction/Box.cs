using UnityEngine;

public class Box : MonoBehaviour, Interactable
{
    [SerializeField]
    private GameObject catObj;

    public void Interact(object obj = null)
    {
        catObj.SetActive(true);
        catObj.transform.parent = null;
        
        Destroy(gameObject);
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