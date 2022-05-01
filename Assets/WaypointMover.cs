using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    void Start()
    {
        updateWaypoint();
        transform.position = currentWaypoint.position;

        updateWaypoint();
        lookAtWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, distance);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold) {
            updateWaypoint();
            lookAtWaypoint();
        }
    }

    private void updateWaypoint() {
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    private void lookAtWaypoint()
    {
        transform.LookAt(currentWaypoint);
    }
}
