using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;

    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;

    }

    public void SetPauseState()
    {
        SFXManager.instance.PlaySfxById(3);
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        isPaused = !isPaused; 
    }


}
