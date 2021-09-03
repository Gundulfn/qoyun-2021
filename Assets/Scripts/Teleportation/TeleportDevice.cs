using UnityEngine;

public class TeleportDevice : MonoBehaviour
{
    private Rigidbody rb;
    private const float THROW_FORCE = 500f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * THROW_FORCE);
    }

    public void DestroyDevice()
    {
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 2);
    }
}