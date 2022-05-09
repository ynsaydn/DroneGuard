using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneGuardMainDrone
{ 
    [RequireComponent(typeof(Rigidbody))]

    public class MainDroneBaseRigidbody : MonoBehaviour
    {
        [Header("Rigidbody Properties")]
        [SerializeField] private float weightInLbs = 1f;


        const float IbsToKg = 0.454f;

        protected Rigidbody rb;
        protected float startDrag;
        protected float startAngularDrag;


        // Start is called before the first frame update
        void Awake() 
        {
            rb = GetComponent<Rigidbody>();
            if(rb) 
            {
               rb.mass = weightInLbs * IbsToKg;
               startDrag = rb.drag;
               startAngularDrag = rb.angularDrag;
            }
        }
        
        
        // Update is called once per frame
        void FixedUpdate()
        {
            if(!rb)
            {
                return;
            }

            HandlePhysics();
        }

        protected virtual void HandlePhysics() { }
    }

}   

    
