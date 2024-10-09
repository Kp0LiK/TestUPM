using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5.0f;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, smoothSpeed * Time.deltaTime);
        transform.LookAt(player);
    }
}