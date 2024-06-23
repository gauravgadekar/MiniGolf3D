using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public RectTransform powerBar;
    bool powerActivated = false;
    public GameObject ball;
    private bool canShot = true;
    private bool canCheckSpeed = false;
    public int shotPowerMultiplier;
    public int nbShots = 0;
    public GameObject aim;


    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            HandleShot();
        }

        if ((ball.GetComponent<Rigidbody>().velocity.magnitude < 0.2f) && (canCheckSpeed))
        {
            canShot = true;
            gameObject.GetComponent<Button>().interactable = canShot;
        }
    }

    public void HandleShot()
    {
        if (canShot)
        {
            if (!powerActivated)
            {
                aim.SetActive(true);
                ActivatePowerBar();
            }
            else
            {
                canShot = false;
                gameObject.GetComponent<Button>().interactable = canShot;
                SFXManager.instance.PlaySfxById(3);
                nbShots++;
                aim.SetActive(false);
                ShotTheBall();
            }
        }
       
    }
    
    public void ActivatePowerBar()
    {
        SFXManager.instance.PlaySfxById(4);
        powerActivated = true;
        StartCoroutine("AnimatePowerBar");
    }

    public void ShotTheBall()
    {
        SFXManager.instance.PlaySfxById(1);
        powerActivated = false;
        StopAllCoroutines();
        float shotPower = powerBar.localScale.x*shotPowerMultiplier;

        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shotPower );

        StartCoroutine("ActivateSpeedCheck");
    }

    IEnumerator ActivateSpeedCheck()
    {
        yield return new WaitForSeconds(1);
        canCheckSpeed = true;
    }

    IEnumerator AnimatePowerBar()
    {
        float val = 0.1f;
        while (powerActivated)
        {
            yield return new WaitForSeconds(0.15f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - val, powerBar.localScale.y, 0);
            if (powerBar.localScale.x < 0.2f )
            {
                val = -0.1f;
            }
            if (powerBar.localScale.x > 0.9f )
            {
                val = 0.1f;
            }
        }
    }
}
