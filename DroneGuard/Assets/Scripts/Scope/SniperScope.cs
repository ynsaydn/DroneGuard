using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScope : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject sniperScope;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            playerCam.GetComponent<Camera>().fieldOfView = 15;
            sniperScope.SetActive(true);
        }
        if(Input.GetButtonUp("Jump"))
        {
            playerCam.GetComponent<Camera>().fieldOfView = 90;
            sniperScope.SetActive(false);
        }
    }
}
