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
        interactionKey = Settings.GetKeyCode(KeybindAction.Interact);
    }
    
    void Update()
    {
        if(camRaycast.isHit() && camRaycast.GetHitObj().GetComponent<Interactable>() != null)
        {
            hitInteractable = camRaycast.GetHitObj().GetComponent<Interactable>();
            
            string infoText = "Press " + interactionKey.ToString() + " " + hitInteractable.GetInteractableText();
            interactionText.SetText(infoText);
        }
        else
        {
            interactionText.SetText("");
        }
    }

    public void HandleInteraction()
    {
        if(camRaycast.GetHitObj() != null)
        {
            Interactable interactable = camRaycast.GetHitObj().GetComponent<Interactable>();

            if(interactable != null && interactable.IsInteractable())
            {
                interactable.Interact();
            }
        }
    }
}