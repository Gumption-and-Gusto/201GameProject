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
    Vector3 mouse;
        // Start is called before the first frame update
    void Start()
    {
        shipTransform = shipScript.shipTransform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = shipTransform.position + cameraOffset;
    }
}
