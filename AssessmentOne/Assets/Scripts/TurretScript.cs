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
    LayerMask cameraLayer;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform origin;
    [SerializeField]
    ShipScript shipScript;
    bool reloaded;
    bool reloading;
    bool inRange;


    void Start()
    {
        reloaded = false;
        reloading = false;
        inRange = false;
        Invoke("Reload", 1);
    }


    void Update()
    {
        if (!shipScript.deathTimerOn && !shipScript.winTimerOn) {
            if (Physics.CheckSphere(transform.position, 500, player))
            {
                inRange = true;
                Debug.Log(inRange);
            }
            else
            {
                inRange = false;
            }
            if (!reloaded && !reloading)
            {
                Invoke("Reload", 1);
                reloading = true;
            }
            else if (reloaded && inRange && !Physics.CheckSphere(transform.position, 150, cameraLayer))
            {
                Shoot();
            }
            if (inRange)
            {
                transform.LookAt(ship);
            }
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
        GameObject shot = Instantiate(projectile);
        shot.transform.position = origin.position;
        shot.transform.LookAt(ship);
    }
}
