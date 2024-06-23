using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioSource backgroundMusic;

    private void Start()
    {
        float val = PlayerPrefs.GetFloat("Volume");

        if (val==0)
        {
            val = 0.2f;
        }
        GetComponent<Slider>().value= val;
        backgroundMusic.volume = val;
    }

    public void SetVol()
    {
        
        float val = GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Volume", val);
        print("volume= "+ val);

        backgroundMusic.volume = val;
    }

}
