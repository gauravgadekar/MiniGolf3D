using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{

    public Material[] mats;
    

    private void Start()
    {
        int randomsky = UnityEngine.Random.Range(0, mats.Length);
        RenderSettings.skybox = mats[randomsky];
    }

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", -0.25f*Time.time);
    }
}
