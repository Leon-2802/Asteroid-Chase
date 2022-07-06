using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private GameObject asteroidChase = null;
    [SerializeField] private GameObject endlessChase = null;
    [SerializeField] private GameObject hideMenu = null;
    [SerializeField] private GameObject loadingBar = null;
    [SerializeField] private ProgressBar fillAmount = null;
    private AsyncOperation sceneToLoad;
    private bool playActive = false;

    public void Play() 
    {
        if(playActive)
        {
            asteroidChase.SetActive(false);
            endlessChase.SetActive(false);
            playActive = false;
        }
        else 
        {
            asteroidChase.SetActive(true);
            endlessChase.SetActive(true);
            playActive = true;
        }
    }
    public void AsteroidChase()
    {
        hideMenu.SetActive(true);
        loadingBar.SetActive(true);
        sceneToLoad = SceneManager.LoadSceneAsync("main");
        StartCoroutine(LoadingScreen());
    }

    public void Exit() 
    {
        Application.Quit();
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0f;
        fillAmount.slider.value = totalProgress;
        while(!sceneToLoad.isDone)
        {
            totalProgress += sceneToLoad.progress;
            fillAmount.slider.value = totalProgress;
            yield return null;
        }
    }
}
