using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCameraTransform : MonoBehaviour
{
    public GameObject gameObject;

    void Start()
    {
        transform.parent = gameObject.transform;
        transform.LookAt(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {
            //transform.position = ;
            // transform.LookAt(gameObject.transform);
        }
    }
}
