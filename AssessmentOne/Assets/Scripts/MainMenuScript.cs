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
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    CanvasGroup slideshowBackground;
    [SerializeField]
    CanvasGroup slide1;
    [SerializeField]
    CanvasGroup slide2;
    [SerializeField]
    CanvasGroup slide3;
    bool fadeInBackground;
    bool fadeInSlide1;
    bool fadeInSlide2;
    bool fadeInSlide3;
    // Start is called before the first frame update
    void Start()
    {
        missions.SetActive(false);
        mainMenu.SetActive(true);
        fadeInBackground = false;
        fadeInSlide1 = false;
        fadeInSlide2 = false;
        fadeInSlide3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInBackground)
        {
            slideshowBackground.alpha += Time.deltaTime * 4;
        }
        else
        {
            slideshowBackground.alpha -= Time.deltaTime * 4;
        }
        if (fadeInSlide1)
        {
            slide1.alpha += Time.deltaTime * 4;
        }
        else
        {
            slide1.alpha -= Time.deltaTime * 10;
        }
        if (fadeInSlide2)
        {
            slide2.alpha += Time.deltaTime * 10;
        }
        else
        {
            slide2.alpha -= Time.deltaTime * 10;
        }
        if (fadeInSlide3)
        {
            slide3.alpha += Time.deltaTime * 10;
        }
        else
        {
            slide3.alpha -= Time.deltaTime * 4;
        }
    }

    public void LaunchIntroCinematic()
    {
        Invoke("LaunchLevel1", audioSource.clip.length + 4);
        mainMenu.SetActive(false);
        Invoke("PlayAudio", 0.5f);
        fadeInBackground = true;
        fadeInSlide1 = true;
        Invoke("FadeSlide1", 10.5f);
        Invoke("Slide2On", 11.5f);
        Invoke("FadeSlide2", 32);
        Invoke("Slide3On", 33);
        Invoke("FadeSlide3", 39);
        Invoke("FadeBG", 39);
    }

    void PlayAudio()
    {
        audioSource.Play();
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

    void Slide2On()
    {
        fadeInSlide2 = true;
    }
    void Slide3On()
    {
        fadeInSlide3 = true;
    }

    void FadeBG()
    {
        fadeInBackground = false;
    }

    void FadeSlide1()
    {
        fadeInSlide1 = false;
    }
    void FadeSlide2()
    {
        fadeInSlide2 = false;
    }
    void FadeSlide3()
    {
        fadeInSlide3 = false;
    }
}