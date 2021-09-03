using UnityEngine;

public class Collectable : MonoBehaviour, Interactable
{
    public void Interact(object obj = null)
    {

    }

    public bool IsInteractable()
    {
        return true;
    }
}