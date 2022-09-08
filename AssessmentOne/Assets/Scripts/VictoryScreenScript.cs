using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreenScript : MonoBehaviour
{
    [SerializeField]
    GameObject victoryScreen;
    [SerializeField]
    GameObject ship;
    ShipScript shipScript;
    [SerializeField]
    CanvasGroup whiteout;
    public bool succeeded;
    void Start()
    {
        succeeded = false;
        shipScript = ship.GetComponent<ShipScript>();
        victoryScreen.SetActive(false);
    }

    void Update()
    {
        //Timer in the ship script sets this screen to begin fading in
        if (shipScript.winTimer <= 0)
        {
            PlayerPrefs.SetFloat("Progress", SceneManager.GetActiveScene().buildIndex + 1);
            victoryScreen.SetActive(true);
            succeeded = true;
            victoryScreen.GetComponent<CanvasGroup>().alpha += 0.7f * Time.deltaTime;
            whiteout.alpha -= 0.1f * Time.deltaTime;
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
