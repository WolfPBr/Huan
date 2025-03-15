using UnityEngine;

public class SphereLauncher : MonoBehaviour
{
    public GameObject cloneSpherePrefab;  // The prefab for the sphere (to be assigned in the Inspector)
    public float launchForce = 10f;      // The force with which the sphere is launched
    public float despawnTime = 5f;       // The time (in seconds) after which the sphere will despawn

    private Camera mainCamera;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            LaunchSphere();
        }
    }

    void LaunchSphere()
    {
        // Get the mouse position in the world
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // We don't need the exact hit point for the direction, so we just cast a ray
        if (Physics.Raycast(ray, out hit))
        {
            // Create the clone sphere at the camera's position
            GameObject clonedSphere = Instantiate(cloneSpherePrefab, mainCamera.transform.position, Quaternion.identity);

            // Calculate the direction from the camera to the mouse's position
            Vector3 direction = (hit.point - mainCamera.transform.position).normalized;

            // Get the Rigidbody component of the cloned sphere
            Rigidbody rb = clonedSphere.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply a force in the direction of the mouse
                rb.AddForce(direction * launchForce, ForceMode.VelocityChange);
            }

            // Destroy the cloned sphere after the specified despawn time
            Destroy(clonedSphere, despawnTime);
        }
    }
}
