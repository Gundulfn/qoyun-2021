using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Player scripts for using actions according to inputs
    private PlayerMovement playerMovement;
    private CamRaycast camRaycast;
    private InteractionController interactionController;

    private const float ROTATION_SENSIVITY = 10f;

    private float mouseWheelRotation;
    private bool clickAgainToUseTool;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        camRaycast = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamRaycast>();
        interactionController = GetComponent<InteractionController>();
    }

    void Update()
    {
        // if (GameUIHandler.instance.isAnyUIActive())
        //     return;

        // In-game inputs
        if (Input.mouseScrollDelta.y != 0)
        {
            mouseWheelRotation += Input.mouseScrollDelta.y * ROTATION_SENSIVITY;
        }

        if (camRaycast.isHit())
        {
            if (Input.GetKeyDown(Settings.GetKeyCode(KeybindAction.InteractionButton)))
            {
                interactionController.HandleInteraction();
            }
        }

        HandleMovement();
    }

    private void HandleMovement()
    {
        float x = 0;
        float z = 0;

        // Forward-Backward directions
        if (Input.GetKey(Settings.GetKeyCode(KeybindAction.MoveForward)))
        {
            z++;
        }
        else if (Input.GetKey(Settings.GetKeyCode(KeybindAction.MoveBackward)))
        {
            z--;
        }

        // Left-Right directions
        if (Input.GetKey(Settings.GetKeyCode(KeybindAction.MoveRight)))
        {
            x++;
        }
        else if (Input.GetKey(Settings.GetKeyCode(KeybindAction.MoveLeft)))
        {
            x--;
        }

        bool jump = Input.GetKeyDown(Settings.GetKeyCode(KeybindAction.Jump));

        playerMovement.Move(x, z);

        if (jump)
        {
            playerMovement.Jump();
        }
    }
}