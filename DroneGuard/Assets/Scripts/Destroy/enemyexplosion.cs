using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyexplosion : MonoBehaviour
{


    public ParticleSystem prticleSystem;
    private Rigidbody rb;


    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }
     private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            rb.useGravity = true;
            Instantiate(prticleSystem, transform.position, Quaternion.identity);
        }
    }
}
