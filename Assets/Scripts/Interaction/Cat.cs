using UnityEngine;

public class Cat: MonoBehaviour, Interactable
{
    [SerializeField]
    private GameObject aliveCatModel, deadCatModel;
    
    private bool isCatDead;
    private int connectedGateNo;

    public void SetCatStatus(bool isCatDead, int connectedGateNo)
    {
        this.isCatDead = isCatDead;
        this.connectedGateNo = connectedGateNo;

        aliveCatModel.SetActive(!isCatDead);
        deadCatModel.SetActive(isCatDead);
    }

    public void Interact(object obj = null)
    {
        if(isCatDead)
        {
            Scan.info = connectedGateNo;
            UIHandler.instance.SetScanText();
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