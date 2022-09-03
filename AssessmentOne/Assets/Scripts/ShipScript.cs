using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    float timer = 3;
    public float deathTimer = 1;
    public float winTimer = 1;
    bool deathTimerOn = false;
    bool winTimerOn = false;
    Vector3 mouseMoves;
    [SerializeField]
    GameObject reactorStream;
    [SerializeField]
    float strafeSpeed;
    [SerializeField]
    float engineSpeed;
    Rigidbody rb;
    public Transform shipTransform;
    [SerializeField]
    ParticleSystem explosion;
    [SerializeField]
    ParticleSystem nuclearDetonation;
    [SerializeField]
    GameObject body;
    [SerializeField]
    GameObject sphere;
    [SerializeField]
    ParticleSystem exhaust;
    [SerializeField]
    CanvasGroup whiteout;
    [SerializeField]
    PauseScript pauseScript;
    Vector3 startPosition = new(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        pauseScript.Unpause();
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(-40,-20, 2200);
        startPosition = transform.position;
        if (startPosition == transform.position)
        {
            rb.AddRelativeForce(Vector3.up * engineSpeed);
        }
        deathTimer = 1;
        winTimer = 1;
        body.GetComponent<Renderer>().enabled = true;
        sphere.GetComponent<Renderer>().enabled = true;
    }   
    // Update is called once per frame
    void Update()
    {
        shipTransform = transform;
        if (timer < 0 && deathTimerOn == false && pauseScript.paused == false) 
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
        if (winTimerOn == true && winTimer > 0)
        {
            winTimer -= Time.deltaTime;
            whiteout.alpha += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        body.GetComponent<Renderer>().enabled = false;
        sphere.GetComponent<Renderer>().enabled = false;
        exhaust.Stop();
        if (collision.gameObject == reactorStream)
        {
            nuclearDetonation.Play();
            winTimerOn = true;
        }
        else {

            explosion.Play();
            deathTimerOn = true;

        }
    }
}
