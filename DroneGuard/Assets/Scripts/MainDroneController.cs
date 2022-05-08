using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DroneGuardMainDrone
{
    [RequireComponent(typeof(MainDroneInputs))]

    public class MainDroneController : MainDroneBaseRigidbody
    {

        [Header("Control Properties")]
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 4f;
        [SerializeField] private float lerpSpeed = 2f;

        private MainDroneInputs input;
        private List<IEngine> engines = new List<IEngine>();

        private float finalPitch;
        private float finalRoll;
        private float yaw; 
        private float finalYaw;
        
        void Start()
        {
            input = GetComponent<MainDroneInputs>();
            engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
        }




        protected override void HandlePhysics()
        {
           HandleEngines();
           HandleControls();
        }

        protected virtual void HandleEngines()
        {
            //rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));
            foreach(IEngine engine in engines)
            {
                engine.UpdateEngine(rb, input);
            }

        }

        protected virtual void HandleControls()
        {
            float pitch = input.Cyclic.y * minMaxPitch;
            float roll = -input.Cyclic.x * minMaxRoll;
            yaw += input.Pedals * yawPower; 

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

            Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
            rb.MoveRotation(rot);
        }


    }
}
