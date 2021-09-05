using UnityEngine;
using System.Collections;

public class Teleportation: MonoBehaviour
{
    public static Teleportation instance;
    private bool cutEffectAnim;

    public bool canTeleport
    {
        get;
        private set;
    }

    private Animation teleportEffectAnim;

    private Transform teleporter;
    private Vector3 pos;
    private UniverseCode universeCode;

    private AudioSource aud;

    [SerializeField]
    private Sunlight sunLight;

    [SerializeField]
    private AudioClip teleportSound;

    void Start()
    {
        instance = this;
        teleportEffectAnim = GetComponent<Animation>();
        aud = GetComponent<AudioSource>();

        canTeleport = true;

    }

    public void TeleportToLocation(Vector3 pos, Transform teleporter, UniverseCode universeCode = UniverseCode.None)
    {
        if(canTeleport)
        {         
            teleportEffectAnim.Play();

            // Saving for late teleport, look "Teleport" function 
            this.teleporter = teleporter;
            this.pos = pos;
            this.universeCode = universeCode;

            aud.clip = teleportSound;
            aud.Play();

            DisableTeleport();
        }
    }
    
    public void TeleportToHome()
    {
        teleportEffectAnim.Play();
        cutEffectAnim = true;
    }

    // "TeleportEffect" Animation Functions
    // To teleport after flashing effect at Animation
    public void Teleport()
    {
        if(cutEffectAnim)
        {
            teleportEffectAnim[teleportEffectAnim.clip.name].speed = 0;

            StartCoroutine(GameController.instance.PassToCreditsScene());
        }
        else
        {
            teleporter.position = pos;

            if(universeCode != UniverseCode.None)
            {
                sunLight.ChangeLightColor(universeCode);
            }
        }
    }

    public void AllowTeleport()
    {
        canTeleport = true;
    }

    public void DisableTeleport()
    {
        canTeleport = false;
    }
}