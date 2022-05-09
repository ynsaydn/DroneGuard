using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;


    private void  OnDrawGizmos() 
    {
        foreach(Transform t in transform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.blue;
        for (int i = 0; i< transform.childCount - 1; i++ )
        {
            Gizmos.DrawLine (transform.GetChild(i).position,transform.GetChild(i+1).position);
        }
        //Son move point ile ilk move point bağlanır.
        Gizmos.DrawLine(transform.GetChild(transform.childCount -1 ).position, transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        return null; 
    }
}
