using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField]
    Transform ship;
    [SerializeField]
    LayerMask player;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform projectileStart;
    bool reloaded;
    bool reloading;


    void Start()
    {
        reloaded = true;
        reloading = false;
    }


    void Update()
    {
        if(!reloaded && !reloading)
        {
            Invoke("Reload", 1);
            reloading = true;
        }
        else if(reloaded && Physics.CheckSphere(transform.position, 500, player)){
            Vector3 aimDirection = ship.position - transform.position;
            Quaternion aimRotation = Quaternion.LookRotation(aimDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, aimRotation, Time.deltaTime * 10);
            Shoot();
        }
    }
    void Reload()
    {
        reloading = false;
        reloaded = true;
    }

    void Shoot()
    {
        reloaded = false;
        GameObject shot = Instantiate(projectile, projectileStart);
        Rigidbody shotRB = shot.GetComponent<Rigidbody>();
        shotRB.AddRelativeForce(Vector3.forward * 100);
    }
}
