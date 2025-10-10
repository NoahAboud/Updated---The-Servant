using UnityEngine;

public class CameraFollowKeyRotate : MonoBehaviour
{
    public Transform player;          // The player to follow
    public Vector3 offset = new Vector3(0, 5, -8);
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 50f; // How fast the camera rotates

    private float currentAngle = 0f;

    void LateUpdate()
    {
        if (player == null) return;

        // Handle camera rotation with keys (Q/E or Left/Right arrows)
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            currentAngle -= rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.RightArrow))
            currentAngle += rotationSpeed * Time.deltaTime;

        // Calculate rotation
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);

        // Apply rotation to offset
        Vector3 desiredPosition = player.position + rotation * offset;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Always look at the player
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}