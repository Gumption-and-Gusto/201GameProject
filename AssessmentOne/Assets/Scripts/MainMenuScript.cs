using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject missions;
    [SerializeField]
    GameObject options;
    [SerializeField]
    Slider musicSlider;
    [SerializeField]
    Slider SFXSlider;
    [SerializeField]
    Slider voiceSlider;
    [SerializeField]
    Slider sensitivitySlider;
    [SerializeField]
    AudioSource introMonologue;
    [SerializeField]
    AudioSource music;
    [SerializeField]
    CanvasGroup slideshowBackground;
    [SerializeField]
    CanvasGroup slide1;
    [SerializeField]
    CanvasGroup slide2;
    [SerializeField]
    CanvasGroup slide3;
    [SerializeField]
    CanvasGroup slide4;
    bool fadeInBackground;
    bool fadeInSlide1;
    bool fadeInSlide2;
    bool fadeInSlide3;
    bool fadeInSlide4;
    // Start is called before the first frame update
    void Start()
    {
        missions.SetActive(false);
        mainMenu.SetActive(true);
        options.SetActive(false);
        fadeInBackground = false;
        fadeInSlide1 = false;
        fadeInSlide2 = false;
        fadeInSlide3 = false;
        fadeInSlide4 = false;
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
        introMonologue.volume = PlayerPrefs.GetFloat("VoiceVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        voiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume");
        sensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
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
            slide3.alpha -= Time.deltaTime * 10;
        }
        if (fadeInSlide4)
        {
            slide4.alpha += Time.deltaTime * 10;
        }
        else
        {
            slide4.alpha -= Time.deltaTime * 4;
        }
    }

    public void SaveMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        music.volume = musicSlider.value;
    }
    public void SaveSFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
    public void SaveVoiceVolume()
    {
        PlayerPrefs.SetFloat("VoiceVolume", voiceSlider.value);
        introMonologue.volume = voiceSlider.value;
    }
    public void SaveMouseSensistivity()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivitySlider.value);
    }
    public void LaunchIntroCinematic()
    {
        if (music.volume > 0.1)
        {
            music.volume = 0.1f;
        }
        Invoke("LaunchLevel1", introMonologue.clip.length + 3);
        mainMenu.SetActive(false);
        Invoke("PlayAudio", 0.5f);
        fadeInBackground = true;
        fadeInSlide1 = true;
        Invoke("FadeSlide1", 10.5f);
        Invoke("Slide2On", 11.5f);
        Invoke("FadeSlide2", 25.5f);
        Invoke("Slide3On", 26.5f);
        Invoke("FadeSlide3", 32);
        Invoke("Slide4On", 33);
        Invoke("FadeSlide4", 39);
        Invoke("FadeBG", 39);
    }

    void PlayAudio()
    {
        introMonologue.Play();
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

    public void Options()
    {
        options.SetActive(true);
    }

    public void BackFromOptions()
    {
        options.SetActive(false);
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
    void Slide4On()
    {
        fadeInSlide4 = true;
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
    void FadeSlide4()
    {
        fadeInSlide4 = false;
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}