using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    [SerializeField]
    GameObject deathScreen;
    [SerializeField]
    GameObject ship;
    ShipScript shipScript;
    [SerializeField]
    VictoryScreenScript victoryScreenScript;
    [SerializeField]
    CanvasGroup commander;
    // Start is called before the first frame update
    void Start()
    {
        shipScript = ship.GetComponent<ShipScript>();
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shipScript.deathTimer <= 0 && !victoryScreenScript.succeeded)
        {
            deathScreen.SetActive(true);
            deathScreen.GetComponent<CanvasGroup>().alpha += 0.7f * Time.deltaTime;
            commander.alpha = 0;
        }
    }

    public void Redeploy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
