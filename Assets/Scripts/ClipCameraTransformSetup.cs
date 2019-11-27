using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipCameraTransformSetup : MonoBehaviour
{
    public GameObject MainCamera;

    private Camera _camera;
    private FocusCameraTransform _cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        _camera = MainCamera.GetComponent<Camera>();
        _cameraTransform = GetComponent<FocusCameraTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera)
        {
            _cameraTransform.focusPosition = new Vector3(0, 0, (_camera.farClipPlane - _camera.nearClipPlane) / 2);
        }
    }
}
