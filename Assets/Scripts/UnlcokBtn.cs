using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlcokBtn : MonoBehaviour
{
    void Start()
    {
        int lvl = PlayerPrefs.GetInt("lastLevel");
        int thisLvl = int.Parse(gameObject.name);

        if (thisLvl <= lvl)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
