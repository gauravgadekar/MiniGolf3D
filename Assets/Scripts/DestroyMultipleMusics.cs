using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMultipleMusics : MonoBehaviour
{
    private GameObject[] go;
    private void Start()
    {
        go = GameObject.FindGameObjectsWithTag("music");

        if (go.Length > 1)
        {
            Destroy(go[1]);
        }
    }
}
