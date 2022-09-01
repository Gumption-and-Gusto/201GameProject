using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject missions;
    // Start is called before the first frame update
    void Start()
    {
        missions.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchIntroCinematic()
    {

    }

    public void LaunchLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void Missions()
    {
        mainMenu.SetActive(false);
        missions.SetActive(true);
    }
    public void BackFromMissions()
    {
        mainMenu.SetActive(true);
        missions.SetActive(false);
    }
}