using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    float timer = 3;
    public float deathTimer = 1;
    bool deathTimerOn = false;
    Vector3 mouseMoves;
    [SerializeField]
    float strafeSpeed;
    [SerializeField]
    float engineSpeed;
    Rigidbody rb;
    public Transform shipTransform;
    [SerializeField]
    ParticleSystem explosion;
    [SerializeField]
    GameObject body;
    [SerializeField]
    GameObject sphere;
    [SerializeField]
    ParticleSystem exhaust;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * engineSpeed);
        transform.position = new Vector3(-40,-20,2200);
    }

    // Update is called once per frame
    void Update()
    {
        shipTransform = transform;
        if (timer < 0 && deathTimerOn == false) 
        {
            mouseMoves = new Vector3(Input.GetAxis("Mouse X") * -1, Input.GetAxis("Mouse Y") * 7 / 3, 0);
            rb.AddForce(mouseMoves * Time.deltaTime * strafeSpeed);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (deathTimerOn == true && deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        explosion.Play();
        deathTimerOn = true;
        body.GetComponent<Renderer>().enabled = false;
        sphere.GetComponent<Renderer>().enabled = false;
        exhaust.Stop();
    }
}
