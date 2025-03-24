using UnityEngine;
using UnityEngine.InputSystem; // For input handling
using UnityEngine.XR.Interaction.Toolkit;

public class ShootObjectOnButtonPress : MonoBehaviour
{
    // The object prefab to shoot
    public GameObject objectToShoot;

    // The transform from which the object will be shot
    public Transform shootFromTransform;

    // The force with which the object will be shot
    public float shootForce = 10f;

    // The input action that triggers the shooting (this can be mapped in Unity's Input System)
    public InputActionProperty shootButtonAction;

    private void OnEnable()
    {
        // Enable the input action
        shootButtonAction.action.Enable();
    }

    private void OnDisable()
    {
        // Disable the input action
        shootButtonAction.action.Disable();
    }

    private void Update()
    {
        // Check if the button is pressed
        if (shootButtonAction.action.triggered)
        {
            ShootObject();
        }
    }

    private void ShootObject()
    {
        if (objectToShoot && shootFromTransform)
        {
            // Instantiate the object to shoot at the specified transform
            GameObject projectile = Instantiate(objectToShoot, shootFromTransform.position, shootFromTransform.rotation);

            // Add force to the projectile to make it move (e.g., shoot it forward)
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(shootFromTransform.forward * shootForce, ForceMode.VelocityChange);
            }

            // Optional: Destroy the object after a short delay to avoid clutter
            Destroy(projectile, 5f); // Destroy after 5 seconds
        }
    }
}