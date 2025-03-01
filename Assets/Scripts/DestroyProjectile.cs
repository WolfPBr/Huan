using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem dieParticles;

    private ParticleSystem dieParticlesInstance;


    private void dieParticlesFunction()
    {
        dieParticlesInstance = Instantiate(dieParticles, transform.position, Quaternion.Euler(-90f, 0f, 0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        dieParticlesFunction();
        Debug.Log("Collided with: " + collision.gameObject.name);
        Destroy(GameObject);
    }
}
