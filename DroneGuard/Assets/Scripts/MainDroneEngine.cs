using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneGuardMainDrone

{
    [RequireComponent(typeof(BoxCollider))]

    public class MainDroneEngine : MonoBehaviour, IEngine
    {

        [Header("Engine Properties")]
        [SerializeField] private float maxPower = 4f;

        [Header ("Propeller Properties")]
        [SerializeField] private Transform propeller;
        [SerializeField] private float propRotSpeed = 300f ;





        void IEngine.InitEngine()
        {
            throw new System.NotImplementedException();
        }

        

        void IEngine.UpdateEngine(Rigidbody rb, MainDroneInputs input)
        {
            //Debug.Log("Running Engine:" + gameObject.name);

            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * diff;

            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass* Physics.gravity.magnitude + finalDiff) + (input.Throttle * maxPower)) / 4f;
        
            rb.AddForce(engineForce, ForceMode.Force);
            HandlePropellers();
        }

        void HandlePropellers()
        {
            if(!propeller)
            {
                return;
            }
            propeller.Rotate(Vector3.forward, propRotSpeed );
        }
    }
}
