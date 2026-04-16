using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Get the position of the player
    [SerializeField] private Transform player;

    // Update the camera's position to follow the player every frame, while keeping the z-axis unchanged
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
