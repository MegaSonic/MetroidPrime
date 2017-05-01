using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraToSwitch;
    public bool canSwitch = true;
    public GameObject activeCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (canSwitch)
            {
                if (cameraToSwitch.activeSelf)
                {
                    cameraToSwitch.SetActive(false);
                    activeCamera.SetActive(true);
                }
                else
                {
                    activeCamera.SetActive(false);
                    cameraToSwitch.SetActive(true);
                }
                canSwitch = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canSwitch = true;
    }
}
