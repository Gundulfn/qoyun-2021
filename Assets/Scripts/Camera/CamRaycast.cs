using UnityEngine;

public class CamRaycast : MonoBehaviour
{
    private RaycastHit hit;

    private float rayDistance = 5;
    public LayerMask layerMask = 1 << 1; 

    private Vector3 hitPos;
    private GameObject currentHit;

    public bool isHit()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, layerMask, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public GameObject GetHitObj()
    {
        return hit.collider.gameObject;
    }
}