using UnityEngine;

public class Player : MonoBehaviour
{    
    public CharacterController characterController
    {
        get;
        private set;
    }

    public PlayerMovement playerMovement
    {
        get;
        private set;
    }

    public PlayerInput playerInput
    {
        get;
        private set;
    }

    public CamRaycast camRaycast
    {
        get;
        private set;
    }

    public InteractionController interactionController
    {
        get;
        private set;
    }

    public MouseClick mouseClick
    {
        get;
        private set;
    }

    public MouseLook mouseLook
    {
        get;
        private set;
    }

    [SerializeField]
    private Animation deathAnim;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        characterController = GetComponent<CharacterController>();
        interactionController = GetComponent<InteractionController>();
        mouseClick = GetComponent<MouseClick>();

        GameObject mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        mouseLook = mainCameraObj.GetComponent<MouseLook>();
        camRaycast = mainCameraObj.GetComponent<CamRaycast>();
    }

    public void Die()
    {
        DisablePlayer();
        
        GameController.instance.MuteAllAudios();
        
        deathAnim.gameObject.SetActive(true);
        StartCoroutine(GameController.instance.RestartGame(deathAnim[deathAnim.clip.name].length));
    }

    public void DisablePlayer()
    {
        PausePlayer();
        playerInput.enabled = false;
        characterController.enabled = false;
        playerMovement.enabled = false;
    }

    // Pause/Unpause player movement and interaction
    public void PausePlayer()
    {
        interactionController.enabled = false;
        mouseLook.enabled = false;
    }

    public void UnpausePlayer()
    {
        interactionController.enabled = true;
        mouseLook.enabled = true;
    }
}