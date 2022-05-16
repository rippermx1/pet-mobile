using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Character character;
    private GameObject waypointsPlayerLeft;
    private GameObject waypointsPlayerRight;
    private GameObject waypointsIALeft;
    private GameObject waypointsIARight;

    private void Awake()
    {
        waypointsPlayerLeft = GameObject.FindGameObjectWithTag("WaypointsPlayerLeft");
        waypointsPlayerRight = GameObject.FindGameObjectWithTag("WaypointsPlayerRight");
        waypointsIALeft = GameObject.FindGameObjectWithTag("WaypointsIALeft");
        waypointsIARight = GameObject.FindGameObjectWithTag("WaypointsIARight");

        if (gameObject.GetComponent<WaypointMover>().waypoints == null)
        {
            /* Player Section */
            if (GroundController.instance.waypointToUse != null && GroundController.instance.waypointToUse.Equals("WaypointsPlayerLeft"))
            {
                gameObject.GetComponent<WaypointMover>().waypoints = waypointsPlayerLeft.GetComponent<Waypoints>();
            }
            if (GroundController.instance.waypointToUse != null && GroundController.instance.waypointToUse.Equals("WaypointsPlayerRight"))
            {
                gameObject.GetComponent<WaypointMover>().waypoints = waypointsPlayerRight.GetComponent<Waypoints>();
            }
            /* IA Section */
            if (GroundController.instance.waypointToUse != null && GroundController.instance.waypointToUse.Equals("WaypointsIALeft"))
            {
                gameObject.GetComponent<WaypointMover>().waypoints = waypointsIALeft.GetComponent<Waypoints>();
            }
            if (GroundController.instance.waypointToUse != null && GroundController.instance.waypointToUse.Equals("WaypointsIARight"))
            {
                gameObject.GetComponent<WaypointMover>().waypoints = waypointsIARight.GetComponent<Waypoints>();
            }
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
