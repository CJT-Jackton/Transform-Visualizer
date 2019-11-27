using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject[] Camera = new GameObject[6];

    private Camera[] _camera = new Camera[6];
    private FocusCameraTransform[] _cameraTransform = new FocusCameraTransform[6];

    private int _activeCamera = -1;
    private Vector3 _mouseOrigin;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; ++i)
        {
            Camera cam = Camera[i].GetComponent<Camera>();
            FocusCameraTransform ct = Camera[i].GetComponent<FocusCameraTransform>();

            if (cam)
            {
                _camera[i] = cam;
            }

            if (ct)
            {
                _cameraTransform[i] = ct;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_activeCamera == -1)
            {
                for (int i = 0; i < 6; ++i)
                {
                    if (_camera[i] && _cameraTransform[i])
                    {
                        if (_camera[i].pixelRect.Contains(Input.mousePosition))
                        {
                            _activeCamera = i;
                            _mouseOrigin = Input.mousePosition;
                            break;
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _activeCamera = -1;
        }

        if (Input.GetMouseButton(0))
        {
            if (_activeCamera != -1)
            {
                Vector3 t = Input.mousePosition - _mouseOrigin;
                t *= 0.0001f;
                _cameraTransform[_activeCamera].Yaw += t.x;
                _cameraTransform[_activeCamera].Pitch -= t.y;
            }
        }

        for (int i = 0; i < 6; ++i)
        {
            if (_camera[i] && _cameraTransform[i])
            {
                if (_camera[i].pixelRect.Contains(Input.mousePosition))
                {
                    _cameraTransform[i].Distance += Input.mouseScrollDelta.y * -0.1f;
                }
            }
        }
    }
}
