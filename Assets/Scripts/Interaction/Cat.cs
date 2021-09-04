using UnityEngine;

public class Cat: MonoBehaviour, Interactable
{
    private bool isCatDead;
    private int connectedGateNo;

    public void SetCatStatus(bool isCatDead, int connectedGateNo)
    {
        this.isCatDead = isCatDead;
        this.connectedGateNo = connectedGateNo;

        // Set model depending to "isCatDead"
    }

    public void Interact(object obj = null)
    {
        if(isCatDead)
        {
            //Scan
            Debug.Log("Connected to Gate " + connectedGateNo);
        }
        else
        {
            GameProgress.instance.IncreaseSavedCatCount();
            
            // add meow sound later 
            Destroy(gameObject);
        }
    }
    
    public bool IsInteractable()
    {
        return true;
    }

    public string GetInteractableText()
    {
        if(isCatDead)
        {
            return InteractableText.deadCatText;
        }
        else
        {
            return InteractableText.aliveCatText;
        }
    }
}