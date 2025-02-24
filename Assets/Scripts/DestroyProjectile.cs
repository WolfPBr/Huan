using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        Destroy(GameObject);
    }
}
