using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenScript : MonoBehaviour
{
    [SerializeField]
    GameObject deathScreen;
    [SerializeField]
    GameObject ship;
    ShipScript shipScript;
    // Start is called before the first frame update
    void Start()
    {
        shipScript = ship.GetComponent<ShipScript>();
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shipScript.deathTimer <= 0)
        {
            deathScreen.SetActive(true);
            deathScreen.GetComponent<CanvasGroup>().alpha += 0.7f * Time.deltaTime;
        }
    }
}
