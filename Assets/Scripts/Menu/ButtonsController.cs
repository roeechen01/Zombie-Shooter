using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonsController : MonoBehaviour
{
    private AudioSource audioSource;
    private Toggle toggle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        toggle = FindObjectOfType<Toggle>();
        if (toggle)
            toggle.isOn = Blood.active;

    }
    public void ButtonClicked(string sceneName)
    {
        audioSource.Play();
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        //FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Stop();
        Application.Quit();
    }

    public void SetBlood()
    {
        Blood.active = toggle.isOn;
    }
}


