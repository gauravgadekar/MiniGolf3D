using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject IHM;
    public GameObject animcam;
    public GameObject gamecam;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || (Input.GetMouseButtonUp(0)))
        {
            IHM.SetActive(true);
            animcam.SetActive(false);
            gamecam.SetActive(true);
            this.gameObject.SetActive(false);
            
        }
    }
    
    
}
