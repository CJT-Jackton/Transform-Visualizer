using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class UIController : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    public GameObject[] Cameras = new GameObject[6];

    private Camera[] _camera = new Camera[6];
    private Text[] _labelText = new Text[6];
    private string[] _viewportLabel = {
        "Object Space", "World Space", "View Space",
        "Clip Space", "NDC Space", "Screen Space"
    };

    private void DrawLabel()
    {
        for(int i = 0; i < 6; ++i)
        {
            if (_camera[i])
            {
                Vector3 pos = _camera[i].ViewportToScreenPoint(new Vector3(0.5f, 0.0f, 0.0f));
                _labelText[i].transform.position = pos;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i= 0; i < 6; ++i)
        {
            Camera cam = Cameras[i].GetComponent<Camera>();

            if (cam)
            {
                _camera[i] = cam;
            }

            _labelText[i] = Instantiate(text, canvas.transform);
            _labelText[i].name = "Text [" + _viewportLabel[i] + "]";
            _labelText[i].text = _viewportLabel[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        DrawLabel();
    }
}
