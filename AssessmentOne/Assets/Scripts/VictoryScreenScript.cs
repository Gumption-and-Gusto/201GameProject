using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreenScript : MonoBehaviour
{
    [SerializeField]
    GameObject victoryScreen;
    [SerializeField]
    GameObject ship;
    ShipScript shipScript;
    [SerializeField]
    CanvasGroup whiteout;
    // Start is called before the first frame update
    void Start()
    {
        shipScript = ship.GetComponent<ShipScript>();
        victoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shipScript.winTimer <= 0)
        {
            victoryScreen.SetActive(true);
            victoryScreen.GetComponent<CanvasGroup>().alpha += 0.7f * Time.deltaTime;
            whiteout.alpha -= 0.1f * Time.deltaTime;
        }
    }
}
