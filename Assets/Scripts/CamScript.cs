using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamScript : MonoBehaviour
{
    public GameObject ball;
    public float distance = 3.5f;
    private float x = 0f;
    private float y = 0f;
    private Quaternion rotation;

    private void Start()
    {
        x = transform.eulerAngles.y;
        y = transform.eulerAngles.x;
    }

    private void LateUpdate()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        x += Input.GetAxis("Mouse X") * 3;
#endif

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            x += Input.GetTouch(0).deltaPosition.x * 0.1f;            
        }
#endif

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            rotation = Quaternion.Euler(y, x, 0);
        }

        Vector3 position = rotation * new Vector3(0f, ball.transform.position.y / 3 + 1, -distance) + ball.transform.position;

        transform.rotation = rotation;
        transform.position = position;

        if (transform.position.y < 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        }
    }
}