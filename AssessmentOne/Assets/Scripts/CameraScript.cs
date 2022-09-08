using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    ShipScript shipScript;
    Transform shipTransform;
    [SerializeField]
    Vector3 cameraOffset;
    void Start()
    {
        //Copy ship location
        shipTransform = shipScript.shipTransform;
    }

    void Update()
    {
        //Position camera relative to ship, but if ship is at the top of the tunnel, don't move the camera out of the tunnel (tunnel height maxes out at y=50 and height offset is +2)
        if (shipTransform.position.y < 48)
        {
            transform.position = shipTransform.position + cameraOffset;
        }
        else
        {
            transform.position = new Vector3(shipTransform.position.x, 48, shipTransform.position.z) + cameraOffset;
        }
    }
}
