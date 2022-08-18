using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    Vector3 mouseMoves;
    [SerializeField]
    float strafeSpeed;
    [SerializeField]
    float engineSpeed;
    Rigidbody rb;
    public Transform shipTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * engineSpeed);
        //transform.position = Vector3.one;
        
    }

    // Update is called once per frame
    void Update()
    {
        shipTransform = transform;
        mouseMoves = new Vector3(Input.GetAxis("Mouse X") * -1, Input.GetAxis("Mouse Y") * 7/3, 0);
        transform.position = transform.position + mouseMoves * Time.deltaTime * strafeSpeed;
    }
}
