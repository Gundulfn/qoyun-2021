using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionController : MonoBehaviour
{
    private Interactable hitInteractable;
    private KeyCode interactionKey;
    
    [SerializeField]
    private TextMeshProUGUI interactionText;
    private CamRaycast camRaycast;

    void Start()
    {
        camRaycast = FindObjectOfType<CamRaycast>();
        interactionKey = Settings.GetKeyCode(KeybindAction.InteractionButton);
    }
    
    void Update()
    {
        if(camRaycast.isHit() && camRaycast.GetHitObj().GetComponent<Interactable>() != null)
        {
            hitInteractable = camRaycast.GetHitObj().GetComponent<Interactable>();
            
            string infoText = "";

            // if(hitInteractable.GetType() == typeof(Collectable))
            // {
            //     Item item = (hitInteractable as Collectable).GetItem();

            //     if(item != null)
            //     {
            //         infoText += "Press " + interactionKey.ToString() + " to collect " + item.GetName() + "[" + item.GetStackCount() + "]";
            //     } 
            // }
            // else if(hitInteractable.GetType() == typeof(MiningStation))
            // { 
            //     Item item = (hitInteractable as MiningStation).GetResource();
                
            //     if(item != null)
            //     {
            //         infoText += "Mining Station\nPress " + interactionKey.ToString() + " to collect " + item.GetName() + "[" + item.GetStackCount() + "]";
            //     }
            //     else
            //     {
            //         infoText += "No resource is found at this point";
            //     }

            //     infoText += "\nPress " + destroyConstructionKey.ToString() + " to destroy construction";               
            // }

            interactionText.SetText(infoText);
        }
        else
        {
            interactionText.SetText("");
        }
    }

    public void HandleInteraction()
    {
        if(camRaycast.GetHitObj() == null)
            return;

        Interactable interactable = camRaycast.GetHitObj().GetComponent<Interactable>();

        if(interactable != null && interactable.IsInteractable())
        {
            // if(interactable.GetType() == typeof(Collectable))
            // {
            //     (interactable as Collectable).Interact(inventory);
            // }
            // else if(interactable.GetType() == typeof(MiningStation))
            // {                
            //     (interactable as MiningStation).Interact(inventory);
            // }
        }
    }
}