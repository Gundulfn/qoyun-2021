using UnityEngine;

public class Player : MonoBehaviour
{    
    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        characterController = GetComponent<CharacterController>();
    }

    public void Die()
    {

    }

    private void SetPlayerScriptsActivity()
    {
        // playerMovement.enabled = !GameUIHandler.instance.isAnyUIActive();
        // characterController.enabled = !GameUIHandler.instance.isAnyUnClosableUIActive();
        // playerInput.enabled = !GameUIHandler.instance.isAnyUnClosableUIActive();
    }
}