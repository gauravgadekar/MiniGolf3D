using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        transform.RotateAround(target.transform.position,Vector3.up, 20*Time.deltaTime);
    }
}
