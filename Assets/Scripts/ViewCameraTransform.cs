using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCameraTransform : MonoBehaviour
{
    public GameObject _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = _mainCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
