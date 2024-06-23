using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisableZoom : MonoBehaviour
{
    private void Start()
    {
        ForceDisable();
    }

    public void ForceDisable()
    {
        StartCoroutine("DisableThisCam");
    }

    IEnumerator DisableThisCam()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
    
}
