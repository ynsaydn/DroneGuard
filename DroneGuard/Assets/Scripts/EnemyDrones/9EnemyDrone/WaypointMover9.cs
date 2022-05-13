using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover9 : MonoBehaviour
{

    [SerializeField] private Waypoints9 wayPoints;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;


    // Start is called before the first frame update
    void Start()
    {
        // ilk way point birincil point olarak alma
        currentWaypoint = wayPoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        // sıradaki pointi seçme
        currentWaypoint = wayPoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            moveSpeed = 0.1f;
        }
        
        if(Input.GetButtonUp("Jump"))
        
        {
            moveSpeed = 5f;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position,moveSpeed* Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold) 
        {
           currentWaypoint = wayPoints.GetNextWaypoint(currentWaypoint);
        }
    }
}
