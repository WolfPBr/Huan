using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;

    private Transform target;

    public void SetTarget(Transform player)
    {
        this.target = player;
        Vector3 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
        //transform.Rotate(Vector3.up, -90f);

        
    }

    void Update()
    {
          transform.Rotate(Vector3.right * 480f * Time.deltaTime, Space.Self);
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
