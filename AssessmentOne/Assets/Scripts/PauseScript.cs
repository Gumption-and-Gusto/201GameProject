using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    GameObject pause;
    [SerializeField]
    GameObject options;
    [SerializeField]
    GameObject ship;
    [SerializeField]
    Slider musicSlider;
    [SerializeField]
    Slider SFXSlider;
    [SerializeField]
    Slider voiceSlider;
    [SerializeField]
    Slider sensitivitySlider;
    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource SFXSource;
    [SerializeField]
    AudioSource voiceSource;
    public bool paused;
    void Start()
    {
        options.SetActive(false);
        //set sliders to match preferences and set volumes appropriately
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        SFXSource.volume = PlayerPrefs.GetFloat("SFXVolume");
        voiceSource.volume = PlayerPrefs.GetFloat("VoiceVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        voiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume");
        sensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        paused = true;
        pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        paused = false;
        pause.SetActive(false);
        options.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        options.SetActive(true);
    }
    public void Back()
    {
        options.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    //Save preferences
    public void SaveMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        musicSource.volume = musicSlider.value;
    }
    public void SaveSFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        SFXSource.volume = SFXSlider.value;
    }
    public void SaveVoiceVolume()
    {
        PlayerPrefs.SetFloat("VoiceVolume", voiceSlider.value);
        voiceSource.volume = voiceSlider.value;
    }
    public void SaveMouseSensistivity()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivitySlider.value);
    }
}
