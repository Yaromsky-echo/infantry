using UnityEngine;

public class SmoothPOVController : MonoBehaviour
{
    public Transform playerTransform;   // The player's transform to follow
    public float mouseSensitivity = 2.0f;   // Sensitivity of the mouse input
    public float smoothTime = 0.1f;   // Smoothing factor for the rotation
    public Vector2 pitchMinMaxX = new Vector2(0, 0);   // Min and Max pitch (horizantol angle)
    public Vector2 pitchMinMaxY = new Vector2(-60, 60);   // Min and Max pitch (vertical angle)

    private Vector2 currentRotation;   // Current rotation angles
    private Vector2 rotationVelocity;   // Current rotation velocity (for smoothing)

    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Calculate target rotation
        currentRotation.x += mouseX;
        currentRotation.x = Mathf.Clamp(currentRotation.y, pitchMinMaxX.x, pitchMinMaxX.y);
        currentRotation.y -= mouseY;
        currentRotation.y = Mathf.Clamp(currentRotation.y, pitchMinMaxY.x, pitchMinMaxY.y);

        // Smoothly interpolate rotation
        Vector2 targetRotation = new Vector2(currentRotation.x, currentRotation.y);
        Vector2 smoothRotation = Vector2.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, smoothTime);

        // Apply rotation to camera
        transform.localRotation = Quaternion.Euler(smoothRotation.y, smoothRotation.x, 0);

        // Update position to follow player
        Vector3 targetPosition = playerTransform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothTime);
    }
}
