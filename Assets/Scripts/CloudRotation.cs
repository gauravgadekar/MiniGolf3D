using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRotation : MonoBehaviour
{

    public Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation*Time.deltaTime);  
    }
}
