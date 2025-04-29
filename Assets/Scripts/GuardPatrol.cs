using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GuardPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float patrolSpeed = 2.0f;

    private Transform currentWaypoint;
    private int currentWaypointIndex;
    private float pauseDuration = 2.0f;

    void Start()
    {
        // Start by moving towards a random waypoint.
        currentWaypointIndex = Random.Range(0, waypoints.Length);
        currentWaypoint = waypoints[currentWaypointIndex];
    }

    void Update()
    {
        // Check if the guard has reached the current waypoint.
        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            // Pause for a moment at each waypoint.
            StartCoroutine(PauseAtWaypoint(pauseDuration));

            // Change the current waypoint to a random one.
            int newWaypointIndex;
            do
            {
                newWaypointIndex = Random.Range(0, waypoints.Length);
            } while (newWaypointIndex == currentWaypointIndex);

            currentWaypointIndex = newWaypointIndex;
            currentWaypoint = waypoints[currentWaypointIndex];
        }

        // Move the guard towards the current waypoint.
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, patrolSpeed * Time.deltaTime);
    }

    IEnumerator PauseAtWaypoint(float duration)
    {
        // Pause for a specified duration at each waypoint.
        yield return new WaitForSeconds(duration);
    }
}
