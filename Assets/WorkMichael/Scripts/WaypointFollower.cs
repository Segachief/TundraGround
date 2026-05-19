using UnityEngine;

public class WaypointFollower : MonoBehaviour // Script by Michael Arthur
{
    [SerializeField] private GameObject[] waypoints; // Array of waypoints for the object to follow
    private int currentWaypointIndex = 0; // Index to track the current waypoint


    [SerializeField] private float speed = 2f; // Speed at which the object moves towards the waypoints

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) // Check if the object is close enough to the current waypoint
        {
            currentWaypointIndex++; // Move to the next waypoint
            if (currentWaypointIndex >= waypoints.Length) // If the index exceeds the number of waypoints reset to the first waypoint
            {
                currentWaypointIndex = 0; // Reset to the first waypoint
            }   
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); // Move the object towards the current waypoint at the specified speed
    }
}
