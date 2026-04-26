using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int currentWaypointIndex = 0;

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // If the distance between the current waypoint and the object is less than 0.1, then move to the next waypoint
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        FlipEnemyDirection();
    }

    // Flip the enemy's sprite based on the direction it is moving towards the current waypoint
    // If the enemy is moving towards the right (current waypoint's x position is greater than the enemy's x position), then flipX is set to false (facing right)
    private void FlipEnemyDirection()
    {
        if (CompareTag("Enemy") && waypoints[currentWaypointIndex].transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (CompareTag("Enemy") && waypoints[currentWaypointIndex].transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }
}
