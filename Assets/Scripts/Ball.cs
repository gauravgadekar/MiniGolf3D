using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public GameObject winParticles;
    public TextMeshProUGUI text;
    public Shot shotScript;
    public GameObject panelFin;
    public Transform cubeFin;
    public GameObject camZoom;
    bool canZoom = true;
   
    
    
    public void Start()
    {
        cubeFin = GameObject.Find("fin").transform;
    }

    private void Update()
    {

        if (camZoom)
        {
            if (Vector3.Distance(transform.position, cubeFin.position)<2f)
            {
                if (canZoom)
                {
                    canZoom = false;
                    camZoom.SetActive(true);   
                    camZoom.GetComponent<DisableZoom>().ForceDisable();
                }
            
            }
            else
            {
                camZoom.SetActive(false);
                canZoom = true;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.gameObject.tag == "fall")
        {
            SFXManager.instance.PlaySfxById(2);
            StartCoroutine("LoadLevelAfterSeconds");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
        
        
        if (other.gameObject.tag == "fin")
        {
            int score = (10 - shotScript.nbShots) * 100;

            if (score<0)
            {
                score = 0;
            }

            GameManager.instance.score += score + GameManager.instance.bonusCount ;
            
            GameManager.
            
            Instantiate(winParticles, transform.position, quaternion.identity);
            SFXManager.instance.PlaySfxById(0);
            text.text = "Completed in " + shotScript.nbShots + "Shots!";
            
            panelFin.SetActive(true);

        }

        if (other.gameObject.tag=="bonus")
        {
            Destroy(other.gameObject);
            SFXManager.instance.PlaySfxById(3);
            GameManager.instance.bonusCount++;
        }
    }

    IEnumerator LoadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
