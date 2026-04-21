using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // When the player collides with the platform, set the player's parent to the platform so that it moves with the platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // When the player exits the collision with the platform, set the player's parent to null so that it no longer moves with the platform
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}