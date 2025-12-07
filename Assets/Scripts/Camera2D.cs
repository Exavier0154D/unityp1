using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform targetPlayer;
    public float offsetX = 6f;
    public float offsetY = 0f;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (targetPlayer == null) return;

        Vector3 desiredPosition = new Vector3(
            targetPlayer.position.x + offsetX,
            targetPlayer.position.y + offsetY,
            -10f
        );

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
