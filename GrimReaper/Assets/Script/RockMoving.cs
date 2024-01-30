using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RockMoving : MonoBehaviour
{
    private List<Transform> waypoints;
    private int currentTargetIndex = 0;
    private bool isWaiting = false;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new List<Transform>();

        // Create waypoints and add them to the list
        Transform waypoint1 = new GameObject("Waypoint1").transform;
        waypoint1.position = new Vector3(150f, 44f, 0f);
        waypoints.Add(waypoint1);

        Transform waypoint2 = new GameObject("Waypoint2").transform;
        waypoint2.position = new Vector3(104f, 44f, 0f);
        waypoints.Add(waypoint2);

        // Set the initial position of the object
        transform.position = waypoints[currentTargetIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        if (currentTargetIndex < waypoints.Count)
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTargetIndex].position, speed);

            // Check if the object has reached the waypoint
            if (Vector3.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.1f)
            {
                // Switch to the next waypoint
                currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count;

                // Start the coroutine to freeze the object for 2 seconds
                StartCoroutine(FreezeForSeconds(2f));
            }
        }

        if (transform.GetChild(0) != null)
        {        
            transform.GetChild(0).position = new Vector3(transform.position.x, transform.GetChild(0).position.y, transform.GetChild(0).position.z);
        }
    }

    IEnumerator FreezeForSeconds(float seconds)
    {
        isWaiting = true;
        yield return new WaitForSeconds(seconds);
        isWaiting = false;
    }
}
