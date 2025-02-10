using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    private Transform target;

    public void SetTarget(Transform player)
    {
        target = player;
        Vector3 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
    }

    // private void OnTriggerEnter(Collider other)
    //  {
    //     if (other.CompareTag("Player"))
    //    {
    // Assume the player has a script with a TakeDamage method
    //       other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
    //       Destroy(gameObject);
    //  }
    //  }
}
