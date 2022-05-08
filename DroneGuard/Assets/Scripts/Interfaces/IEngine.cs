using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneGuardMainDrone
{


    public interface IEngine
    {
        void InitEngine();
        void UpdateEngine(Rigidbody rb,MainDroneInputs input );
    }

}