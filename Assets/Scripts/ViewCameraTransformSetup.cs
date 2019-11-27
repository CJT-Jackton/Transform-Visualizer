using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCameraTransformSetup : MonoBehaviour
{
    public GameObject MainCamera;

    private Camera _camera;
    private FocusCameraTransform _cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        if (MainCamera)
        {
            transform.parent = MainCamera.transform;
            //transform.localPosition = Vector3.zero;

            _camera = MainCamera.GetComponent<Camera>();
            _cameraTransform = GetComponent<FocusCameraTransform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera)
        {
            _cameraTransform.focusPosition = MainCamera.transform.position
                + MainCamera.transform.TransformDirection(new Vector3(0, 0, _camera.farClipPlane / 2));
                //+ MainCamera.transform.forward * (_camera.farClipPlane / 2);
            //_cameraTransform.focusPosition = MainCamera.transform.position;

            //Debug.Log(_cameraTransform.focusPosition);
        }
    }
}
