using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{

    [SerializeField] private WayPoints wayPoints;

    [SerializeField] private float moveSpeed = 5f;

    private Transform currentWaypoint;


    // Start is called before the first frame update
    void Start()
    {
        // ilk way point birincil point olarak alma
        currentWaypoint = wayPoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
