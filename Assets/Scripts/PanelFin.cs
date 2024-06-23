using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelFin : MonoBehaviour
{
    public TextMeshProUGUI totalScoreText;

    private void Start()
    {
        SetTotalScore();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GoToNextLevel()
    {
        int nextLevel=SceneManager.GetActiveScene().buildIndex+1;
        unlockNextlevel(nextLevel);
        
        if (nextLevel < 11)
        {
           SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    
    public void unlockNextlevel(int lvl)
    {
        int lastUnlockedLevel = PlayerPrefs.GetInt("lastLevel");
        if (lvl > lastUnlockedLevel)  
        {
            PlayerPrefs.SetInt("lastLevel", lvl);            
        }

    }

    public void SetTotalScore()
    {
        totalScoreText.text = "Total Score: " + GameManager._instance.score;
    }
    
    public void QuitApp()
    {
        Application.Quit();
    }




}
