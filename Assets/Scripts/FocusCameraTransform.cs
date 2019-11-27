using UnityEngine;

public class FocusCameraTransform : MonoBehaviour
{
    public enum Type { Object, Position };
    public Type type;
    [Space(10)]
    public GameObject focusObject;
    public Vector3 focusPosition;

    public float Pitch
    {
        get { return _pitch; }
        set { _pitch = Mathf.Clamp(value, -0.2499f, 0.2499f); }
    }
    public float Yaw
    {
        get { return _yaw; }
        set { _yaw = value % 1; }
    }
    public float Distance
    {
        get { return _distance; }
        set { _distance = Mathf.Max(value, 0); }
    }

    [Space(10)]
    [Header("Transformation")]
    [SerializeField, Range(-0.2499f, 0.2499f)]
    private float _pitch;
    [SerializeField, Range(0, 1)]
    private float _yaw;
    [SerializeField]
    private float _distance;

    private float _pitchRad;
    private float _yawRad;

    void Start()
    {
        if (type is Type.Object && focusObject)
        {
            transform.parent = focusObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _pitchRad = _pitch * 2f * Mathf.PI;
        _yawRad = _yaw * 2f * Mathf.PI;

        Vector3 pos = new Vector3(Mathf.Cos(_pitchRad) * Mathf.Cos(_yawRad), Mathf.Sin(_pitchRad), Mathf.Cos(_pitchRad) * Mathf.Sin(_yawRad));
        pos *= _distance;

        if (type is Type.Object && focusObject)
        {
            transform.localPosition = pos;
            transform.LookAt(focusObject.transform, transform.parent.up);
        }

        if(type is Type.Position)
        {
            transform.localPosition = pos;
            transform.LookAt(transform.parent, transform.parent.up);
            transform.localPosition += transform.parent.InverseTransformPoint(focusPosition);
        }
    }
}
