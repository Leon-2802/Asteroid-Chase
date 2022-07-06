using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseCtrl : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen = null;
    [SerializeField] private AudioSource music = null;
    [SerializeField] private Image pauseButton = null;
    [SerializeField] private Sprite pauseImage = null;
    [SerializeField] private Sprite playImage = null;
    [SerializeField] private GameObject resume = null;
    [SerializeField] private GameObject menu = null;
    private bool pause = false;
    private float standardVolume;

    void Start() 
    {
        standardVolume = music.volume;
        pause = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        resume.SetActive(false);
        menu.SetActive(false);
        music.volume = standardVolume;
        pauseButton.sprite = pauseImage;
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump") && pause == false) 
            Pause();
        else if(Input.GetButtonDown("Jump") && pause == true) 
            Play();
    }
    public void ButtonPressed()
    {
        if(pause == false)
            Pause();
        else
            Play();
    }

    public void MenuBtn()
    {
        music.volume = standardVolume;
        SceneManager.LoadScene("menu");
    }

    void Pause()
    {
        pause = true;
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        resume.SetActive(true);
        menu.SetActive(true);
        if(music.volume > 0.2f)
            music.volume = 0.2f;
        pauseButton.sprite = playImage;
    }
    void Play()
    {
        pause = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        resume.SetActive(false);
        menu.SetActive(false);
        music.volume = standardVolume;
        pauseButton.sprite = pauseImage;
    }
}
