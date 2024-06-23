using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAnim : MonoBehaviour
{
    private void Start()
    {
        iTween.PunchScale(gameObject,iTween.Hash("loopType", iTween.LoopType.loop,"amount", new Vector3(transform.localScale.x*0.3f,transform.localScale.y *0.3f,transform.localScale.z * 0.3f)));
    }
}
