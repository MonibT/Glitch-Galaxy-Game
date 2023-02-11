using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    public GameObject[] waypoints;
    private int currentwaypointIndex = 0;

    public float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentwaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentwaypointIndex++;
            if (currentwaypointIndex >= waypoints.Length)
            {
                currentwaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentwaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
