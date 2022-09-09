using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    Rigidbody RB;
    [SerializeField]
    ParticleSystem explosion;
    bool hit;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        hit = false;
    }

    void Update()
    {
        if (hit == false)
        {
            RB.AddRelativeForce(Vector3.forward * 500);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        explosion.Play();
        hit = true;
        RB.velocity = Vector3.zero;
        RB.angularVelocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        Invoke("End", 0.18f);
    }

    private void End()
    {
        gameObject.SetActive(false);
    }
}
