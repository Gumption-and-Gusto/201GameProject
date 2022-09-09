using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    Transform ship;
    void Start()
    {
    }

    void Update()
    {
        transform.position = ship.position + new Vector3(0, 0, -150);
    }
}
