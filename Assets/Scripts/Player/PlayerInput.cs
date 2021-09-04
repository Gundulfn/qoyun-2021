using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    
    private const float ROTATION_SENSIVITY = 10f;
    private float mouseWheelRotation;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if(Input.GetKeyDown(Settings.GetKeyCode(KeybindAction.GadgetUIButton)))
        {
            UIHandler.instance.OnGadgetUIKeyDown();
        }

        if (UIHandler.instance.isGadgetActive())
        {
            player.PausePlayer();
            return;
        }
        else
        {
            player.UnpausePlayer();
        }
        
        // In-game inputs
        if (Input.mouseScrollDelta.y != 0)
        {
            mouseWheelRotation += Input.mouseScrollDelta.y * ROTATION_SENSIVITY;
        }

        if (player.camRaycast.isHit())
        {
            if (Input.GetKeyDown(Settings.GetKeyCode(KeybindAction.Interact)))
            {
                player.interactionController.HandleInteraction();
            }
        }

        HandleMovement();
        HandleMouseClicks();
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

        player.playerMovement.Move(x, z);

        if (jump)
        {
            player.playerMovement.Jump();
        }
    }

    private void HandleMouseClicks()
    {
        if(Input.GetKeyDown(Settings.GetKeyCode(KeybindAction.ThrowTeleportDevice))) // Left click
        {
            player.mouseClick.ThrowTeleportDevice();
        }
        else if(Input.GetKeyDown(Settings.GetKeyCode(KeybindAction.TeleportToDevice))) // Right click
        {
            player.mouseClick.TeleportToDevice();
        }
    }
}