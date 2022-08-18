using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    float timer = 3;
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
        rb.AddRelativeForce(Vector3.down * Time.deltaTime * engineSpeed);
        transform.position = new Vector3(-40,-20,2200);
    }

    // Update is called once per frame
    void Update()
    {
        shipTransform = transform;
        if (timer < 0) 
        {
            mouseMoves = new Vector3(Input.GetAxis("Mouse X") * -1, Input.GetAxis("Mouse Y") * 7 / 3, 0);
            rb.AddForce(mouseMoves * Time.deltaTime * strafeSpeed);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    //Input.GetAxis("Mouse X") * -1 Input.GetAxis("Mouse Y") * 7 / 3
}
