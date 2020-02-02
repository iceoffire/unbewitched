using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        pause.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioSource.PlayOneShot(audioClip);
            if (pause.activeInHierarchy)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        SceneManager.LoadScene((int)SceneIndexes.StoreFernando);
    }
}
