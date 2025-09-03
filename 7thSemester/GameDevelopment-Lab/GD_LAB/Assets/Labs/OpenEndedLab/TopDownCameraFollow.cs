using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{
    public Transform target;  // Assign the player here in the Inspector
    public Vector3 offset = new Vector3(0, 10, 0); // Fixed height above the player
    public float smoothSpeed = 5f; // Adjust for smoother camera movement

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPosition = target.position + offset;
        
        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Ensure camera always looks downward
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
