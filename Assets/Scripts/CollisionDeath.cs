using UnityEngine;

public class CollisionDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            other.GetComponent<Player>().Die();
        }
    }
}
