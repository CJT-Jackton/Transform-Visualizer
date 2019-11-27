using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ClipMatrixSetup : MonoBehaviour
{
    public GameObject camera;

    private Camera _cam;
    private Material _material;

    private Matrix4x4 _matrix;

    // Start is called before the first frame update
    void Start()
    {
        _cam = camera.GetComponent<Camera>();
        _material = GetComponent<Renderer>().sharedMaterial;

        if (_cam)
        {
            _matrix = _cam.projectionMatrix * _cam.worldToCameraMatrix;
            _material.SetMatrix("_MVPMatrix", _matrix);
        }
    }

    void Update()
    {
        if (true)
        {
            _matrix = _cam.projectionMatrix * _cam.worldToCameraMatrix;
            _material.SetMatrix("_MVPMatrix", _matrix);
        }
    }
}
