using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DrawCameraFrustum : MonoBehaviour
{
    //[RequireComponent(typeof(LineRenderer))]
    public GameObject Line;
    public GameObject LineClip;

    private Camera _camera;
    private GameObject[] _lines = new GameObject[12];
    private GameObject[] _linesClip = new GameObject[12];

    void Start()
    {
        _camera = GetComponent<Camera>();

        for (int i = 0; i < _lines.Length; ++i)
        {
            _lines[i] = Instantiate(Line);
            _lines[i].name = name + "_Visualizer_" + i;
            _lines[i].SetActive(false);

            _linesClip[i] = Instantiate(LineClip);
            _linesClip[i].name = name + "_Visualizer_Clip_" + i;
            _linesClip[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] frustumNearCorners = new Vector3[4];
        Vector3[] frustumFarCorners = new Vector3[4];

        _camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), _camera.nearClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumNearCorners);
        _camera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), _camera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumFarCorners);

        Vector3[] worldSpaceNearCorner = new Vector3[4];
        Vector3[] worldSpaceFarCorner = new Vector3[4];

        Matrix4x4 _matrix = _camera.projectionMatrix * _camera.worldToCameraMatrix;

        Vector4[] clipSpaceNearCorner = new Vector4[4];
        Vector4[] clipSpaceFarCorner = new Vector4[4];

        for (int i = 0; i < 4; i++)
        {
            worldSpaceNearCorner[i] = _camera.transform.TransformVector(frustumNearCorners[i]);
            worldSpaceFarCorner[i] = _camera.transform.TransformVector(frustumFarCorners[i]);

            //clipSpaceNearCorner[i] = _matrix.MultiplyPoint(_camera.transform.position + worldSpaceNearCorner[i]);
            //clipSpaceFarCorner[i] = _matrix.MultiplyPoint(_camera.transform.position + worldSpaceFarCorner[i]);
            clipSpaceNearCorner[i] = _camera.transform.position + worldSpaceNearCorner[i];
            clipSpaceNearCorner[i].w = 1.0f;
            clipSpaceNearCorner[i] = _matrix*(clipSpaceNearCorner[i]);

            clipSpaceFarCorner[i] = _camera.transform.position + worldSpaceFarCorner[i];
            clipSpaceFarCorner[i].w = 1.0f;
            clipSpaceFarCorner[i] = _matrix*(clipSpaceFarCorner[i]);

            Debug.Log(clipSpaceNearCorner[i]);
            Debug.Log(clipSpaceFarCorner[i]);
        }

        for (int i = 0; i < 4; ++i)
        {
            LineRenderer lr = _lines[i].GetComponent<LineRenderer>();
            LineRenderer lr2 = _linesClip[i].GetComponent<LineRenderer>();
            
            if (lr)
            {
                _lines[i].SetActive(true);
                lr.SetPosition(0, _camera.transform.position + worldSpaceNearCorner[i]);
                lr.SetPosition(1, _camera.transform.position + worldSpaceFarCorner[i]);

                _linesClip[i].SetActive(true);
                lr2.SetPosition(0, clipSpaceNearCorner[i]);
                lr2.SetPosition(1, clipSpaceFarCorner[i]);
            }

            lr = _lines[i + 4].GetComponent<LineRenderer>();
            lr2 = _linesClip[i + 4].GetComponent<LineRenderer>();

            if (lr)
            {
                _lines[i + 4].SetActive(true);
                lr.SetPosition(0, _camera.transform.position + worldSpaceNearCorner[i]);
                lr.SetPosition(1, _camera.transform.position + worldSpaceNearCorner[(i + 1) % 4]);

                _linesClip[i + 4].SetActive(true);
                lr2.SetPosition(0, clipSpaceNearCorner[i]);
                lr2.SetPosition(1, clipSpaceNearCorner[(i + 1) % 4]);
            }

            lr = _lines[i + 8].GetComponent<LineRenderer>();
            lr2 = _linesClip[i + 8].GetComponent<LineRenderer>();

            if (lr)
            {
                _lines[i + 8].SetActive(true);
                lr.SetPosition(0, _camera.transform.position + worldSpaceFarCorner[i]);
                lr.SetPosition(1, _camera.transform.position + worldSpaceFarCorner[(i + 1) % 4]);

                _linesClip[i + 8].SetActive(true);
                lr2.SetPosition(0, clipSpaceFarCorner[i]);
                lr2.SetPosition(1, clipSpaceFarCorner[(i + 1) % 4]);
            }
        }
    }
}
