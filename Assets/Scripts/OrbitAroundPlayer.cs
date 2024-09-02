using UnityEngine;

public class OrbitAroundMouse : MonoBehaviour
{
    [SerializeField] private Transform playerTransform = null; // The player around which the camera will orbit
    [SerializeField] private float sensitivity = 10.0f; // Sensitivity of the mouse movement
    [SerializeField] private float smoothTime = 0.1f; // Smoothing time for camera rotation
    [SerializeField] private float distance = 10.0f; // Distance from the player

    private Vector3 currentRotation = Vector3.zero; // The current rotation of the camera
    private Vector3 rotationVelocity = Vector3.zero; // Velocity used by SmoothDamp

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        // Calculate target rotation
        Vector3 targetRotation = currentRotation + new Vector3(0.0f, mouseX, 0.0f);

        // Smoothly interpolate rotation
        currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, smoothTime);

        // Apply the rotation to the camera
        transform.eulerAngles = currentRotation;

        // Update the position based on distance from the player
        transform.position = playerTransform.position - transform.forward * distance;
    }
}
